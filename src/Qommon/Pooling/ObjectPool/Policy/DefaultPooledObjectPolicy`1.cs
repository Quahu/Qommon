namespace Qommon.Pooling;

/// <summary>
///     Represents the default pooled object policy,
///     for object types with parameterless constructors.
/// </summary>
/// <typeparam name="T"> The type of the objects. </typeparam>
public class DefaultPooledObjectPolicy<T> : PooledObjectPolicy<T>
    where T : class, new()
{
    /// <inheritdoc/>
    public override T Create()
    {
        return new T();
    }

    /// <inheritdoc/>
    public override bool OnReturn(T obj)
    {
        return true;
    }
}
