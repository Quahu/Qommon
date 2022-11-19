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
///     <para/>
///     <see cref="CreateDisposablePools"/> can be set to <see langword="false"/> to prevent possibly unexpected disposals
///     of the pooled objects, however you should then ensure you dispose of those objects yourself.
/// </remarks>
public class DefaultObjectPoolProvider : ObjectPoolProvider
{
    /// <summary>
    ///     Gets or sets the capacity of the created object pools,
    ///     i.e. the amount of objects to be retained.
    /// </summary>
    /// <remarks>
    ///     Defaults to twice the amount of logical processors
    ///     the host machine is using.
    /// </remarks>
    public int Capacity { get; set; } = Environment.ProcessorCount * 2;

    /// <summary>
    ///     Gets or sets whether this provider should create specialized disposable instances.
    ///     See remarks of this type for details.
    /// </summary>
    /// <remarks>
    ///     Defaults to <see langword="true"/>.
    /// </remarks>
    public bool CreateDisposablePools { get; set; } = true;

    /// <summary>
    ///     Instantiates a new object pool provider.
    /// </summary>
    public DefaultObjectPoolProvider()
    { }

    /// <inheritdoc/>
    public override ObjectPool<T> Create<T>(PooledObjectPolicy<T> policy)
        where T : class
    {
        Guard.IsNotNull(policy);

        if (CreateDisposablePools && typeof(IDisposable).IsAssignableFrom(typeof(T)))
        {
            return new DisposableObjectPool<T>(policy, Capacity);
        }

        return new DefaultObjectPool<T>(policy, Capacity);
    }
}
