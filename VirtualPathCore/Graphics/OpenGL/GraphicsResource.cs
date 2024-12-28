using Silk.NET.OpenGLES;

namespace VirtualPathCore.Graphics.OpenGL;

/// <summary>
/// 表示一个抽象的图形资源类，用于管理与 OpenGL 相关的资源
/// 该类继承自 <see cref="Disposable"/>，确保资源在不再需要时被正确释放
/// </summary>
/// <param name="graphicsHost">图形宿主实例，用于获取 OpenGL 上下文</param>
public abstract class GraphicsResource(IGraphicsHost<GL> graphicsHost) : Disposable
{
    /// <summary>
    /// 获取图形宿主实例
    /// </summary>
    protected IGraphicsHost<GL> GraphicsHost { get; } = graphicsHost;

    /// <summary>
    /// 获取当前 OpenGL 上下文
    /// </summary>
    protected GL GL => GraphicsHost.GetContext();

    /// <summary>
    /// 获取或设置图形资源的句柄
    /// </summary>
    public uint Handle { get; protected set; }
}
