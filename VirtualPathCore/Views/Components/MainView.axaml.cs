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
        private readonly IDrawingService _drawingService1;
        private readonly IDrawingService _drawingService2;
        private readonly MainViewModel _viewModel;

        public MainView()
        {
            _drawingService1 = new SimpleDrawingService();
            _drawingService2 = new ExternalDrawingService();
            _viewModel = new MainViewModel();

            InitializeComponent();

            DataContext = _viewModel;

            RegisterRendererEvents(glRenderer1, _drawingService1);
            RegisterRendererEvents(glRenderer2, _drawingService2);
        }

        private void RegisterRendererEvents(VirtualPathCore.Graphics.OpenGL.Renderer renderer, IDrawingService drawingService)
        {
            renderer.OnLoad += () => { drawingService.Load(new object[] { renderer, _viewModel }); };
            renderer.OnUpdate += drawingService.Update;
            renderer.OnRender += drawingService.Render;
        }
    }
}
