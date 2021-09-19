using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Qommon.Collections
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EnumerableExtensions
    {
        public static T[] GetArray<T>(this IEnumerable<T> enumerable)
            => enumerable switch
            {
                null => Array.Empty<T>(),
                T[] array => array,
                _ => enumerable.ToArray()
            };
    }
}
