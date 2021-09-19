using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Qommon
{
    public static partial class Guard
    {
        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance is in a completed state.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> is not in a completed state.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsCompleted(Task task, [CallerArgumentExpression("task")] string name = null)
        {
            if (task.IsCompleted)
                return;

            Throw.ArgumentExceptionForIsCompleted(task, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance is not in a completed state.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> is in a completed state.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotCompleted(Task task, [CallerArgumentExpression("task")] string name = null)
        {
            if (!task.IsCompleted)
                return;

            Throw.ArgumentExceptionForIsNotCompleted(task, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance has been completed successfully.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> has not been completed successfully.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsCompletedSuccessfully(Task task, [CallerArgumentExpression("task")] string name = null)
        {
            if (task.Status == TaskStatus.RanToCompletion)
                return;

            Throw.ArgumentExceptionForIsCompletedSuccessfully(task, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance has not been completed successfully.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> has been completed successfully.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotCompletedSuccessfully(Task task, [CallerArgumentExpression("task")] string name = null)
        {
            if (task.Status != TaskStatus.RanToCompletion)
                return;

            Throw.ArgumentExceptionForIsNotCompletedSuccessfully(task, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance is faulted.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> is not faulted.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsFaulted(Task task, [CallerArgumentExpression("task")] string name = null)
        {
            if (task.IsFaulted)
                return;

            Throw.ArgumentExceptionForIsFaulted(task, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance is not faulted.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> is faulted.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotFaulted(Task task, [CallerArgumentExpression("task")] string name = null)
        {
            if (!task.IsFaulted)
                return;

            Throw.ArgumentExceptionForIsNotFaulted(task, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance is canceled.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> is not canceled.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsCanceled(Task task, [CallerArgumentExpression("task")] string name = null)
        {
            if (task.IsCanceled)
                return;

            Throw.ArgumentExceptionForIsCanceled(task, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance is not canceled.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> is canceled.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotCanceled(Task task, [CallerArgumentExpression("task")] string name = null)
        {
            if (!task.IsCanceled)
                return;

            Throw.ArgumentExceptionForIsNotCanceled(task, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance has a specific status.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="status">The task status that is accepted.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> doesn't match <paramref name="status"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasStatusEqualTo(Task task, TaskStatus status, [CallerArgumentExpression("task")] string name = null)
        {
            if (task.Status == status)
                return;

            Throw.ArgumentExceptionForHasStatusEqualTo(task, status, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Task"/> instance has not a specific status.
        /// </summary>
        /// <param name="task">The input <see cref="Task"/> instance to test.</param>
        /// <param name="status">The task status that is accepted.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="task"/> matches <paramref name="status"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasStatusNotEqualTo(Task task, TaskStatus status, [CallerArgumentExpression("task")] string name = null)
        {
            if (task.Status != status)
                return;

            Throw.ArgumentExceptionForHasStatusNotEqualTo(task, status, name);
        }
    }
}
