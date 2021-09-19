using System;
using System.Threading.Tasks;

namespace Qommon.Events
{
    public interface IAsynchronousEvent
    {
        ValueTask InvokeAsync(object sender, EventArgs e);

        void Invoke(object sender, EventArgs e);
    }
}
