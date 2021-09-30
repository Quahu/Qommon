using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Qommon
{
    public static partial class Guard
    {
        private static partial class Throw
        {
            [Pure]
            private static string GetNameString(string name)
            {
                if (name == null)
                    return "provided";

                if (name.StartsWith('"'))
                    return name;

                return $"\"{name}\"";
            }

            [Pure]
            private static string GetValueString<T>(T value)
            {
                return value switch
                {
                    string _ => $"\"{value}\"",
                    null => "null",
                    _ => $"<{value}>"
                };
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNull<T>(T value, string name)
                where T : class
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be null, was {GetValueString(value)} ({value.GetType().ToTypeString()}).", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNull<T>(T? value, string name)
                where T : struct
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T?).ToTypeString()}) must be null, was {GetValueString(value)} ({typeof(T).ToTypeString()}).", name);

            [DoesNotReturn]
            public static void ArgumentNullExceptionForIsNotNull<T>(string name)
                => throw new ArgumentNullException(name, $"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be not null.");

            [DoesNotReturn]
            public static void ArgumentExceptionForIsOfType<T>(object value, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} must be of type {typeof(T).ToTypeString()}, was {value.GetType().ToTypeString()}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotOfType<T>(object value, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} must not be of type {typeof(T).ToTypeString()}, was {value.GetType().ToTypeString()}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsOfType(object value, Type type, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} must be of type {type.ToTypeString()}, was {value.GetType().ToTypeString()}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotOfType(object value, Type type, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} must not be of type {type.ToTypeString()}, was {value.GetType().ToTypeString()}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsAssignableToType<T>(object value, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} must be assignable to type {typeof(T).ToTypeString()}, was {value.GetType().ToTypeString()}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotAssignableToType<T>(object value, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} must not be assignable to type {typeof(T).ToTypeString()}, was {value.GetType().ToTypeString()}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsAssignableToType(object value, Type type, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} must be assignable to type {type.ToTypeString()}, was {value.GetType().ToTypeString()}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotAssignableToType(object value, Type type, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} must not be assignable to type {type.ToTypeString()}, was {value.GetType().ToTypeString()}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsReferenceEqualTo<T>(string name)
                where T : class
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must be the same instance as the target object.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForIsReferenceNotEqualTo<T>(string name)
                where T : class
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T).ToTypeString()}) must not be the same instance as the target object.", name);
        }
    }
}
