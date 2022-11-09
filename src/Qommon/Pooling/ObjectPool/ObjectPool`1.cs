namespace Qommon.Pooling;

/// <summary>
///     Represents a type from which object instances can be rented and reused.
/// </summary>
/// <typeparam name="T"> The type of the objects. </typeparam>
public abstract class ObjectPool<T>
    where T : class
{
    /// <summary>
    ///     Rents an object from this pool.
    /// </summary>
    /// <returns> The rented object. </returns>
    public abstract T Rent();

    /// <summary>
    ///     Returns a rented object back to this pool.
    /// </summary>
    /// <param name="obj"> The rented object. </param>
    public abstract void Return(T obj);
}
