using System;
using Silk.NET.Core.Native;

namespace VirtualPathCore.Graphics;

/// <summary>
/// 表示一个接受时间增量（以秒为单位）作为参数的无返回值委托
/// </summary>
/// <param name="deltaSeconds">时间增量，单位为秒</param>
public delegate void DeltaAction(double deltaSeconds);

/// <summary>
/// 表示一个接受宽度和高度作为参数的无返回值委托
/// </summary>
/// <param name="width">新的宽度值</param>
/// <param name="height">新的高度值</param>
public delegate void SizeAction(int width, int height);

/// <summary>
/// 定义一个图形宿主的接口，用于管理图形上下文的生命周期和事件
/// </summary>
/// <typeparam name="TContext">图形上下文的类型，必须继承自 <see cref="NativeAPI"/></typeparam>
public interface IGraphicsHost<TContext> where TContext : NativeAPI
{
    /// <summary>
    /// 当图形宿主加载时触发的事件
    /// </summary>
    event Action? OnLoad;

    /// <summary>
    /// 当图形宿主卸载时触发的事件
    /// </summary>
    event Action? OnUnload;

    /// <summary>
    /// 当图形宿主更新时触发的事件，接受时间增量作为参数
    /// </summary>
    event DeltaAction? OnUpdate;

    /// <summary>
    /// 当图形宿主渲染时触发的事件，接受时间增量作为参数
    /// </summary>
    event DeltaAction? OnRender;

    /// <summary>
    /// 当图形宿主大小改变时触发的事件，接受新的宽度和高度作为参数
    /// </summary>
    event SizeAction? OnResize;

    /// <summary>
    /// 获取当前图形上下文
    /// </summary>
    /// <returns>当前的图形上下文实例</returns>
    TContext GetContext();
}
