using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;
using VirtualPathCore.Views;

namespace VirtualPathCore
{
    /// <summary>
    /// ���������࣬������ʾӦ���������棬���ӳٽ�����ҳ�档
    /// </summary>
    public partial class StartupWindow : Window
    {
        /// <summary>
        /// ��ʼ�����������������ע�ᴰ�ڴ��¼���
        /// </summary>
        public StartupWindow()
        {
            InitializeComponent();

            // ע�ᴰ�ڴ��¼��������ڽ�����Ⱦ��ɺ�ִ���߼�
            this.Opened += OnStartupOpened;
        }

        /// <summary>
        /// ���������ڴ򿪺�ִ���첽�����������߼���
        /// </summary>
        private async void OnStartupOpened(object? sender, System.EventArgs e)
        {
            // ���ô���Ϊ��󻯣������ڴ��ڴ򿪺����ò�����Ч�Ҳ�Ӱ����Ⱦ��
            this.WindowState = WindowState.Maximized;

            // ģ������ӳ�ʱ�䣬ȷ���û��ܿ����������棨���Զ����ӳ�ʱ�䣩
            await Task.Delay(1500);

            // ʵ��������ʾ������
            var mainWindow = new MainWindow();
            mainWindow.Show();

            // �ر���������
            this.Close();
        }

        /// <summary>
        /// �����ڳߴ緢���仯ʱ���Զ����� Logo ���ı����ּ���С��
        /// </summary>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // ���ݴ��ڳߴ綯̬���� Logo ͼƬ
            LogoImage.Width = e.NewSize.Width * 0.375;
            LogoImage.Height = e.NewSize.Height * 0.333;
            LogoImage.Margin = new Thickness(0, e.NewSize.Height * 0.185, 0, 0);

            // ���û�ӭ�ı���С�ͱ߾�
            WelcomeText.Margin = new Thickness(0, e.NewSize.Height * 0.033, 0, 0);
            WelcomeText.FontSize = e.NewSize.Height * 0.04;

            // ���ð汾���ı���С�͵ײ��߾�
            VersionText.Margin = new Thickness(0, e.NewSize.Height * 0.033, 0, e.NewSize.Height * 0.033);
            VersionText.FontSize = e.NewSize.Height * 0.023;
        }
    }
}
