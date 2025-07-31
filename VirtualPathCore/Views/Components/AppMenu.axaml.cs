using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace VirtualPathCore.Views.Components
{
    public partial class AppMenu : UserControl
    {
        public event EventHandler<RoutedEventArgs>? ToggleSidebarClicked;
        public event EventHandler<RoutedEventArgs>? ToggleDockClicked;

        public AppMenu()
        {
            InitializeComponent();
        }

        private void ToggleSidebar(object? sender, RoutedEventArgs e)
        {
            ToggleSidebarClicked?.Invoke(this, e);
        }

        private void ToggleDock(object? sender, RoutedEventArgs e)
        {
            ToggleDockClicked?.Invoke(this, e);
        }
    }
}
