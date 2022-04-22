using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Qommon;

public static partial class Guard
{
    private static partial class Throw
    {
        [DoesNotReturn]
        public static void ArgumentExceptionForIsCompleted(Task task, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must be completed, had status {GetValueString(task.Status)}.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsNotCompleted(Task task, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must not be completed, had status {GetValueString(task.Status)}.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsCompletedSuccessfully(Task task, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must be completed successfully, had status {GetValueString(task.Status)}.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsNotCompletedSuccessfully(Task task, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must not be completed successfully, had status {GetValueString(task.Status)}.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsFaulted(Task task, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must be faulted, had status {GetValueString(task.Status)}.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsNotFaulted(Task task, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must not be faulted, had status {GetValueString(task.Status)}.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsCanceled(Task task, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must be canceled, had status {GetValueString(task.Status)}.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsNotCanceled(Task task, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must not be canceled, had status {GetValueString(task.Status)}.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForHasStatusEqualTo(Task task, TaskStatus status, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must have status {status}, had status {GetValueString(task.Status)}.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForHasStatusNotEqualTo(Task task, TaskStatus status, string? name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({task.GetType().ToTypeString()}) must not have status {GetValueString(status)}.", name);
    }
}
