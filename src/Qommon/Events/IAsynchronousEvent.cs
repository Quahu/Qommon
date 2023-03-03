using System;
using System.Threading.Tasks;

namespace Qommon.Events;

/// <summary>
///     Represents an asynchronous event.
/// </summary>
public interface IAsynchronousEvent
{
    /// <summary>
    ///     Invokes the subscribed event handlers of this event in parallel.
    /// </summary>
    /// <param name="sender"> The sender invoking the event. </param>
    /// <param name="e"> The event data. </param>
    /// <remarks>
    ///     Exceptions occurring in the handlers are collected and then thrown
    ///     combined as an <see cref="AggregateException"/>.
    /// </remarks>
    /// <returns>
    ///     A <see cref="Task"/> which will complete when all subscribed handlers
    ///     have finished executing.
    /// </returns>
    /// <exception cref="AggregateException">
    ///     Thrown when one or more exceptions occurred in the subscribed event handlers.
    /// </exception>
    Task InvokeParallel(object? sender, EventArgs e);

    /// <summary>
    ///     Invokes the subscribed event handlers of this event sequentially.
    /// </summary>
    /// <remarks>
    ///     Exceptions occurring in the handlers are immediately thrown.
    /// </remarks>
    /// <param name="sender"> The sender invoking the event. </param>
    /// <param name="e"> The event data. </param>
    /// <returns>
    ///     A <see cref="Task"/> which will complete when all subscribed handlers
    ///     have finished executing.
    /// </returns>
    Task InvokeSequential(object? sender, EventArgs e);
}
