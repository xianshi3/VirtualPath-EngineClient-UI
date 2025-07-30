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
    /// ���������࣬������ʾӦ�ó������ʱ�Ĺ��ɻ��档
    /// ������ɺ���������� MainWindow��
    /// </summary>
    public partial class StartupWindow : Window
    {
        /// <summary>
        /// ���캯������ʼ����������¼�����ʼ������
        /// </summary>
        public StartupWindow()
        {
            InitializeComponent();

            // ���ڴ�ʱ�����¼���������������
            this.Opened += OnStartupOpened;

            // ���ڴ�С�仯ʱ�����¼������ڶ�̬��������
            this.SizeChanged += OnSizeChanged;

            // ���� Logo �����ֵĶ���Ч��
            AnimateLogoAndText();
        }

        /// <summary>
        /// ִ�� Logo ���ź����ֽ��ԡ����ƶ�����
        /// ʹ�� DispatcherTimer ʵ�ֶ���֡������
        /// ͨ���Զ��建������ʵ�ֶ���ƽ�����ɡ�
        /// </summary>
        private void AnimateLogoAndText()
        {
            var duration = TimeSpan.FromSeconds(1.5); // ������ʱ��1.5��
            var startScale = 0.9;  // Logo ��ʼ���ű���
            var endScale = 1.0;    // Logo �������ű�����������С��

            var startTime = DateTime.Now; // ��¼������ʼʱ��

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16) // Լ60֡ÿ��ĸ���Ƶ��
            };

            // �Զ��建������ (Cubic Ease In-Out)
            double Ease(double t) =>
                t < 0.5
                ? 4 * t * t * t
                : 1 - Math.Pow(-2 * t + 2, 3) / 2;

            // ��ʼ������͸���Ⱥ�λ�ƣ������Ӳ��ɼ�����΢���ƿ�ʼ
            WelcomeText.Opacity = 0;
            VersionText.Opacity = 0;

            WelcomeText.RenderTransform = new TranslateTransform(0, 20);
            VersionText.RenderTransform = new TranslateTransform(0, 20);

            // ��ʱ��ÿ֡���¶���״̬
            timer.Tick += (s, e) =>
            {
                var elapsed = DateTime.Now - startTime;
                // ���㶯������t����Χ0~1
                var t = Math.Min(1.0, elapsed.TotalMilliseconds / duration.TotalMilliseconds);

                // ���㻺������
                var easedT = Ease(t);

                // Logo ���Ŷ��������ݻ���ֵ��ֵ
                if (LogoImage.RenderTransform is not ScaleTransform scaleTransform)
                {
                    scaleTransform = new ScaleTransform(1, 1);
                    LogoImage.RenderTransform = scaleTransform;
                }
                scaleTransform.ScaleX = startScale + (endScale - startScale) * easedT;
                scaleTransform.ScaleY = startScale + (endScale - startScale) * easedT;

                // ���ֽ��Զ�����͸���ȴ�0��1
                WelcomeText.Opacity = easedT;
                VersionText.Opacity = easedT;

                // �������ƶ�����Y��λ�ô�20�ƶ���0
                if (WelcomeText.RenderTransform is TranslateTransform welcomeTT)
                    welcomeTT.Y = 20 * (1 - easedT);

                if (VersionText.RenderTransform is TranslateTransform versionTT)
                    versionTT.Y = 20 * (1 - easedT);

                // ��������ֹͣ��ʱ��
                if (t >= 1.0)
                    timer.Stop();
            };

            timer.Start();
        }

        /// <summary>
        /// ���ڴ��¼����������ȴ�һ��ʱ���������ڣ��رյ�ǰ�������ڡ�
        /// </summary>
        /// <param name="sender">�¼�Դ</param>
        /// <param name="e">�¼�����</param>
        private async void OnStartupOpened(object? sender, EventArgs e)
        {
            await Task.Delay(1500); // ģ�������ӳ�

            var mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        /// <summary>
        /// ���ڴ�С�仯�¼������������ݴ��ڳߴ綯̬���� Logo �����������С��
        /// </summary>
        /// <param name="sender">�¼�Դ</param>
        /// <param name="e">��С�仯�¼�����</param>
        private void OnSizeChanged(object? sender, SizeChangedEventArgs e)
        {
            var height = e.NewSize.Height;

            // ��̬���������С�����ֱ���Э��
            WelcomeText.FontSize = height * 0.05;
            VersionText.FontSize = height * 0.02;

            // ��̬���� Logo ��С�����ֱ���Э��
            LogoImage.Width = e.NewSize.Width * 0.375;
            LogoImage.Height = e.NewSize.Height * 0.333;
        }
    }
}
