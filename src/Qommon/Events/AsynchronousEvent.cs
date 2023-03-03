using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading.Tasks;
using Qommon.Pooling;

namespace Qommon.Events;

/// <summary>
///     Represents an event handler used by <see cref="AsynchronousEvent{T}"/>.
/// </summary>
/// <typeparam name="TEventArgs"> The type of <see cref="EventArgs"/> used by this handler. </typeparam>
/// <param name="sender"> The sender invoking the event. </param>
/// <param name="e"> The event data. </param>
public delegate Task AsynchronousEventHandler<TEventArgs>(object? sender, TEventArgs e)
    where TEventArgs : EventArgs;

/// <summary>
///     Represents an asynchronous event handler caller.
/// </summary>
/// <typeparam name="TEventArgs"> The <see cref="Type"/> of <see cref="EventArgs"/> used by this event. </typeparam>
[DebuggerTypeProxy(typeof(AsynchronousEventDebuggerProxy<>))]
[DebuggerDisplay("Count = {Count}")]
public sealed class AsynchronousEvent<TEventArgs> : IAsynchronousEvent
    where TEventArgs : EventArgs
{
    /// <summary>
    ///     Gets the amount of handlers this <see cref="AsynchronousEvent{T}"/> holds.
    /// </summary>
    public int Count => _handlers.Length;

    private ImmutableArray<AsynchronousEventHandler<TEventArgs>> _handlers;

    /// <summary>
    ///     Instantiates a new <see cref="AsynchronousEvent{T}"/>.
    /// </summary>
    public AsynchronousEvent()
    {
        _handlers = ImmutableArray<AsynchronousEventHandler<TEventArgs>>.Empty;
    }

    internal AsynchronousEventHandler<TEventArgs>[] GetSubscribers()
    {
        return _handlers.AsSpan().ToArray();
    }

    /// <summary>
    ///     Subscribes the specified event handler to this event.
    /// </summary>
    /// <param name="handler"> The event handler to subscribe. </param>
    /// <exception cref="ArgumentException">
    ///     Thrown when <paramref name="handler"/> is already a handler of this event.
    /// </exception>
    public void Add(AsynchronousEventHandler<TEventArgs> handler)
    {
        Guard.IsNotNull(handler);

        static ImmutableArray<AsynchronousEventHandler<TEventArgs>> Transformer(
            ImmutableArray<AsynchronousEventHandler<TEventArgs>> handlers,
            AsynchronousEventHandler<TEventArgs> handler)
        {
            if (handlers.Contains(handler))
                return handlers;

            return handlers.Add(handler);
        }

        if (!ImmutableInterlocked.Update(ref _handlers, Transformer, handler))
        {
            throw new ArgumentException($"The event handler {handler} is already subscribed to this event. Did you subscribe twice by mistake?");
        }
    }

    /// <summary>
    ///     Unsubscribes the specified event handler from this event.
    /// </summary>
    /// <param name="handler"> The event handler to unsubscribe. </param>
    /// <exception cref="ArgumentException">
    ///     Thrown when <paramref name="handler"/> is not a handler of this event.
    /// </exception>
    public void Remove(AsynchronousEventHandler<TEventArgs> handler)
    {
        Guard.IsNotNull(handler);

        static ImmutableArray<AsynchronousEventHandler<TEventArgs>> Transformer(
            ImmutableArray<AsynchronousEventHandler<TEventArgs>> handlers,
            AsynchronousEventHandler<TEventArgs> handler)
        {
            return handlers.Remove(handler);
        }

        if (!ImmutableInterlocked.Update(ref _handlers, Transformer, handler))
        {
            throw new ArgumentException($"The event handler {handler} is not subscribed to this event.");
        }
    }

    /// <summary>
    ///     Unsubscribes all event handlers from this event.
    /// </summary>
    public void Clear()
    {
        static ImmutableArray<AsynchronousEventHandler<TEventArgs>> Transformer(ImmutableArray<AsynchronousEventHandler<TEventArgs>> handlers)
        {
            return handlers.Clear();
        }

        ImmutableInterlocked.Update(ref _handlers, Transformer);
    }

    /// <inheritdoc cref="IAsynchronousEvent.InvokeParallel"/>
    public Task InvokeParallel(object? sender, TEventArgs e)
    {
        static async Task InvokeSingleAsync(AsynchronousEventHandler<TEventArgs> handler, object? sender, TEventArgs e)
        {
            try
            {
                await handler.Invoke(sender, e).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new AggregateException("One or more exceptions occurred while invoking the event.", ex);
            }
        }

        static async Task InvokeMultipleAsync(ImmutableArray<AsynchronousEventHandler<TEventArgs>> handlers, int handlerCount, object? sender, TEventArgs e)
        {
            List<Exception>? exceptions = null;
            var tasks = new Task?[handlers.Length];
            for (var i = 0; i < handlers.Length; i++)
            {
                var handler = handlers[i];
                try
                {
                    tasks[i] = handler.Invoke(sender, e);
                }
                catch (Exception ex)
                {
                    (exceptions ??= new()).Add(ex);
                }
            }

            foreach (var task in tasks)
            {
                if (task == null)
                    continue;

                try
                {
                    await task.ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    (exceptions ??= new()).Add(ex);
                }
            }

            if (exceptions != null)
            {
                throw new AggregateException("One or more exceptions occurred while invoking the event.", exceptions);
            }
        }

        var handlers = _handlers;
        var handlerCount = _handlers.Length;
        return handlerCount == 1
            ? InvokeSingleAsync(handlers[0], sender, e)
            : InvokeMultipleAsync(handlers, handlerCount, sender, e);
    }

    /// <inheritdoc cref="IAsynchronousEvent.InvokeSequential"/>
    public Task InvokeSequential(object? sender, TEventArgs e)
    {
        static async Task InvokeSingleAsync(AsynchronousEventHandler<TEventArgs> handler, object? sender, TEventArgs e)
        {
            await handler.Invoke(sender, e).ConfigureAwait(false);
        }

        static async Task InvokeMultipleAsync(ImmutableArray<AsynchronousEventHandler<TEventArgs>> handlers, int handlerCount, object? sender, TEventArgs e)
        {
            for (var i = 0; i < handlerCount; i++)
            {
                var handler = handlers[i];
                var task = handler.Invoke(sender, e);
                await task.ConfigureAwait(false);
            }
        }

        var handlers = _handlers;
        var handlerCount = _handlers.Length;
        return handlerCount == 1
            ? InvokeSingleAsync(handlers[0], sender, e)
            : InvokeMultipleAsync(handlers, handlerCount, sender, e);
    }

    Task IAsynchronousEvent.InvokeParallel(object? sender, EventArgs e)
    {
        return InvokeParallel(sender, (TEventArgs) e);
    }

    Task IAsynchronousEvent.InvokeSequential(object? sender, EventArgs e)
    {
        return InvokeSequential(sender, (TEventArgs) e);
    }
}
