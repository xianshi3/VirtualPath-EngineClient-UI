using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace VirtualPathCore.Views
{
    /// <summary>
    /// �������࣬������������沼�ֺͽ����߼���
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// ��ʶ������Ƿ���ʾ����࣬true ��ʾ����࣬false ��ʾ���Ҳࡣ
        /// </summary>
        private bool isSidebarOnLeft = true;

        /// <summary>
        /// ���캯������ʼ����������ô���״̬�����������ġ�
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainWindowViewModel();
            WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// �л���������Ҳ� AI �Ի������ʾ������״̬��
        /// </summary>
        /// <param name="sender">�����¼��Ŀؼ���</param>
        /// <param name="e">�¼�������</param>
        private void ToggleSidebar(object sender, RoutedEventArgs e)
        {
            // ʹ�� Dispatcher ȷ�� UI �߳�ִ��
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                // ��ȡ��ǰ������Ƿ�ɼ�
                bool isVisible = SidebarBorder.IsVisible;

                // �л�������� AI �Ի���Ŀɼ���
                SidebarBorder.IsVisible = !isVisible;
                AIChatBorder.IsVisible = !isVisible;

                // ��������������ռ�ã����ݲ�����Ƿ���ʾ��̬��������
                if (SidebarBorder.IsVisible)
                {
                    Grid.SetColumnSpan(ContentBorder, 1);
                    Grid.SetColumn(ContentBorder, 1); // �����������м���
                }
                else
                {
                    Grid.SetColumnSpan(ContentBorder, 3);
                    Grid.SetColumn(ContentBorder, 0); // ������ռ�����У�����ʼ
                }
            });
        }

        /// <summary>
        /// �л�������� AI �Ի����λ�ã����һ�����
        /// </summary>
        /// <param name="sender">�����¼��Ŀؼ���</param>
        /// <param name="e">�¼�������</param>
        private void ToggleDock(object sender, RoutedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (isSidebarOnLeft)
                {
                    // ������Ƶ��Ҳ࣬AI�Ի����Ƶ����
                    SetDockPosition(sidebarColumn: 2, aiChatColumn: 0);
                }
                else
                {
                    // ������ƻ���࣬AI�Ի����ƻ��Ҳ�
                    SetDockPosition(sidebarColumn: 0, aiChatColumn: 2);
                }
                // ����״̬��־
                isSidebarOnLeft = !isSidebarOnLeft;
            });
        }

        /// <summary>
        /// ���ò������ AI �Ի����������е���λ�á�
        /// </summary>
        /// <param name="sidebarColumn">�����������������</param>
        /// <param name="aiChatColumn">AI �Ի���������������</param>
        private void SetDockPosition(int sidebarColumn, int aiChatColumn)
        {
            Grid.SetColumn(SidebarBorder, sidebarColumn);
            Grid.SetColumn(AIChatBorder, aiChatColumn);
        }
    }
}
