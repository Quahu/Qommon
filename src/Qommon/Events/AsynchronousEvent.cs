using System;
using System.Threading.Tasks;

namespace Qommon.Events
{
    public delegate Task AsynchronousEventHandler<T>(T e) where T : EventArgs;

    public sealed class AsynchronousEvent<T> where T : EventArgs
    {
        private event AsynchronousEventHandler<T> Delegate;

        private readonly object _lock = new object();
        private readonly Func<Exception, Task> _errorHandler;

        public AsynchronousEvent()
        {
        }

        public AsynchronousEvent(Func<Exception, Task> errorHandler)
        {
            _errorHandler = errorHandler;
        }

        public void Hook(AsynchronousEventHandler<T> handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            lock (_lock)
            {
                Delegate += handler;
            }
        }

        public void Unhook(AsynchronousEventHandler<T> handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            lock (_lock)
            {
                Delegate -= handler;
            }
        }

        public void UnhookAll()
        {
            lock (_lock)
            {
                Delegate = null;
            }
        }

        public async Task InvokeAsync(T e)
        {
            Delegate[] list;
            lock (_lock)
            {
                list = Delegate?.GetInvocationList();
            }

            if (list == null)
                return;

            for (var i = 0; i < list.Length; i++)
            {
                var task = ((AsynchronousEventHandler<T>) list[i])(e);
                if (task == null)
                    continue;

                try
                {
                    await task.ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    if (_errorHandler != null)
                        await _errorHandler(ex).ConfigureAwait(false);
                }
            }
        }
    }
}
