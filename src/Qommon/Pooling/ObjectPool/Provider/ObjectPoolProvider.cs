namespace Qommon.Pooling;

/// <summary>
///     Represents a type responsible for creating object pools.
/// </summary>
public abstract class ObjectPoolProvider
{
    /// <summary>
    ///     Creates an object pool with the specified object policy.
    /// </summary>
    /// <param name="policy"> The object policy. </param>
    /// <typeparam name="T"> The type of the objects. </typeparam>
    /// <returns>
    ///     The created object pool.
    /// </returns>
    public abstract ObjectPool<T> Create<T>(PooledObjectPolicy<T> policy)
        where T : class;
}
