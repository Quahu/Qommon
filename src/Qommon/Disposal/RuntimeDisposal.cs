using System;
using System.Threading.Tasks;

namespace Qommon.Disposal
{
    /// <summary>
    ///     Represents utilities for disposing types implementing <see cref="IAsyncDisposable"/> and <see cref="IDisposable"/>
    ///     that are not known at the time of compilation.
    /// </summary>
    public static class RuntimeDisposal
    {
        /// <summary>
        ///     Asynchronously disposes of the specified instance by calling either
        ///     <see cref="IAsyncDisposable.DisposeAsync"/> or <see cref="IDisposable.Dispose"/>,
        ///     or both if <paramref name="disposeBoth"/> is set to <see langword="true"/>.
        /// </summary>
        /// <param name="instance"> The instance to dispose. </param>
        /// <param name="disposeBoth">
        ///     Whether to call both <see cref="IAsyncDisposable.DisposeAsync"/>
        ///     and <see cref="IDisposable.Dispose"/> or only one of them.
        /// </param>
        /// <returns>
        ///     The <see cref="ValueTask"/> representing the disposal work.
        /// </returns>
        public static async ValueTask DisposeAsync(object? instance, bool disposeBoth = false)
        {
            if (instance is IAsyncDisposable asyncDisposable)
                await asyncDisposable.DisposeAsync().ConfigureAwait(false);

            if (instance is IDisposable disposable && (disposeBoth || instance is not IAsyncDisposable))
                disposable.Dispose();
        }

        /// <summary>
        ///     Disposes of the specified instance by calling <see cref="IDisposable.Dispose"/>.
        /// </summary>
        /// <param name="instance"> The instance to dispose. </param>
        public static void Dispose(object? instance)
        {
            if (instance is IDisposable disposable)
                disposable.Dispose();
        }

        /// <summary>
        ///     Wraps the specified instance in a <see cref="RuntimeAsyncDisposable"/>.
        /// </summary>
        /// <param name="instance"> The instance to wrap. </param>
        /// <param name="disposeBoth">
        ///     Whether the <see cref="RuntimeAsyncDisposable"/> should call both
        ///     <see cref="IAsyncDisposable.DisposeAsync"/> and <see cref="IDisposable.Dispose"/> or only one of them.
        /// </param>
        /// <returns>
        ///     The <see cref="RuntimeAsyncDisposable"/> wrapping the instance.
        /// </returns>
        public static RuntimeAsyncDisposable WrapAsync(object? instance, bool disposeBoth = false)
            => new(instance, disposeBoth);

        /// <summary>
        ///     Wraps the specified instance in a <see cref="RuntimeDisposable"/>.
        /// </summary>
        /// <remarks>
        ///     <see cref="WrapAsync(object, bool)"/> should be preferred, if the instance might be implementing <see cref="IAsyncDisposable"/>.
        /// </remarks>
        /// <param name="instance"> The instance to wrap. </param>
        /// <returns>
        ///     The <see cref="RuntimeDisposable"/> wrapping the instance.
        /// </returns>
        public static RuntimeDisposable Wrap(object? instance)
            => new(instance);

        /// <summary>
        ///     Represents an <see cref="IAsyncDisposable"/> that will call <see cref="RuntimeDisposal.DisposeAsync"/> upon disposal.
        /// </summary>
        public readonly struct RuntimeAsyncDisposable : IAsyncDisposable
        {
            private readonly object? _instance;
            private readonly bool _disposeBoth;

            /// <summary>
            ///     Instantiates a new <see cref="RuntimeAsyncDisposable"/>.
            /// </summary>
            /// <param name="instance"> The instance to wrap. </param>
            /// <param name="disposeBoth">  </param>
            public RuntimeAsyncDisposable(object? instance, bool disposeBoth)
            {
                _instance = instance;
                _disposeBoth = disposeBoth;
            }

            /// <inheritdoc/>
            public ValueTask DisposeAsync()
            {
                return RuntimeDisposal.DisposeAsync(_instance, _disposeBoth);
            }
        }

        /// <summary>
        ///     Represents an <see cref="IDisposable"/> that will call <see cref="RuntimeDisposal.Dispose"/> upon disposal.
        /// </summary>
        public readonly struct RuntimeDisposable : IDisposable
        {
            private readonly object? _instance;

            /// <summary>
            ///     Instantiates a new <see cref="RuntimeDisposable"/>.
            /// </summary>
            /// <param name="instance"> The instance to wrap. </param>
            public RuntimeDisposable(object? instance)
            {
                _instance = instance;
            }

            /// <inheritdoc/>
            public void Dispose()
            {
                RuntimeDisposal.Dispose(_instance);
            }
        }
    }
}
