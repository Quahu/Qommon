using System;
using System.Collections.Generic;
using Qommon.Collections.Proxied;

namespace Qommon.Collections.ReadOnly
{
    internal sealed class ReadOnlySet<T> : ProxiedSet<T>
    {
        public static readonly IReadOnlySet<T> Empty = new HashSet<T>(0).ReadOnly();

        /// <inheritdoc/>
        public override bool IsReadOnly => true;

        public ReadOnlySet(ISet<T> set)
            : base(set)
        { }

        /// <inheritdoc/>
        public override bool Add(T item)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public override void Clear()
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public override bool Remove(T item)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public override void ExceptWith(IEnumerable<T> other)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public override void IntersectWith(IEnumerable<T> other)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public override void SymmetricExceptWith(IEnumerable<T> other)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public override void UnionWith(IEnumerable<T> other)
            => throw new NotSupportedException();
    }
}
