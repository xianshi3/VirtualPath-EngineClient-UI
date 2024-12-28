using System;

namespace VirtualPathCore.Graphics;

/// <summary>
/// 提供一种机制来释放非托管资源，并确保资源在不再需要时被正确释放
/// 该类实现了 <see cref="IDisposable"/> 接口，并提供了一个抽象方法 <see cref="Destroy(bool)"/> 供派生类实现
/// </summary>
public abstract class Disposable : IDisposable
{
    private bool disposedValue;

    /// <summary>
    /// 析构函数，用于在对象被垃圾回收时释放非托管资源
    /// </summary>
    ~Disposable()
    {
        Dispose(disposing: false);
    }

    /// <summary>
    /// 派生类应重写此方法以释放非托管资源
    /// </summary>
    /// <param name="disposing">指示是否由 <see cref="Dispose()"/> 方法调用</param>
    protected abstract void Destroy(bool disposing = false);

    /// <summary>
    /// 释放托管和非托管资源
    /// </summary>
    /// <param name="disposing">指示是否由 <see cref="Dispose()"/> 方法调用</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            Destroy(disposing);

            disposedValue = true;
        }
    }

    /// <summary>
    /// 释放由 <see cref="Disposable"/> 类使用的所有资源
    /// 此方法应被显式调用，以确保资源在不再需要时被正确释放
    /// </summary>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
