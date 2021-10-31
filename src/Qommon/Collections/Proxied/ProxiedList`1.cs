using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections.Proxied
{
    /// <summary>
    ///     Represents an implementation of <see cref="IList{T}"/> and <see cref="IReadOnlyList{T}"/>
    ///     by wrapping an <see cref="IList{T}"/> with virtual implementations making overriding individual members very simple.
    /// </summary>
    /// <typeparam name="T"> The type of values in the list. </typeparam>
    public abstract class ProxiedList<T> : IList<T>, IReadOnlyList<T>
    {
        /// <inheritdoc cref="ICollection{T}.Count"/>
        public virtual int Count => List.Count;

        /// <inheritdoc/>
        public virtual bool IsReadOnly => List.IsReadOnly;

        /// <inheritdoc cref="IList{T}.this"/>
        public virtual T this[int index]
        {
            get => List[index];
            set => List[index] = value;
        }

        /// <summary>
        ///     Gets the wrapped list.
        /// </summary>
        protected IList<T> List { get; }

        /// <summary>
        ///     Instantiates a new <see cref="ProxiedList{T}"/> wrapping a <see cref="List{T}"/>.
        /// </summary>
        /// <param name="capacity"> The initial capacity of the list. </param>
        protected ProxiedList(int capacity = 0)
        {
            List = new List<T>(capacity);
        }

        /// <summary>
        ///     Instantiates a new <see cref="ProxiedList{T}"/>.
        /// </summary>
        /// <param name="list"> The list to wrap. </param>
        protected ProxiedList(IList<T> list)
        {
            Guard.IsNotNull(list);

            List = list;
        }

        /// <inheritdoc/>
        public virtual void Add(T item)
            => List.Add(item);

        /// <inheritdoc/>
        public virtual void Clear()
            => List.Clear();

        /// <inheritdoc/>
        public virtual bool Contains(T item)
            => List.Contains(item);

        /// <inheritdoc/>
        public virtual void CopyTo(T[] array, int arrayIndex)
            => List.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public virtual bool Remove(T item)
            => List.Remove(item);

        /// <inheritdoc/>
        public virtual int IndexOf(T item)
            => List.IndexOf(item);

        /// <inheritdoc/>
        public virtual void Insert(int index, T item)
            => List.Insert(index, item);

        /// <inheritdoc/>
        public virtual void RemoveAt(int index)
            => List.RemoveAt(index);

        /// <inheritdoc/>
        public virtual IEnumerator<T> GetEnumerator()
            => List.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
