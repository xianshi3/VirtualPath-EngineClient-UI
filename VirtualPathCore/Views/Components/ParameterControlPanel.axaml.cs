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

        // ����Ĭ��ͨ�� DataContext �� MainViewModel������������
        // �������Ҫ���Զ���ǿ���͵� ViewModel ����
    }
}
