using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Qommon.Collections.ThreadSafe;

/// <remarks>
///     This type uses <see cref="Monitor"/> for synchronization.
/// </remarks>
internal sealed class MonitorThreadSafeDictionary<TKey, TValue> : ThreadSafeDictionary<TKey, TValue>
    where TKey : notnull
{
    public override TKey[] Keys
    {
        get
        {
            lock (this)
            {
                var keys = new TKey[_dictionary.Count];
                _dictionary.Keys.CopyTo(keys, 0);
                return keys;
            }
        }
    }

    public override TValue[] Values
    {
        get
        {
            lock (this)
            {
                var values = new TValue[_dictionary.Count];
                _dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }
    }

    public override int Count
    {
        get
        {
            lock (this)
            {
                return _dictionary.Count;
            }
        }
    }

    public override bool IsEmpty
    {
        get
        {
            lock (this)
            {
                return _dictionary.Count == 0;
            }
        }
    }

    public override bool IsReadOnly
    {
        get
        {
            lock (this)
            {
                return _dictionary.IsReadOnly;
            }
        }
    }

    public override TValue this[TKey key]
    {
        get
        {
            lock (this)
            {
                return _dictionary[key];
            }
        }
        set
        {
            lock (this)
            {
                _dictionary[key] = value;
            }
        }
    }

    private readonly IDictionary<TKey, TValue> _dictionary;

    public MonitorThreadSafeDictionary(IDictionary<TKey, TValue> dictionary)
    {
        _dictionary = dictionary;
    }

    public override bool TryAdd(TKey key, TValue value)
    {
        lock (this)
        {
            return _dictionary.TryAdd(key, value);
        }
    }

    public override TValue GetOrAdd(TKey key, TValue value)
    {
        lock (this)
        {
            if (_dictionary.TryGetValue(key, out var existingValue))
            {
                return existingValue;
            }

            _dictionary.Add(key, value);
            return value;
        }
    }

    public override TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
    {
        lock (this)
        {
            if (_dictionary.TryGetValue(key, out var existingValue))
            {
                return existingValue;
            }

            var value = valueFactory(key);
            _dictionary.Add(key, value);
            return value;
        }
    }

    public override TValue GetOrAdd<TState>(TKey key, Func<TKey, TState, TValue> valueFactory, TState state)
    {
        lock (this)
        {
            if (_dictionary.TryGetValue(key, out var existingValue))
            {
                return existingValue;
            }

            var value = valueFactory(key, state);
            _dictionary.Add(key, value);
            return value;
        }
    }

    public override TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateFactory)
    {
        lock (this)
        {
            if (_dictionary.TryGetValue(key, out var existingValue))
            {
                existingValue = updateFactory(key, existingValue);
                _dictionary[key] = existingValue;
                return existingValue;
            }

            _dictionary.Add(key, addValue);
            return addValue;
        }
    }

    public override TValue AddOrUpdate(TKey key, Func<TKey, TValue> addFactory, Func<TKey, TValue, TValue> updateFactory)
    {
        lock (this)
        {
            if (_dictionary.TryGetValue(key, out var existingValue))
            {
                existingValue = updateFactory(key, existingValue);
                _dictionary[key] = existingValue;
                return existingValue;
            }

            var value = addFactory(key);
            _dictionary.Add(key, value);
            return value;
        }
    }

    public override TValue AddOrUpdate<TState>(TKey key, Func<TKey, TState, TValue> addFactory, Func<TKey, TValue, TState, TValue> updateFactory, TState state)
    {
        lock (this)
        {
            if (_dictionary.TryGetValue(key, out var existingValue))
            {
                existingValue = updateFactory(key, existingValue, state);
                _dictionary[key] = existingValue;
                return existingValue;
            }

            var value = addFactory(key, state);
            _dictionary.Add(key, value);
            return value;
        }
    }

    public override bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
    {
        lock (this)
        {
            if (_dictionary.TryGetValue(key, out var existingValue))
            {
                var valueComparer = EqualityComparer<TValue>.Default;
                if (valueComparer.Equals(existingValue, comparisonValue))
                {
                    _dictionary[key] = newValue;
                    return true;
                }
            }

            return false;
        }
    }

    public override bool TryRemove(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        lock (this)
        {
            return _dictionary.Remove(key, out value);
        }
    }

    public override KeyValuePair<TKey, TValue>[] ToArray()
    {
        lock (this)
        {
            var items = new KeyValuePair<TKey, TValue>[_dictionary.Count];
            _dictionary.CopyTo(items, 0);
            return items;
        }
    }

    public override bool ContainsKey(TKey key)
    {
        lock (this)
        {
            return _dictionary.ContainsKey(key);
        }
    }

    public override void Add(TKey key, TValue value)
    {
        lock (this)
        {
            _dictionary.Add(key, value);
        }
    }

    public override bool Remove(TKey key)
    {
        lock (this)
        {
            return _dictionary.Remove(key);
        }
    }

    public override void Clear()
    {
        lock (this)
        {
            _dictionary.Clear();
        }
    }

    public override bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        lock (this)
        {
            return _dictionary.TryGetValue(key, out value);
        }
    }

    public override void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        lock (this)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }
    }

    public override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return (ToArray() as IList<KeyValuePair<TKey, TValue>>).GetEnumerator();
    }
}
