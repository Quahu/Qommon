using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections.Synchronized
{
    public interface ISynchronizedList<T> : IList<T>
    {
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => (this.ToArray() as IList<T>).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
