using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections.Synchronized
{
    public interface ISynchronizedList<T> : IList<T>
    {
        T[] ToArray();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => (ToArray() as IList<T>).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
