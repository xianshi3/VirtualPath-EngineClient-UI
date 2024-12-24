using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;
using VirtualPathCore.Views;

namespace VirtualPathCore
{
    /// <summary>
    /// 启动窗口类，用于显示启动画面并加载主页面。
    /// </summary>
    public partial class StartupWindow : Window
    {
        /// <summary>
        /// 初始化启动窗口并最大化。
        /// </summary>
        public StartupWindow()
        {
            InitializeComponent();
            LoadMainPageAsync();
            this.WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// 异步加载主页面并延迟启动处理。
        /// </summary>
        private async void LoadMainPageAsync()
        {
            await Task.Delay(500);
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// 处理窗口大小变化事件，调整Logo和文本的大小与位置。
        /// </summary>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // 调整Logo图片
            LogoImage.Width = e.NewSize.Width * 0.375;
            LogoImage.Height = e.NewSize.Height * 0.333;
            LogoImage.Margin = new Thickness(0, e.NewSize.Height * 0.185, 0, 0);

            // 调整欢迎文本
            WelcomeText.Margin = new Thickness(0, e.NewSize.Height * 0.033, 0, 0);
            WelcomeText.FontSize = e.NewSize.Height * 0.04;

            // 调整版本信息
            VersionText.Margin = new Thickness(0, e.NewSize.Height * 0.033, 0, e.NewSize.Height * 0.033);
            VersionText.FontSize = e.NewSize.Height * 0.023;
        }
    }
}
