using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Qommon
{
    /// <summary>
    /// Helper methods to verify conditions when running code.
    /// </summary>
    [DebuggerStepThrough]
    public static partial class Guard
    {
        /// <summary>
        /// Asserts that the input value is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of reference value type being tested.</typeparam>
        /// <param name="value">The input value to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not <see langword="null"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNull<T>(T value, [CallerArgumentExpression("value")] string name = null)
            where T : class
        {
            if (value is null)
                return;

            Throw.ArgumentExceptionForIsNull(value, name);
        }

        /// <summary>
        /// Asserts that the input value is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of nullable value type being tested.</typeparam>
        /// <param name="value">The input value to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not <see langword="null"/>.</exception>
        /// <remarks>The method is generic to avoid boxing the parameters, if they are value types.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNull<T>(T? value, [CallerArgumentExpression("value")] string name = null)
            where T : struct
        {
            if (value is null)
                return;

            Throw.ArgumentExceptionForIsNull(value, name);
        }

        /// <summary>
        /// Asserts that the input value is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of reference value type being tested.</typeparam>
        /// <param name="value">The input value to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <see langword="null"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull<T>([NotNull] T value, [CallerArgumentExpression("value")] string name = null)
            where T : class
        {
            if (value is not null)
                return;

            Throw.ArgumentNullExceptionForIsNotNull<T>(name);
        }

        /// <summary>
        /// Asserts that the input value is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of nullable value type being tested.</typeparam>
        /// <param name="value">The input value to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <remarks>The method is generic to avoid boxing the parameters, if they are value types.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull<T>([NotNull] T? value, [CallerArgumentExpression("value")] string name = null)
            where T : struct
        {
            if (value is not null)
                return;

            Throw.ArgumentNullExceptionForIsNotNull<T?>(name);
        }

        /// <summary>
        /// Asserts that the input value is of a specific type.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="value">The input <see cref="object"/> to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not of type <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsOfType<T>(object value, [CallerArgumentExpression("value")] string name = null)
        {
            if (value.GetType() == typeof(T))
                return;

            Throw.ArgumentExceptionForIsOfType<T>(value, name);
        }

        /// <summary>
        /// Asserts that the input value is not of a specific type.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="value">The input <see cref="object"/> to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is of type <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotOfType<T>(object value, [CallerArgumentExpression("value")] string name = null)
        {
            if (value.GetType() != typeof(T))
                return;

            Throw.ArgumentExceptionForIsNotOfType<T>(value, name);
        }

        /// <summary>
        /// Asserts that the input value is of a specific type.
        /// </summary>
        /// <param name="value">The input <see cref="object"/> to test.</param>
        /// <param name="type">The type to look for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the type of <paramref name="value"/> is not the same as <paramref name="type"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsOfType(object value, Type type, [CallerArgumentExpression("value")] string name = null)
        {
            if (value.GetType() == type)
                return;

            Throw.ArgumentExceptionForIsOfType(value, type, name);
        }

        /// <summary>
        /// Asserts that the input value is not of a specific type.
        /// </summary>
        /// <param name="value">The input <see cref="object"/> to test.</param>
        /// <param name="type">The type to look for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the type of <paramref name="value"/> is the same as <paramref name="type"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotOfType(object value, Type type, [CallerArgumentExpression("value")] string name = null)
        {
            if (value.GetType() != type)
                return;

            Throw.ArgumentExceptionForIsNotOfType(value, type, name);
        }

        /// <summary>
        /// Asserts that the input value can be assigned to a specified type.
        /// </summary>
        /// <typeparam name="T">The type to check the input value against.</typeparam>
        /// <param name="value">The input <see cref="object"/> to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> can't be assigned to type <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsAssignableToType<T>(object value, [CallerArgumentExpression("value")] string name = null)
        {
            if (value is T)
                return;

            Throw.ArgumentExceptionForIsAssignableToType<T>(value, name);
        }

        /// <summary>
        /// Asserts that the input value can't be assigned to a specified type.
        /// </summary>
        /// <typeparam name="T">The type to check the input value against.</typeparam>
        /// <param name="value">The input <see cref="object"/> to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> can be assigned to type <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotAssignableToType<T>(object value, [CallerArgumentExpression("value")] string name = null)
        {
            if (value is not T)
                return;

            Throw.ArgumentExceptionForIsNotAssignableToType<T>(value, name);
        }

        /// <summary>
        /// Asserts that the input value can be assigned to a specified type.
        /// </summary>
        /// <param name="value">The input <see cref="object"/> to test.</param>
        /// <param name="type">The type to look for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> can't be assigned to <paramref name="type"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsAssignableToType(object value, Type type, [CallerArgumentExpression("value")] string name = null)
        {
            if (type.IsInstanceOfType(value))
                return;

            Throw.ArgumentExceptionForIsAssignableToType(value, type, name);
        }

        /// <summary>
        /// Asserts that the input value can't be assigned to a specified type.
        /// </summary>
        /// <param name="value">The input <see cref="object"/> to test.</param>
        /// <param name="type">The type to look for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> can be assigned to <paramref name="type"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotAssignableToType(object value, Type type, [CallerArgumentExpression("value")] string name = null)
        {
            if (!type.IsInstanceOfType(value))
                return;

            Throw.ArgumentExceptionForIsNotAssignableToType(value, type, name);
        }

        /// <summary>
        /// Asserts that the input value must be the same instance as the target value.
        /// </summary>
        /// <typeparam name="T">The type of input values to compare.</typeparam>
        /// <param name="value">The input <typeparamref name="T"/> value to test.</param>
        /// <param name="target">The target <typeparamref name="T"/> value to test for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not the same instance as <paramref name="target"/>.</exception>
        /// <remarks>The method is generic to prevent using it with value types.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsReferenceEqualTo<T>(T value, T target, [CallerArgumentExpression("value")] string name = null)
            where T : class
        {
            if (ReferenceEquals(value, target))
                return;

            Throw.ArgumentExceptionForIsReferenceEqualTo<T>(name);
        }

        /// <summary>
        /// Asserts that the input value must not be the same instance as the target value.
        /// </summary>
        /// <typeparam name="T">The type of input values to compare.</typeparam>
        /// <param name="value">The input <typeparamref name="T"/> value to test.</param>
        /// <param name="target">The target <typeparamref name="T"/> value to test for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is the same instance as <paramref name="target"/>.</exception>
        /// <remarks>The method is generic to prevent using it with value types.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsReferenceNotEqualTo<T>(T value, T target, [CallerArgumentExpression("value")] string name = null)
            where T : class
        {
            if (!ReferenceEquals(value, target))
                return;

            Throw.ArgumentExceptionForIsReferenceNotEqualTo<T>(name);
        }

        /// <summary>
        /// Asserts that the input value must be <see langword="true"/>.
        /// </summary>
        /// <param name="value">The input <see cref="bool"/> to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <param name="message">A message to display if <paramref name="value"/> is <see langword="false"/>.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is <see langword="false"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsTrue([DoesNotReturnIf(false)] bool value, [CallerArgumentExpression("value")] string name = null, string message = null)
        {
            if (value)
                return;

            Throw.ArgumentExceptionForIsTrue(name, message);
        }

        /// <summary>
        /// Asserts that the input value must be <see langword="false"/>.
        /// </summary>
        /// <param name="value">The input <see cref="bool"/> to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <param name="message">A message to display if <paramref name="value"/> is <see langword="true"/>.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is <see langword="true"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsFalse([DoesNotReturnIf(true)] bool value, [CallerArgumentExpression("value")] string name = null, string message = null)
        {
            if (!value)
                return;

            Throw.ArgumentExceptionForIsFalse(name, message);
        }
    }
}