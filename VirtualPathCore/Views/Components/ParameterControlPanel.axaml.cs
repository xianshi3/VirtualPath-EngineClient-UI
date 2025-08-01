using Avalonia.Controls;
using VirtualPathCore.Contracts.Services;
using VirtualPathCore.Services;
using VirtualPathCore.ViewModels;

namespace VirtualPathCore.Views
{
    public partial class ParameterControlPanel : UserControl
    {
        public ParameterControlPanel()
        {
            InitializeComponent();
        }

        // 这里默认通过 DataContext 绑定 MainViewModel，无需额外代码
        // 如果你需要可以定义强类型的 ViewModel 属性
    }
}
