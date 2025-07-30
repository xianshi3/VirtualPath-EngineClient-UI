using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Threading.Tasks;
using VirtualPathCore.Views;

namespace VirtualPathCore
{
    /// <summary>
    /// 启动窗口类，用于显示应用程序加载时的过渡画面。
    /// 启动完成后进入主界面 MainWindow。
    /// </summary>
    public partial class StartupWindow : Window
    {
        /// <summary>
        /// 构造函数，初始化组件，绑定事件，开始动画。
        /// </summary>
        public StartupWindow()
        {
            InitializeComponent();

            // 窗口打开时触发事件，启动后续流程
            this.Opened += OnStartupOpened;

            // 窗口大小变化时触发事件，用于动态调整布局
            this.SizeChanged += OnSizeChanged;

            // 启动 Logo 和文字的动画效果
            AnimateLogoAndText();
        }

        /// <summary>
        /// 执行 Logo 缩放和文字渐显、上移动画。
        /// 使用 DispatcherTimer 实现动画帧驱动，
        /// 通过自定义缓动函数实现动画平滑过渡。
        /// </summary>
        private void AnimateLogoAndText()
        {
            var duration = TimeSpan.FromSeconds(1.5); // 动画总时长1.5秒
            var startScale = 0.9;  // Logo 初始缩放比例
            var endScale = 1.0;    // Logo 结束缩放比例（正常大小）

            var startTime = DateTime.Now; // 记录动画开始时间

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16) // 约60帧每秒的更新频率
            };

            // 自定义缓动函数 (Cubic Ease In-Out)
            double Ease(double t) =>
                t < 0.5
                ? 4 * t * t * t
                : 1 - Math.Pow(-2 * t + 2, 3) / 2;

            // 初始化文字透明度和位移，动画从不可见且稍微下移开始
            WelcomeText.Opacity = 0;
            VersionText.Opacity = 0;

            WelcomeText.RenderTransform = new TranslateTransform(0, 20);
            VersionText.RenderTransform = new TranslateTransform(0, 20);

            // 定时器每帧更新动画状态
            timer.Tick += (s, e) =>
            {
                var elapsed = DateTime.Now - startTime;
                // 计算动画进度t，范围0~1
                var t = Math.Min(1.0, elapsed.TotalMilliseconds / duration.TotalMilliseconds);

                // 计算缓动进度
                var easedT = Ease(t);

                // Logo 缩放动画，根据缓动值插值
                if (LogoImage.RenderTransform is not ScaleTransform scaleTransform)
                {
                    scaleTransform = new ScaleTransform(1, 1);
                    LogoImage.RenderTransform = scaleTransform;
                }
                scaleTransform.ScaleX = startScale + (endScale - startScale) * easedT;
                scaleTransform.ScaleY = startScale + (endScale - startScale) * easedT;

                // 文字渐显动画，透明度从0到1
                WelcomeText.Opacity = easedT;
                VersionText.Opacity = easedT;

                // 文字上移动画，Y轴位置从20移动到0
                if (WelcomeText.RenderTransform is TranslateTransform welcomeTT)
                    welcomeTT.Y = 20 * (1 - easedT);

                if (VersionText.RenderTransform is TranslateTransform versionTT)
                    versionTT.Y = 20 * (1 - easedT);

                // 动画结束停止定时器
                if (t >= 1.0)
                    timer.Stop();
            };

            timer.Start();
        }

        /// <summary>
        /// 窗口打开事件处理器，等待一段时间后打开主窗口，关闭当前启动窗口。
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private async void OnStartupOpened(object? sender, EventArgs e)
        {
            await Task.Delay(1500); // 模拟启动延迟

            var mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        /// <summary>
        /// 窗口大小变化事件处理器，根据窗口尺寸动态调整 Logo 和文字字体大小。
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">大小变化事件参数</param>
        private void OnSizeChanged(object? sender, SizeChangedEventArgs e)
        {
            var height = e.NewSize.Height;

            // 动态调整字体大小，保持比例协调
            WelcomeText.FontSize = height * 0.05;
            VersionText.FontSize = height * 0.02;

            // 动态调整 Logo 大小，保持比例协调
            LogoImage.Width = e.NewSize.Width * 0.375;
            LogoImage.Height = e.NewSize.Height * 0.333;
        }
    }
}
