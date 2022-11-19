using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Qommon.Pooling;

/// <summary>
///     Represents an object pool which disposes the pooled objects
///     when the objects are discarded or if the pool is disposed or garbage collected.
/// </summary>
/// <typeparam name="T"> The type of the objects. </typeparam>
public class DisposableObjectPool<T> : DefaultObjectPool<T>, IDisposable
    where T : class
{
    private bool _isDisposed;

    /// <inheritdoc/>
    public DisposableObjectPool(PooledObjectPolicy<T> policy, int capacity)
        : base(policy, capacity)
    { }

    ~DisposableObjectPool()
    {
        Dispose(false);
    }

    /// <inheritdoc/>
    public override T Rent()
    {
        if (_isDisposed)
        {
            Throw.ObjectDisposedException(GetType().ToString());
        }

        return base.Rent();
    }

    /// <inheritdoc/>
    public override bool Return(T obj)
    {
        if (_isDisposed || !base.Return(obj))
        {
            DisposeObject(obj);
            return false;
        }

        return true;
    }

    /// <summary>
    ///     Disposes this object pool,
    ///     disposing any disposable items that are retained in the pool.
    /// </summary>
    /// <param name="disposing"> <see langword="true"/> if called from <see cref="Dispose()"/>, <see langword="false"/> if called from the destructor. </param>
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed)
            return;

        _isDisposed = true;

        var fastObject = Interlocked.Exchange(ref _fastObject, null);
        DisposeObject(fastObject);

        var slowObjects = _slowObjects;
        for (var i = 0; i < slowObjects.Length; i++)
        {
            var slowObject = Interlocked.Exchange(ref slowObjects[i].Value, null);
            DisposeObject(slowObject);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void DisposeObject(T? obj)
    {
        if (obj is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }

    /// <summary>
    ///     Disposes this object pool,
    ///     disposing any disposable items that are retained in the pool.
    /// </summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Dispose(true);
    }
}
