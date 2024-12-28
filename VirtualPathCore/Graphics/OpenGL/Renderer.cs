using System;
using System.Diagnostics;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Avalonia.Threading;
using VirtualPathCore.Helpers;
using Silk.NET.OpenGLES;

namespace VirtualPathCore.Graphics.OpenGL;

/// <summary>
/// Renderer 类负责管理 OpenGL 渲染上下文，处理渲染管线的初始化和渲染循环
/// 它继承自 OpenGlControlBase 并实现了 IGraphicsHost<GL> 接口
/// </summary>
public class Renderer : OpenGlControlBase, IGraphicsHost<GL>
{
    /// <summary>
    /// 定义了一个样式属性 Samples，用于设置渲染时的采样数
    /// </summary>
    public static readonly StyledProperty<int> SamplesProperty = AvaloniaProperty.Register<Renderer, int>("Samples", 4);

    private readonly Stopwatch _stopwatch = new();

    private GL? context;
    private Frame? frame;

    #region Pipelines
    private RenderPipeline? canvasPipeline;
    #endregion

    #region Meshes
    private Mesh[]? canvasMeshes;
    #endregion

    /// <summary>
    /// 当 OpenGL 上下文初始化完成时触发的事件
    /// </summary>
    public event Action? OnLoad;

    /// <summary>
    /// 当 OpenGL 上下文被释放时触发的事件
    /// </summary>
    public event Action? OnUnload;

    /// <summary>
    /// 在每一帧更新时触发的事件，传递自上一帧以来的时间差（秒）
    /// </summary>
    public event DeltaAction? OnUpdate;

    /// <summary>
    /// 在每一帧渲染时触发的事件，传递自上一帧以来的时间差（秒）
    /// </summary>
    public event DeltaAction? OnRender;

    /// <summary>
    /// 当渲染窗口大小发生变化时触发的事件，传递新的宽度和高度
    /// </summary>
    public event SizeAction? OnResize;

    /// <summary>
    /// 获取或设置渲染时的采样数
    /// </summary>
    public int Samples
    {
        get { return GetValue(SamplesProperty); }
        set { SetValue(SamplesProperty, value); }
    }

    /// <summary>
    /// 当 OpenGL 上下文初始化时调用，负责初始化 OpenGL 上下文、渲染管线和网格
    /// </summary>
    /// <param name="gl">OpenGL 接口对象</param>
    protected override void OnOpenGlInit(GlInterface gl)
    {
        _stopwatch.Start();

        // Initialize the OpenGL context
        {
            context ??= GL.GetApi(gl.GetProcAddress);
            frame ??= new Frame(this);

            using Shader vs = new(this, ShaderType.VertexShader, File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Resources", "Shaders", "Canvas.vert")));
            using Shader fs = new(this, ShaderType.FragmentShader, File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Resources", "Shaders", "Canvas.frag")));
            canvasPipeline = new RenderPipeline(this, vs, fs);

            MeshFactory.GetCanvas(out Vertex[] vertices, out uint[] indices);
            canvasMeshes = [new(this, vertices, indices)];
        }

        OnLoad?.Invoke();

        OnResize?.Invoke((int)Bounds.Width, (int)Bounds.Height);
    }

    /// <summary>
    /// 当 OpenGL 上下文被释放时调用，负责释放资源并触发 OnUnload 事件
    /// </summary>
    /// <param name="gl">OpenGL 接口对象</param>
    protected override void OnOpenGlDeinit(GlInterface gl)
    {
        _stopwatch.Stop();

        OnUnload?.Invoke();

        foreach (Mesh mesh in canvasMeshes!)
        {
            mesh.Dispose();
        }
        canvasPipeline!.Dispose();
        frame!.Dispose();
        context!.Dispose();

        frame = null;
        context = null;
    }

    /// <summary>
    /// 在每一帧渲染时调用，负责更新帧状态、触发更新和渲染事件，并执行实际的渲染操作
    /// </summary>
    /// <param name="gl">OpenGL 接口对象</param>
    /// <param name="fb">帧缓冲对象</param>
    protected override void OnOpenGlRender(GlInterface gl, int fb)
    {
        if (context == null || frame == null || canvasPipeline == null || canvasMeshes == null)
        {
            throw new InvalidOperationException("The OpenGL context has not been initialized yet.");
        }

        frame.Update((int)Bounds.Width, (int)Bounds.Height, Samples);

        frame.Bind();
        {
            OnUpdate?.Invoke(_stopwatch.Elapsed.TotalSeconds);

            OnRender?.Invoke(_stopwatch.Elapsed.TotalSeconds);
        }
        frame.Unbind();

        {
            context.BindFramebuffer(GLEnum.Framebuffer, (uint)fb);
            context.Viewport(0, 0, (uint)Bounds.Width, (uint)Bounds.Height);

            context.Clear((uint)GLEnum.ColorBufferBit | (uint)GLEnum.DepthBufferBit | (uint)GLEnum.StencilBufferBit);

            foreach (Mesh mesh in canvasMeshes)
            {
                canvasPipeline.Bind();

                canvasPipeline.SetUniform("Tex", 0, frame.Texture);

                mesh.VertexAttributePointer((uint)canvasPipeline.GetAttribLocation("In_Position"), 3, nameof(Vertex.Position));
                mesh.VertexAttributePointer((uint)canvasPipeline.GetAttribLocation("In_Normal"), 3, nameof(Vertex.Normal));
                mesh.VertexAttributePointer((uint)canvasPipeline.GetAttribLocation("In_Tangent"), 3, nameof(Vertex.Tangent));
                mesh.VertexAttributePointer((uint)canvasPipeline.GetAttribLocation("In_Bitangent"), 3, nameof(Vertex.Bitangent));
                mesh.VertexAttributePointer((uint)canvasPipeline.GetAttribLocation("In_Color"), 4, nameof(Vertex.Color));
                mesh.VertexAttributePointer((uint)canvasPipeline.GetAttribLocation("In_TexCoord"), 2, nameof(Vertex.TexCoord));

                mesh.Draw();

                canvasPipeline.Unbind();
            }

            context.BindFramebuffer(GLEnum.Framebuffer, 0);
        }

        Dispatcher.UIThread.Post(RequestNextFrameRendering, DispatcherPriority.Render);
    }

    /// <summary>
    /// 当渲染窗口大小发生变化时调用，触发 OnResize 事件
    /// </summary>
    /// <param name="e">包含新窗口大小的事件参数</param>
    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        if (context != null)
        {
            OnResize?.Invoke((int)e.NewSize.Width, (int)e.NewSize.Height);
        }
    }

    /// <summary>
    /// 获取当前的 OpenGL 上下文
    /// </summary>
    /// <returns>当前的 OpenGL 上下文</returns>
    /// <exception cref="InvalidOperationException">如果 OpenGL 上下文尚未初始化</exception>
    public GL GetContext()
    {
        if (context == null)
        {
            throw new InvalidOperationException("The OpenGL context has not been initialized yet.");
        }

        return context;
    }
}
