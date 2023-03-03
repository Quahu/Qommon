using System;
using System.Diagnostics;
using Qommon.Events;

namespace Qommon.Pooling;

internal sealed class AsynchronousEventDebuggerProxy<T>
    where T : EventArgs
{
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public AsynchronousEventHandler<T>[] Subscribers => _asynchronousEvent.GetSubscribers();

    private readonly AsynchronousEvent<T> _asynchronousEvent;

    public AsynchronousEventDebuggerProxy(AsynchronousEvent<T> asynchronousEvent)
    {
        _asynchronousEvent = asynchronousEvent;
    }
}
