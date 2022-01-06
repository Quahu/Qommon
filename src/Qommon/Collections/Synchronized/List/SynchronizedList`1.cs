using System.Collections.Generic;
using Qommon.Collections.Proxied;

namespace Qommon.Collections.Synchronized
{
    public class SynchronizedList<T> : ProxiedList<T>,
        ISynchronizedList<T>
    {
        public override int Count
        {
            get
            {
                lock (this)
                {
                    return List.Count;
                }
            }
        }

        public override T this[int index]
        {
            get
            {
                lock (this)
                {
                    return List[index];
                }
            }
            set
            {
                lock (this)
                {
                    List[index] = value;
                }
            }
        }

        public SynchronizedList(int capacity = 0)
            : base(capacity)
        { }

        public SynchronizedList(IList<T> list)
            : base(list)
        { }

        public override bool Add(T item)
        {
            lock (this)
            {
                List.Add(item);
                return true;
            }
        }

        public override void Clear()
        {
            lock (this)
            {
                List.Clear();
            }
        }

        public override bool Contains(T item)
        {
            lock (this)
            {
                return List.Contains(item);
            }
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            lock (this)
            {
                List.CopyTo(array, arrayIndex);
            }
        }

        public override bool Remove(T item)
        {
            lock (this)
            {
                return List.Remove(item);
            }
        }

        public override int IndexOf(T item)
        {
            lock (this)
            {
                return List.IndexOf(item);
            }
        }

        public override void Insert(int index, T item)
        {
            lock (this)
            {
                List.Insert(index, item);
            }
        }

        public override void RemoveAt(int index)
        {
            lock (this)
            {
                List.RemoveAt(index);
            }
        }

        public T[] ToArray()
        {
            lock (this)
            {
                var array = new T[List.Count];
                List.CopyTo(array, 0);
                return array;
            }
        }

        public override IEnumerator<T> GetEnumerator()
            => (ToArray() as IList<T>).GetEnumerator();
    }
}
