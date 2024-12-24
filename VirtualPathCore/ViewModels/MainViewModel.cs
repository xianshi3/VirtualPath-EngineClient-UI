using CommunityToolkit.Mvvm.ComponentModel;

namespace VirtualPathCore.ViewModels;

/// <summary>
/// 主视图模型类，包含用于调整模型的属性
/// </summary>
public partial class MainViewModel : ViewModelBase
{
    /// <summary>
    /// 模型的旋转角度
    /// </summary>
    [ObservableProperty]
    private float rotationAngle;

    /// <summary>
    /// 模型的缩放比例
    /// </summary>
    [ObservableProperty]
    private float scale = 1.0f;

    /// <summary>
    /// 模型在 X 轴上的位置
    /// </summary>
    [ObservableProperty]
    private float positionX;

    /// <summary>
    /// 模型在 Y 轴上的位置
    /// </summary>
    [ObservableProperty]
    private float positionY;

    /// <summary>
    /// 模型在 Z 轴上的位置
    /// </summary>
    [ObservableProperty]
    private float positionZ;
}