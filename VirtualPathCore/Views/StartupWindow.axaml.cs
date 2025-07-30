using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;
using VirtualPathCore.Views;

namespace VirtualPathCore
{
    /// <summary>
    /// 启动窗口类，用于显示应用启动画面，并延迟进入主页面。
    /// </summary>
    public partial class StartupWindow : Window
    {
        /// <summary>
        /// 初始化启动窗口组件，并注册窗口打开事件。
        /// </summary>
        public StartupWindow()
        {
            InitializeComponent();

            // 注册窗口打开事件，用于在界面渲染完成后执行逻辑
            this.Opened += OnStartupOpened;
        }

        /// <summary>
        /// 当启动窗口打开后执行异步加载主窗口逻辑。
        /// </summary>
        private async void OnStartupOpened(object? sender, System.EventArgs e)
        {
            // 设置窗口为最大化（必须在窗口打开后设置才能生效且不影响渲染）
            this.WindowState = WindowState.Maximized;

            // 模拟加载延迟时间，确保用户能看到启动界面（可自定义延迟时间）
            await Task.Delay(1500);

            // 实例化并显示主窗口
            var mainWindow = new MainWindow();
            mainWindow.Show();

            // 关闭启动窗口
            this.Close();
        }

        /// <summary>
        /// 当窗口尺寸发生变化时，自动调整 Logo 和文本布局及大小。
        /// </summary>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // 根据窗口尺寸动态缩放 Logo 图片
            LogoImage.Width = e.NewSize.Width * 0.375;
            LogoImage.Height = e.NewSize.Height * 0.333;
            LogoImage.Margin = new Thickness(0, e.NewSize.Height * 0.185, 0, 0);

            // 设置欢迎文本大小和边距
            WelcomeText.Margin = new Thickness(0, e.NewSize.Height * 0.033, 0, 0);
            WelcomeText.FontSize = e.NewSize.Height * 0.04;

            // 设置版本号文本大小和底部边距
            VersionText.Margin = new Thickness(0, e.NewSize.Height * 0.033, 0, e.NewSize.Height * 0.033);
            VersionText.FontSize = e.NewSize.Height * 0.023;
        }
    }
}
