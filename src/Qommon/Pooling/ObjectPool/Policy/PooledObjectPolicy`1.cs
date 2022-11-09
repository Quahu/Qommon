namespace Qommon.Pooling;

/// <summary>
///     Represents a type responsible for the objects of an object pool.
/// </summary>
/// <typeparam name="T"> The type of the objects. </typeparam>
public abstract class PooledObjectPolicy<T>
    where T : class
{
    /// <summary>
    ///     Creates an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <returns> The created object. </returns>
    public abstract T Create();

    /// <summary>
    ///     Called when an object is returned to the pool.
    /// </summary>
    /// <param name="obj"> The returned object. </param>
    /// <returns>
    ///     <see langword="true"/> if the object should be stored in the pool
    ///     or <see langword="false"/> if it is no longer viable and should be discarded.
    /// </returns>
    public abstract bool OnReturn(T obj);
}
