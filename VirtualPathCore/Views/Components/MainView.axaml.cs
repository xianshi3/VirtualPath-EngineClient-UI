using Avalonia.Controls;
using VirtualPathCore.Contracts.Services;
using VirtualPathCore.Services;
using VirtualPathCore.ViewModels;

namespace VirtualPathCore.Views
{
    /// <summary>
    /// 主视图类，负责初始化和管理两个绘图服务及其渲染器事件
    /// </summary>
    public partial class MainView : UserControl
    {
        // 定义两个绘图服务实例
        private readonly IDrawingService _drawingService1;
        private readonly IDrawingService _drawingService2;
        private readonly MainViewModel _viewModel;

        /// <summary>
        /// 初始化 MainView 类的新实例
        /// </summary>
        public MainView()
        {
            // 初始化绘图服务
            _drawingService1 = new SimpleDrawingService();
            _drawingService2 = new ExternalDrawingService();
            _viewModel = new MainViewModel();

            InitializeComponent();

            // 设置数据上下文
            DataContext = _viewModel;

            // 注册渲染器的事件处理程序
            RegisterRendererEvents(glRenderer1, _drawingService1);
            RegisterRendererEvents(glRenderer2, _drawingService2);
        }

        /// <summary>
        /// 注册渲染器的事件处理程序
        /// </summary>
        /// <param name="renderer">渲染器实例</param>
        /// <param name="drawingService">绘图服务实例</param>
        private void RegisterRendererEvents(VirtualPathCore.Graphics.OpenGL.Renderer renderer, IDrawingService drawingService)
        {
            renderer.OnLoad += () => { drawingService.Load([renderer, _viewModel]); };
            renderer.OnUpdate += drawingService.Update;
            renderer.OnRender += drawingService.Render;
        }

    }
}