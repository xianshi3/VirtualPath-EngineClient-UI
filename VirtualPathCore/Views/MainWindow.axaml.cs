using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using VirtualPathCore.ViewModels;

namespace VirtualPathCore.Views
{
    public partial class MainWindow : Window
    {
        private bool isSidebarOnLeft = true; // 侧边栏是否在左侧的状态标志

        /// <summary>
        /// 初始化主窗口，设置窗口的初始状态并加载数据上下文。
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized; // 设置窗口默认最大化
            DataContext = new MainWindowViewModel(); // 设置数据上下文为MainWindowViewModel
        }

        /// <summary>
        /// 切换侧边栏和AI对话框的可见性。
        /// </summary>
        /// <param name="sender">触发事件的对象。</param>
        /// <param name="e">事件参数。</param>
        private void ToggleSidebar(object sender, RoutedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                bool isVisible = SidebarBorder.IsVisible; // 获取当前侧边栏的可见性
                SidebarBorder.IsVisible = !isVisible; // 切换侧边栏的可见性
                AIChatBorder.IsVisible = !isVisible;   // 同时切换右侧 AI 对话框的可见性

                // 更新内容区域的列跨度
                if (SidebarBorder.IsVisible)
                {
                    Grid.SetColumnSpan(ContentBorder, 1);
                    Grid.SetColumn(ContentBorder, 1); // 确保内容区域在中间列
                }
                else
                {
                    Grid.SetColumnSpan(ContentBorder, 3);
                    Grid.SetColumn(ContentBorder, 0); // 让内容区域从左侧开始
                }
            });
        }

        /// <summary>
        /// 切换侧边栏和AI对话框的位置。
        /// </summary>
        /// <param name="sender">触发事件的对象。</param>
        /// <param name="e">事件参数。</param>
        private void ToggleDock(object sender, RoutedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (isSidebarOnLeft)
                {
                    SetDockPosition(2, 0); // 将左侧的侧边栏切换到右侧
                    SetDockPosition(0, 2); // 将右侧的AI对话框切换到左侧
                }
                else
                {
                    SetDockPosition(0, 2); // 将左侧的侧边栏切换到左侧
                    SetDockPosition(2, 0); // 将右侧的AI对话框切换到右侧
                }
                isSidebarOnLeft = !isSidebarOnLeft; // 更新状态标志
            });
        }

        /// <summary>
        /// 设置侧边栏和AI对话框的位置。
        /// </summary>
        /// <param name="sidebarColumn">侧边栏的目标列索引。</param>
        /// <param name="aiChatColumn">AI 对话框的目标列索引。</param>
        private void SetDockPosition(int sidebarColumn, int aiChatColumn)
        {
            Grid.SetColumn(SidebarBorder, sidebarColumn); // 设置侧边栏的列
            Grid.SetColumn(AIChatBorder, aiChatColumn);   // 设置AI对话框的列
        }

        /// <summary>
        /// 处理模型选择框的选择变化事件。
        /// </summary>
        /// <param name="sender">触发事件的对象。</param>
        /// <param name="e">事件参数。</param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox?.SelectedItem != null)
            {
                // 确保这部分在UI线程
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    // TODO: 处理选中的模型执行相应的操作
                });
            }
        }
    }
}
