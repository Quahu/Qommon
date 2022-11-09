using System.Diagnostics;
using System.Threading;

namespace Qommon.Pooling;

/// <summary>
///     Represents the default <see cref="ObjectPool{T}"/> implementation.
/// </summary>
/// <typeparam name="T"> The type of the objects. </typeparam>
public class DefaultObjectPool<T> : ObjectPool<T>
    where T : class
{
    private protected readonly PooledObjectPolicy<T> _policy;
    private protected readonly bool _isDefaultPolicy;
    private protected T? _fastObject;
    private protected readonly ArrayWrapper[] _slowObjects;

    [DebuggerDisplay($"{{{nameof(Value)}}}")]
    private protected struct ArrayWrapper
    {
        public T? Value;
    }

    /// <summary>
    ///     Instantiates a new pool with the specified policy and size.
    /// </summary>
    /// <param name="policy"> The object policy. </param>
    /// <param name="capacity"> The amount of items to retain in the pool. </param>
    public DefaultObjectPool(PooledObjectPolicy<T> policy, int capacity)
    {
        Guard.IsNotNull(policy);

        _policy = policy;
        var type = policy.GetType();
        _isDefaultPolicy = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DefaultPooledObjectPolicy<>);

        _fastObject = null;
        _slowObjects = new ArrayWrapper[capacity - 1];
    }

    /// <inheritdoc/>
    public override T Rent()
    {
        var obj = _fastObject;
        if (obj == null || Interlocked.CompareExchange(ref _fastObject, null, obj) != obj)
        {
            var slowObjects = _slowObjects;
            for (var i = 0; i < slowObjects.Length; i++)
            {
                obj = slowObjects[i].Value;
                if (obj != null && Interlocked.CompareExchange(ref slowObjects[i].Value, null, obj) == obj)
                {
                    return obj;
                }
            }

            obj = _policy.Create();
        }

        return obj;
    }

    /// <inheritdoc/>
    public override void Return(T obj)
    {
        if (!_isDefaultPolicy && !_policy.OnReturn(obj))
            return;

        if (_fastObject != null || Interlocked.CompareExchange(ref _fastObject, obj, null) != null)
        {
            var slowObjects = _slowObjects;
            for (var i = 0; i < slowObjects.Length && Interlocked.CompareExchange(ref slowObjects[i].Value, obj, null) != null; i++)
            { }
        }
    }
}
