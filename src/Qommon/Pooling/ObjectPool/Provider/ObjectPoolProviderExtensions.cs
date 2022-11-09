namespace Qommon.Pooling;

public static class ObjectPoolProviderExtensions
{
    /// <summary>
    ///     Creates an object pool.
    /// </summary>
    /// <param name="provider"> The object pool provider. </param>
    /// <typeparam name="T"> The type of the objects. </typeparam>
    /// <returns>
    ///     The created object pool.
    /// </returns>
    public static ObjectPool<T> Create<T>(this ObjectPoolProvider provider)
        where T : class, new()
    {
        var policy = new DefaultPooledObjectPolicy<T>();
        return provider.Create(policy);
    }
}
