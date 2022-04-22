using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Qommon.Threading;

/// <summary>
///     Represents <see cref="SemaphoreSlim"/> extensions.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class SemaphoreSlimExtensions
{
    /// <summary>
    ///     Asynchronously waits to enter this <see cref="SemaphoreSlim"/>.
    ///     The returned disposable will release the <see cref="SemaphoreSlim"/> once upon disposal.
    /// </summary>
    /// <param name="semaphore"> The <see cref="SemaphoreSlim"/> to enter. </param>
    /// <param name="cancellationToken"> The <see cref="CancellationToken"/> to observe. </param>
    /// <returns>
    ///     A <see cref="ValueTask{TResult}"/> that will complete when the semaphore has been entered
    ///     with the result being a <see cref="SemaphoreEnterDisposable"/>.
    /// </returns>
    public static async ValueTask<SemaphoreEnterDisposable> EnterAsync(this SemaphoreSlim semaphore, CancellationToken cancellationToken = default)
    {
        if (semaphore.Wait(0, cancellationToken))
            return new SemaphoreEnterDisposable(semaphore);

        await semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        return new SemaphoreEnterDisposable(semaphore);
    }

    /// <summary>
    ///     Synchronously waits to enter this <see cref="SemaphoreSlim"/>.
    ///     The returned disposable will release the <see cref="SemaphoreSlim"/> once upon disposal.
    /// </summary>
    /// <param name="semaphore"> The <see cref="SemaphoreSlim"/> to enter. </param>
    /// <param name="cancellationToken"> The <see cref="CancellationToken"/> to observe. </param>
    /// <returns>
    ///     A <see cref="ValueTask{TResult}"/> that will complete when the semaphore has been entered
    ///     with the result being a <see cref="SemaphoreEnterDisposable"/>.
    /// </returns>
    public static SemaphoreEnterDisposable Enter(this SemaphoreSlim semaphore, CancellationToken cancellationToken = default)
    {
        semaphore.Wait(cancellationToken);
        return new SemaphoreEnterDisposable(semaphore);
    }

    /// <summary>
    ///     Represents an <see cref="IDisposable"/> that will release the wrapped
    ///     <see cref="SemaphoreSlim"/> once upon disposal.
    /// </summary>
    public struct SemaphoreEnterDisposable : IDisposable
    {
        private SemaphoreSlim? _semaphore;

        /// <summary>
        ///     Instantiates a new <see cref="SemaphoreEnterDisposable"/>
        /// </summary>
        /// <param name="semaphore"></param>
        public SemaphoreEnterDisposable(SemaphoreSlim semaphore)
        {
            Guard.IsNotNull(semaphore);

            _semaphore = semaphore;
        }

        /// <summary>
        ///     Releases the <see cref="SemaphoreSlim"/> once.
        /// </summary>
        public void Dispose()
        {
            _semaphore?.Dispose();
            _semaphore = null;
        }
    }
}