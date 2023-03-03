using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Qommon.Events;

namespace Qommon.Tests.Events;

public class AsynchronousEventTests : QommonFixture
{
    [Test]
    public void Subscribe_DuplicateHandler_Throws()
    {
        var asyncEvent = new AsynchronousEvent<EventArgs>();
        var eventHandler = new AsynchronousEventHandler<EventArgs>((sender, e) => Task.CompletedTask);
        asyncEvent.Add(eventHandler);
        Assert.Throws<ArgumentException>(() => asyncEvent.Add(eventHandler));
    }

    [Test]
    public void Unsubscribe_NotSubcribedHandler_Throws()
    {
        var asyncEvent = new AsynchronousEvent<EventArgs>();
        var eventHandler = new AsynchronousEventHandler<EventArgs>((sender, e) => Task.CompletedTask);
        Assert.Throws<ArgumentException>(() => asyncEvent.Remove(eventHandler));
    }

    [Test]
    public void Unsubscribe_SubcribedHandler_Passes()
    {
        var asyncEvent = new AsynchronousEvent<EventArgs>();
        var eventHandler = new AsynchronousEventHandler<EventArgs>((sender, e) => Task.CompletedTask);
        asyncEvent.Add(eventHandler);
        asyncEvent.Remove(eventHandler);
    }

    [Test]
    public async Task InvokeAsync_MultipleHandlers_AllCompleted()
    {
        var counter = 0;
        var asyncEvent = new AsynchronousEvent<EventArgs>();
        var eventHandler1 = new AsynchronousEventHandler<EventArgs>(async (sender, e) =>
        {
            await Task.Yield();
            Interlocked.Increment(ref counter);
        });

        var eventHandler2 = new AsynchronousEventHandler<EventArgs>(async (sender, e) =>
        {
            await Task.Yield();
            Interlocked.Increment(ref counter);
        });

        var eventHandler3 = new AsynchronousEventHandler<EventArgs>(async (sender, e) =>
        {
            await Task.Yield();
            Interlocked.Increment(ref counter);
        });

        asyncEvent.Add(eventHandler1);
        asyncEvent.Add(eventHandler2);
        asyncEvent.Add(eventHandler3);

        await asyncEvent.InvokeParallel(null, EventArgs.Empty);
        Assert.AreEqual(3, counter);
    }
}
