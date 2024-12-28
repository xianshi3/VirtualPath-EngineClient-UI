namespace VirtualPathCore.Contracts.Services;

/// <summary>
/// 定义绘图服务的接口，用于加载资源、更新状态和渲染内容
/// </summary>
public interface IDrawingService
{
    /// <summary>
    /// 加载绘图服务所需的资源
    /// </summary>
    /// <param name="args">加载资源时所需的参数数组</param>
    void Load(object[] args);

    /// <summary>
    /// 更新绘图服务的状态
    /// </summary>
    /// <param name="deltaSeconds">自上次更新以来的时间间隔（以秒为单位）</param>
    void Update(double deltaSeconds);

    /// <summary>
    /// 渲染绘图服务的内容
    /// </summary>
    /// <param name="deltaSeconds">自上次渲染以来的时间间隔（以秒为单位）</param>
    void Render(double deltaSeconds);
}
