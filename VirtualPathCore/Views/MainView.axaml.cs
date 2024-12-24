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

            // 注册第一个渲染器的事件处理程序
            glRenderer1.OnLoad += () => { _drawingService1.Load(new object[] { glRenderer1, _viewModel }); };
            glRenderer1.OnUpdate += _drawingService1.Update;
            glRenderer1.OnRender += _drawingService1.Render;

            // 注册第二个渲染器的事件处理程序
            glRenderer2.OnLoad += () => { _drawingService2.Load(new object[] { glRenderer2, _viewModel }); };
            glRenderer2.OnUpdate += _drawingService2.Update;
            glRenderer2.OnRender += _drawingService2.Render;
        }
    }
}