using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace VirtualPathCore.Views
{
    /// <summary>
    /// 主窗口类，负责管理主界面布局和交互逻辑。
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 标识侧边栏是否显示在左侧，true 表示在左侧，false 表示在右侧。
        /// </summary>
        private bool isSidebarOnLeft = true;

        /// <summary>
        /// 构造函数，初始化组件并设置窗口状态与数据上下文。
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainWindowViewModel();
            WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// 切换侧边栏和右侧 AI 对话框的显示与隐藏状态。
        /// </summary>
        /// <param name="sender">触发事件的控件。</param>
        /// <param name="e">事件参数。</param>
        private void ToggleSidebar(object sender, RoutedEventArgs e)
        {
            // 使用 Dispatcher 确保 UI 线程执行
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                // 获取当前侧边栏是否可见
                bool isVisible = SidebarBorder.IsVisible;

                // 切换侧边栏和 AI 对话框的可见性
                SidebarBorder.IsVisible = !isVisible;
                AIChatBorder.IsVisible = !isVisible;

                // 调整内容区的列占用，根据侧边栏是否显示动态调整布局
                if (SidebarBorder.IsVisible)
                {
                    Grid.SetColumnSpan(ContentBorder, 1);
                    Grid.SetColumn(ContentBorder, 1); // 内容区放在中间列
                }
                else
                {
                    Grid.SetColumnSpan(ContentBorder, 3);
                    Grid.SetColumn(ContentBorder, 0); // 内容区占满整行，从左开始
                }
            });
        }

        /// <summary>
        /// 切换侧边栏和 AI 对话框的位置，左右互换。
        /// </summary>
        /// <param name="sender">触发事件的控件。</param>
        /// <param name="e">事件参数。</param>
        private void ToggleDock(object sender, RoutedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (isSidebarOnLeft)
                {
                    // 侧边栏移到右侧，AI对话框移到左侧
                    SetDockPosition(sidebarColumn: 2, aiChatColumn: 0);
                }
                else
                {
                    // 侧边栏移回左侧，AI对话框移回右侧
                    SetDockPosition(sidebarColumn: 0, aiChatColumn: 2);
                }
                // 更新状态标志
                isSidebarOnLeft = !isSidebarOnLeft;
            });
        }

        /// <summary>
        /// 设置侧边栏和 AI 对话框在网格中的列位置。
        /// </summary>
        /// <param name="sidebarColumn">侧边栏所在列索引。</param>
        /// <param name="aiChatColumn">AI 对话框所在列索引。</param>
        private void SetDockPosition(int sidebarColumn, int aiChatColumn)
        {
            Grid.SetColumn(SidebarBorder, sidebarColumn);
            Grid.SetColumn(AIChatBorder, aiChatColumn);
        }
    }
}
