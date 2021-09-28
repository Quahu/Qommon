using System;
using System.Diagnostics.CodeAnalysis;

namespace Qommon
{
    public static partial class Guard
    {
        private static partial class Throw
        {
            [DoesNotReturn]
            public static void ArgumentExceptionForIsDefault<T>(T value, string name)
                where T : struct
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be the default value {GetValueString(default(T))}, was {GetValueString(value)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotDefault<T>(string name)
                where T : struct
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must not be the default value {GetValueString(default(T))}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsEqualTo<T>(T value, T target, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be equal to {GetValueString(target)}, was {GetValueString(value)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotEqualTo<T>(T value, T target, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must not be equal to {GetValueString(target)}, was {GetValueString(value)}.", name);

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsLessThan<T>(T value, T maximum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be less than {GetValueString(maximum)}, was {GetValueString(value)}.");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsLessThanOrEqualTo<T>(T value, T maximum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be less than or equal to {GetValueString(maximum)}, was {GetValueString(value)}.");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsGreaterThan<T>(T value, T minimum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be greater than {GetValueString(minimum)}, was {GetValueString(value)}.");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsGreaterThanOrEqualTo<T>(T value, T minimum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be greater than or equal to {GetValueString(minimum)}, was {GetValueString(value)}.");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRange<T>(T value, T minimum, T maximum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be in the range given by {GetValueString(minimum)} and {GetValueString(maximum)}, was {GetValueString(value)}.");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRange<T>(T value, T minimum, T maximum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must not be in the range given by {GetValueString(minimum)} and {GetValueString(maximum)}, was {GetValueString(value)}.");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsBetween<T>(T value, T minimum, T maximum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be between {GetValueString(minimum)} and {GetValueString(maximum)}, was {GetValueString(value)}.");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotBetween<T>(T value, T minimum, T maximum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must not be between {GetValueString(minimum)} and {GetValueString(maximum)}, was {GetValueString(value)}.");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsBetweenOrEqualTo<T>(T value, T minimum, T maximum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be between or equal to {GetValueString(minimum)} and {GetValueString(maximum)}, was {GetValueString(value)}.");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotBetweenOrEqualTo<T>(T value, T minimum, T maximum, string name)
                => throw new ArgumentOutOfRangeException(name, value!, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must not be between or equal to {GetValueString(minimum)} and {GetValueString(maximum)}, was {GetValueString(value)}.");
        }
    }
}
