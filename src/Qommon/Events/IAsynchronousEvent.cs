using System;
using System.Threading.Tasks;

namespace Qommon.Events;

/// <summary>
///     Represents an asynchronous event.
/// </summary>
public interface IAsynchronousEvent
{
    /// <summary>
    ///     Invokes this <see cref="IAsynchronousEvent"/>.
    /// </summary>
    /// <param name="sender"> The event sender. </param>
    /// <param name="e"> The event data. </param>
    /// <returns>
    ///     A <see cref="ValueTask"/> representing the invocation work.
    /// </returns>
    ValueTask InvokeAsync(object? sender, EventArgs e);

    /// <summary>
    ///     Invokes this <see cref="IAsynchronousEvent"/>.
    /// </summary>
    /// <param name="sender"> The event sender. </param>
    /// <param name="e"> The event data. </param>
    void Invoke(object? sender, EventArgs e);
}
