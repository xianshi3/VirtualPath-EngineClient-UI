using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace VirtualPathCore.Views
{
    public partial class MainWindow : Window
    {
        private bool isSidebarOnLeft = true;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainWindowViewModel();
            WindowState = WindowState.Maximized;
        }

        private void ToggleSidebar(object sender, RoutedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                bool isVisible = SidebarBorder.IsVisible;
                SidebarBorder.IsVisible = !isVisible;
                AIChatBorder.IsVisible = !isVisible;

                if (SidebarBorder.IsVisible)
                {
                    Grid.SetColumnSpan(ContentBorder, 1);
                    Grid.SetColumn(ContentBorder, 1);
                }
                else
                {
                    Grid.SetColumnSpan(ContentBorder, 3);
                    Grid.SetColumn(ContentBorder, 0);
                }
            });
        }

        private void ToggleDock(object sender, RoutedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (isSidebarOnLeft)
                {
                    SetDockPosition(2, 0);
                }
                else
                {
                    SetDockPosition(0, 2);
                }
                isSidebarOnLeft = !isSidebarOnLeft;
            });
        }

        private void SetDockPosition(int sidebarColumn, int aiChatColumn)
        {
            Grid.SetColumn(SidebarBorder, sidebarColumn);
            Grid.SetColumn(AIChatBorder, aiChatColumn);
        }
    }
}
