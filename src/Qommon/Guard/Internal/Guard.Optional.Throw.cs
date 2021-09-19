using System;
using System.Diagnostics.CodeAnalysis;

namespace Qommon
{
    public static partial class Guard
    {
        private static partial class Throw
        {
            [DoesNotReturn]
            public static void ArgumentExceptionForHasValue<T>(Optional<T> optional, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Optional<T>).ToTypeString()}) must have a value.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForHasNoValue<T>(Optional<T> optional, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Optional<T>).ToTypeString()}) must not have a value.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForCheckValue<T>(Optional<T> optional, string name, Exception exception)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Optional<T>).ToTypeString()}) has a value which failed to pass an inner assertion.", name, exception);
            }
        }
    }
}
