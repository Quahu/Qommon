namespace Qommon.Pooling;

/// <summary>
///     Represents static utilities for working with object pools.
/// </summary>
/// <remarks>
///     This type provides a quick and easy way to instantiate object pools from <see cref="DefaultObjectPoolProvider"/>
///     without the need of instantiating it yourself.
///     <para/>
///     For larger applications and especially ones that are based around dependency injection
///     using an object pool provider should be preferred over this type.
/// </remarks>
public static class ObjectPool
{
    private static readonly DefaultObjectPoolProvider DefaultProvider = new();

    /// <summary>
    ///     Creates an object pool with the specified policy.
    /// </summary>
    /// <param name="policy"> The object policy. </param>
    /// <typeparam name="T"> The type of the objects. </typeparam>
    /// <returns>
    ///     The created object pool.
    /// </returns>
    public static ObjectPool<T> Create<T>(PooledObjectPolicy<T> policy)
        where T : class
    {
        return DefaultProvider.Create(policy);
    }

    /// <summary>
    ///     Creates an object pool.
    /// </summary>
    /// <typeparam name="T"> The type of the objects. </typeparam>
    /// <returns>
    ///     The created object pool.
    /// </returns>
    public static ObjectPool<T> Create<T>()
        where T : class, new()
    {
        return DefaultProvider.Create<T>();
    }
}
