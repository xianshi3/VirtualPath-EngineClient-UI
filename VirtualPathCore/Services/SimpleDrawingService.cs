using System;
using System.IO;
using VirtualPathCore.Contracts.Services;
using VirtualPathCore.Graphics;
using VirtualPathCore.Graphics.OpenGL;
using VirtualPathCore.Helpers;
using Silk.NET.Maths;
using Silk.NET.OpenGLES;
using Shader = VirtualPathCore.Graphics.OpenGL.Shader;
using VirtualPathCore.ViewModels;

namespace VirtualPathCore.Services
{
    /// <summary>
    /// 提供简单的绘图服务，实现 IDrawingService 接口
    /// 该服务负责加载着色器、创建渲染管道、更新模型变换以及绘制立方体
    /// </summary>
    public class SimpleDrawingService : IDrawingService
    {
        #region Uniforms
        /// <summary>
        /// 统一变换结构体，包含模型、视图、投影矩阵等
        /// </summary>
        private struct UniTransforms
        {
            public Matrix4X4<float> Model;
            public Matrix4X4<float> View;
            public Matrix4X4<float> Projection;
            public Matrix4X4<float> ObjectToWorld;
            public Matrix4X4<float> ObjectToClip;
            public Matrix4X4<float> WorldToObject;
        }

        /// <summary>
        /// 统一参数结构体，包含颜色等参数
        /// </summary>
        private struct UniParameters
        {
            public Vector4D<float> Color;
        }
        #endregion

        private Renderer renderer = null!;
        private Camera camera = null!;
        private MainViewModel viewModel = null!;

        #region Pipelines
        private RenderPipeline simplePipeline = null!;
        private RenderPipeline solidColorPipeline = null!;
        #endregion

        #region Meshes
        private Mesh[] cubeMeshes = null!;
        #endregion

        private Matrix4X4<float> model = Matrix4X4<float>.Identity;
        private Vector4D<float> color = new(1.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>
        /// 加载绘图服务所需的资源，例如渲染器、相机及着色器
        /// </summary>
        /// <param name="args">绘图服务所需的参数</param>
        public void Load(object[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Expected at least 2 arguments: Renderer and MainViewModel");
            }

            renderer = (Renderer)args[0];
            viewModel = (MainViewModel)args[1];
            camera = new Camera()
            {
                Position = new Vector3D<float>(0.0f, 2.0f, 8.0f),
                Fov = 45.0f
            };

            using Shader vs1 = new(renderer, ShaderType.VertexShader, File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Resources", "Shaders", "Simple.vert")));
            using Shader fs1 = new(renderer, ShaderType.FragmentShader, File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Resources", "Shaders", "Simple.frag")));
            simplePipeline = new RenderPipeline(renderer, vs1, fs1);

            using Shader vs2 = new(renderer, ShaderType.VertexShader, File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Resources", "Shaders", "SolidColor.vert")));
            using Shader fs2 = new(renderer, ShaderType.FragmentShader, File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Resources", "Shaders", "SolidColor.frag")));

            solidColorPipeline = new RenderPipeline(renderer, vs2, fs2);

            MeshFactory.GetCube(out Vertex[] vertices, out uint[] indices);
            cubeMeshes = new[] { new Mesh(renderer, vertices, indices) };
        }

        /// <summary>
        /// 更新绘图服务状态，包括模型变换和颜色渐变
        /// </summary>
        /// <param name="deltaSeconds">自上次更新以来经过的时间，以秒为单位</param>
        public void Update(double deltaSeconds)
        {
            model = Matrix4X4.CreateFromAxisAngle(new Vector3D<float>(0.0f, 1.0f, 0.0f), viewModel.RotationAngle) *
                    Matrix4X4.CreateScale(viewModel.Scale) *
                    Matrix4X4.CreateTranslation(new Vector3D<float>(viewModel.PositionX, viewModel.PositionY, viewModel.PositionZ));

            color = Vector4D.Lerp(Vector4D<float>.One, new Vector4D<float>(1.0f, 0.0f, 0.0f, 1.0f), (float)Math.Sin(deltaSeconds));

            camera.Width = (int)renderer.Bounds.Width;
            camera.Height = (int)renderer.Bounds.Height;
        }

        /// <summary>
        /// 渲染立方体和其他对象到屏幕
        /// </summary>
        /// <param name="deltaSeconds">自上次渲染以来经过的时间，以秒为单位</param>
        public void Render(double deltaSeconds)
        {
            GL gl = renderer.GetContext();

            gl.ClearColor(0.2f, 0.2f, 0.2f, 1.0f);
            gl.Clear((uint)GLEnum.ColorBufferBit | (uint)GLEnum.DepthBufferBit | (uint)GLEnum.StencilBufferBit);

            // Cube
            {
                Matrix4X4<float> m = model;

                foreach (Mesh mesh in cubeMeshes)
                {
                    solidColorPipeline.Bind();

                    solidColorPipeline.SetUniform(string.Empty, new UniTransforms()
                    {
                        Model = m,
                        View = camera.View,
                        Projection = camera.Projection,
                        ObjectToWorld = m,
                        ObjectToClip = m * camera.View * camera.Projection,
                        WorldToObject = m.Invert()
                    });

                    solidColorPipeline.SetUniform(string.Empty, new UniParameters()
                    {
                        Color = color
                    });

                    mesh.VertexAttributePointer((uint)solidColorPipeline.GetAttribLocation("In_Position"), 3, nameof(Vertex.Position));
                    mesh.VertexAttributePointer((uint)solidColorPipeline.GetAttribLocation("In_Normal"), 3, nameof(Vertex.Normal));
                    mesh.VertexAttributePointer((uint)solidColorPipeline.GetAttribLocation("In_Tangent"), 3, nameof(Vertex.Tangent));
                    mesh.VertexAttributePointer((uint)solidColorPipeline.GetAttribLocation("In_Bitangent"), 3, nameof(Vertex.Bitangent));
                    mesh.VertexAttributePointer((uint)solidColorPipeline.GetAttribLocation("In_Color"), 4, nameof(Vertex.Color));
                    mesh.VertexAttributePointer((uint)solidColorPipeline.GetAttribLocation("In_TexCoord"), 2, nameof(Vertex.TexCoord));

                    mesh.Draw();

                    solidColorPipeline.Unbind();
                }
            }
        }
    }
}