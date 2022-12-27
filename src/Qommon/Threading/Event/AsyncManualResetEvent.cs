using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Qommon.Threading;

/// <summary>
///     Represents an asynchronous thread synchronization event
///     that, when signaled, must be reset manually.
/// </summary>
public sealed class AsyncManualResetEvent
{
    /// <summary>
    ///     Gets whether this event is in the signaled state.
    /// </summary>
    public bool IsSet
    {
        get
        {
            lock (this)
            {
                return _tcs.Task.IsCompleted;
            }
        }
    }

    private TaskCompletionSource _tcs;

    /// <summary>
    ///     Instantiates a new <see cref="AsyncManualResetEvent"/> with the state set to unsignaled.
    /// </summary>
    public AsyncManualResetEvent()
        : this(false)
    { }

    /// <summary>
    ///     Instantiates a new <see cref="AsyncManualResetEvent"/>.
    /// </summary>
    /// <param name="initialState"> <see langword="true"/> if the state should be set to signaled, <see langword="false"/> otherwise. </param>
    public AsyncManualResetEvent(bool initialState)
    {
        _tcs = CreateTcs();

        if (initialState)
            _tcs.SetResult();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static TaskCompletionSource CreateTcs()
    {
        return new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
    }

    /// <summary>
    ///     Asynchronously waits for this event to be signaled.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to observe. </param>
    /// <returns>
    ///     A <see cref="Task"/> that will complete when this event is signaled.
    /// </returns>
    public Task WaitAsync(CancellationToken cancellationToken = default)
    {
        lock (this)
        {
            return _tcs.Task.WaitAsync(cancellationToken);
        }
    }

    /// <summary>
    ///     Asynchronously waits for this event to be signaled.
    /// </summary>
    /// <param name="timeout"> The timeout after which the task should be faulted with a <see cref="TimeoutException"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to observe. </param>
    /// <returns>
    ///     A <see cref="Task"/> that will complete when this event is signaled.
    /// </returns>
    public Task WaitAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        lock (this)
        {
            return _tcs.Task.WaitAsync(timeout, cancellationToken);
        }
    }

    /// <summary>
    ///     Sets this event to the signaled state.
    /// </summary>
    public void Set()
    {
        lock (this)
        {
            _tcs.TrySetResult();
        }
    }

    /// <summary>
    ///     Resets this event back to the unsignaled state.
    /// </summary>
    public void Reset()
    {
        lock (this)
        {
            if (!_tcs.Task.IsCompleted)
                return;

            _tcs = CreateTcs();
        }
    }
}
