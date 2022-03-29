using System.Collections.Generic;
using Qommon.Collections.Proxied;

namespace Qommon.Collections.Synchronized
{
    /// <summary>
    ///     A lightweight (<see langword="lock"/>-based) thread-safe implementation of <see cref="ISet{T}"/>.
    /// </summary>
    public sealed class SynchronizedHashSet<T> : ProxiedSet<T>
    {
        public override int Count
        {
            get
            {
                lock (this)
                {
                    return _hashSet.Count;
                }
            }
        }

        private readonly HashSet<T> _hashSet;

        public SynchronizedHashSet()
            : this(0)
        { }

        public SynchronizedHashSet(int capacity = 0, IEqualityComparer<T>? comparer = null)
        {
            _hashSet = new HashSet<T>(capacity);
        }

        public SynchronizedHashSet(IEnumerable<T> collection)
        {
            _hashSet = new HashSet<T>(collection);
        }

        public override bool Add(T item)
        {
            lock (this)
            {
                return _hashSet.Add(item);
            }
        }

        public override void Clear()
        {
            lock (this)
            {
                _hashSet.Clear();
            }
        }

        public override bool Contains(T item)
        {
            lock (this)
            {
                return _hashSet.Contains(item);
            }
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            lock (this)
            {
                _hashSet.CopyTo(array, arrayIndex);
            }
        }

        public override void ExceptWith(IEnumerable<T> other)
        {
            lock (this)
            {
                _hashSet.ExceptWith(other);
            }
        }

        public override void IntersectWith(IEnumerable<T> other)
        {
            lock (this)
            {
                _hashSet.IntersectWith(other);
            }
        }

        public override bool IsProperSubsetOf(IEnumerable<T> other)
        {
            lock (this)
            {
                return _hashSet.IsProperSubsetOf(other);
            }
        }

        public override bool IsProperSupersetOf(IEnumerable<T> other)
        {
            lock (this)
            {
                return _hashSet.IsProperSupersetOf(other);
            }
        }

        public override bool IsSubsetOf(IEnumerable<T> other)
        {
            lock (this)
            {
                return _hashSet.IsSubsetOf(other);
            }
        }

        public override bool IsSupersetOf(IEnumerable<T> other)
        {
            lock (this)
            {
                return _hashSet.IsSupersetOf(other);
            }
        }

        public override bool Overlaps(IEnumerable<T> other)
        {
            lock (this)
            {
                return _hashSet.Overlaps(other);
            }
        }

        public override bool Remove(T item)
        {
            lock (this)
            {
                return _hashSet.Remove(item);
            }
        }

        public override bool SetEquals(IEnumerable<T> other)
        {
            lock (this)
            {
                return _hashSet.SetEquals(other);
            }
        }

        public override void SymmetricExceptWith(IEnumerable<T> other)
        {
            lock (this)
            {
                _hashSet.SymmetricExceptWith(other);
            }
        }

        public override void UnionWith(IEnumerable<T> other)
        {
            lock (this)
            {
                _hashSet.UnionWith(other);
            }
        }

        public T[] ToArray()
        {
            lock (this)
            {
                var array = new T[_hashSet.Count];
                _hashSet.CopyTo(array);
                return array;
            }
        }

        public override IEnumerator<T> GetEnumerator()
            => (ToArray() as IReadOnlyList<T>).GetEnumerator();
    }
}
