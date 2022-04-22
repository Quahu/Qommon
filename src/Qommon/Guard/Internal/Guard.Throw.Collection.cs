using System;
using System.Diagnostics.CodeAnalysis;

namespace Qommon;

public static partial class Guard
{
    private static partial class Throw
    {
        [DoesNotReturn]
        public static void ArgumentExceptionForIsNotEmptyWithSpan<T>(string name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must not be empty.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsNotEmptyWithReadOnlySpan<T>(string name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must not be empty.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsNotEmpty<T>(string name)
            => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must not be empty.", name);
    }
}
