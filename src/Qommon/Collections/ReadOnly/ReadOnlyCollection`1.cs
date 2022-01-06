using System;
using System.Collections.Generic;
using Qommon.Collections.Proxied;

namespace Qommon.Collections.ReadOnly
{
    internal sealed class ReadOnlyCollection<T> : ProxiedCollection<T>
    {
        public static readonly IReadOnlyCollection<T> Empty = Array.Empty<T>().ReadOnly();

        /// <inheritdoc/>
        public override bool IsReadOnly => true;

        public ReadOnlyCollection(ICollection<T> collection)
            : base(collection)
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
    }
}
