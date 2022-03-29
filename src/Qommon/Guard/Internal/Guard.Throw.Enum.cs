using System;
using System.Diagnostics.CodeAnalysis;

namespace Qommon
{
    public static partial class Guard
    {
        private static partial class Throw
        {
            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsDefined<T>(T value, string? name)
                where T : struct, Enum
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be defined within the enum, was {GetValueString(value)}.", name);
        }
    }
}
