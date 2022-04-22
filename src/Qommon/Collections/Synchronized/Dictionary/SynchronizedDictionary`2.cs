using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Qommon.Collections.Proxied;

namespace Qommon.Collections.Synchronized;

public class SynchronizedDictionary<TKey, TValue> : ProxiedDictionary<TKey, TValue>,
    ISynchronizedDictionary<TKey, TValue>
    where TKey : notnull
{
    public override ICollection<TKey> Keys
    {
        get
        {
            lock (this)
            {
                var array = new TKey[Dictionary.Count];
                Dictionary.Keys.CopyTo(array, 0);
                return array;
            }
        }
    }

    public override ICollection<TValue> Values
    {
        get
        {
            lock (this)
            {
                var array = new TValue[Dictionary.Count];
                Dictionary.Values.CopyTo(array, 0);
                return array;
            }
        }
    }

    public override int Count
    {
        get
        {
            lock (this)
            {
                return Dictionary.Count;
            }
        }
    }

    public override TValue this[TKey key]
    {
        get
        {
            lock (this)
            {
                return Dictionary[key];
            }
        }
        set
        {
            lock (this)
            {
                Dictionary[key] = value;
            }
        }
    }

    public SynchronizedDictionary(int capacity = 0, IEqualityComparer<TKey>? comparer = null)
        : base(new Dictionary<TKey, TValue>(capacity, comparer))

    { }

    public SynchronizedDictionary(IDictionary<TKey, TValue> dictionary)
        : base(dictionary)

    { }

    public bool TryAdd(TKey key, TValue value)
    {
        lock (this)
        {
            return Dictionary.TryAdd(key, value);
        }
    }

    public bool TryRemove(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        lock (this)
        {
            return Dictionary.Remove(key, out value);
        }
    }

    public override void Add(TKey key, TValue value)
    {
        lock (this)
        {
            Dictionary.Add(key, value);
        }
    }

    public override void Clear()
    {
        lock (this)
        {
            Dictionary.Clear();
        }
    }

    public override bool ContainsKey(TKey key)
    {
        lock (this)
        {
            return Dictionary.ContainsKey(key);
        }
    }

    public override void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        lock (this)
        {
            Dictionary.CopyTo(array, arrayIndex);
        }
    }

    public override bool Remove(TKey key)
    {
        lock (this)
        {
            return Dictionary.Remove(key);
        }
    }

    public override bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        lock (this)
        {
            return Dictionary.TryGetValue(key, out value);
        }
    }

    public KeyValuePair<TKey, TValue>[] ToArray()
    {
        lock (this)
        {
            var array = new KeyValuePair<TKey, TValue>[Dictionary.Count];
            Dictionary.CopyTo(array, 0);
            return array;
        }
    }

    public override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        => (ToArray() as IList<KeyValuePair<TKey, TValue>>).GetEnumerator();

    TKey[] ISynchronizedDictionary<TKey, TValue>.Keys => (Keys as TKey[])!;

    TValue[] ISynchronizedDictionary<TKey, TValue>.Values => (Values as TValue[])!;
}
