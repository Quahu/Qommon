using System;

namespace Qommon.Pooling;

/// <summary>
///     Represents the default implementation of <see cref="ObjectPoolProvider"/>
///     which creates <see cref="DefaultObjectPool{T}"/> instances.
///     Allows for setting <see cref="Capacity"/> which controls the amount of objects
///     retained in the created object pools.
/// </summary>
/// <remarks>
///     For <see cref="IDisposable"/> object types the pool returns a specialized
///     <see cref="DisposableObjectPool{T}"/> to handle object disposal.
///     You can use <see cref="Qommon.Disposal.RuntimeDisposal"/> to
///     dispose the created object pool, if it is disposable.
///     <example>
///         <code language="csharp">
///         var pool = ObjectPool.Create&lt;DisposableType&gt;();
///         ...
///         RuntimeDisposal.Dispose(pool);
///         </code>
///     </example>
/// </remarks>
public class DefaultObjectPoolProvider : ObjectPoolProvider
{
    /// <summary>
    ///     Gets or sets the capacity of the created object pools,
    ///     i.e. the amount of objects to be retained.
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    ///     Instantiates a new object pool provider.
    /// </summary>
    public DefaultObjectPoolProvider()
    {
        Capacity = Environment.ProcessorCount * 2;
    }

    /// <inheritdoc/>
    public override ObjectPool<T> Create<T>(PooledObjectPolicy<T> policy)
        where T : class
    {
        Guard.IsNotNull(policy);

        if (typeof(IDisposable).IsAssignableFrom(typeof(T)))
        {
            return new DisposableObjectPool<T>(policy, Capacity);
        }

        return new DefaultObjectPool<T>(policy, Capacity);
    }
}
