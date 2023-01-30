using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Qommon.Collections.ReadOnly;

internal static class EmptyReadOnlyInstances
{
    public static class List<T>
    {
        public static readonly IReadOnlyList<T> Instance = Array.Empty<T>().ReadOnly();
    }

    public static class Dictionary<TKey, TValue>
        where TKey : notnull
    {
        public static readonly IReadOnlyDictionary<TKey, TValue> Instance = new EmptyDictionary();

        private sealed class EmptyDictionary : IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>
        {
            public int Count => 0;

            public bool IsReadOnly => true;

            public bool IsFixedSize => true;

            public TValue this[TKey key]
            {
                get => Throw.KeyNotFoundException<TValue>();
                set => Throw.NotSupportedException();
            }

            public object? this[object key]
            {
                get => Throw.KeyNotFoundException<object>();
                set => Throw.NotSupportedException();
            }

            public void Add(KeyValuePair<TKey, TValue> item)
            {
                Throw.NotSupportedException();
            }

            public void Add(object key, object? value)
            {
                Throw.NotSupportedException();
            }

            public void Clear()
            {
                Throw.NotSupportedException();
            }

            public bool Contains(object key)
            {
                return false;
            }

            public bool Contains(KeyValuePair<TKey, TValue> item)
            {
                return false;
            }

            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            { }

            public void Remove(object key)
            {
                throw new NotSupportedException();
            }

            public bool Remove(KeyValuePair<TKey, TValue> item)
            {
                Throw.NotSupportedException();
                return false;
            }

            public void CopyTo(Array array, int index)
            { }

            public bool IsSynchronized => false;

            public object SyncRoot => this;

            public void Add(TKey key, TValue value)
            {
                Throw.NotSupportedException();
            }

            public bool ContainsKey(TKey key)
            {
                return false;
            }

            public bool Remove(TKey key)
            {
                Throw.NotSupportedException();
                return false;
            }

            public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
            {
                value = default;
                return false;
            }

            private sealed class Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator
            {
                public KeyValuePair<TKey, TValue> Current => default;

                object IEnumerator.Current => default!;

                DictionaryEntry IDictionaryEnumerator.Entry => default!;

                object IDictionaryEnumerator.Key => default!;

                object? IDictionaryEnumerator.Value => default;

                public bool MoveNext()
                {
                    return false;
                }

                public void Reset()
                { }

                public void Dispose()
                { }
            }

            IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
            {
                return new Enumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new Enumerator();
            }

            IDictionaryEnumerator IDictionary.GetEnumerator()
            {
                return new Enumerator();
            }

            ICollection<TKey> IDictionary<TKey, TValue>.Keys => Array.Empty<TKey>();

            ICollection<TValue> IDictionary<TKey, TValue>.Values => Array.Empty<TValue>();

            ICollection IDictionary.Values => Array.Empty<object>();

            ICollection IDictionary.Keys => Array.Empty<object>();

            IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys
            {
                get { yield break; }
            }

            IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values
            {
                get { yield break; }
            }
        }
    }

    public static class Set<T>
    {
        public static readonly IReadOnlySet<T> Instance = new HashSet<T>(0).ReadOnly();
    }
}
