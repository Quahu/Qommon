using System;
using System.Runtime.CompilerServices;

namespace Qommon
{
    public static partial class Guard
    {
        /// <summary>
        ///     Asserts that the input value is <see langword="default"/>.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input value to test. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentException">
        ///      Thrown if <paramref name="value"/> is not <see langword="default"/>.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsDefault<T>(T value, [CallerArgumentExpression("value")] string? name = null)
            where T : struct, IEquatable<T>
        {
            if (value.Equals(default))
                return;

            Throw.ArgumentExceptionForIsDefault(value, name);
        }

        /// <summary>
        ///     Asserts that the input value is not <see langword="default"/>.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input value to test. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentException">
        ///      Thrown if <paramref name="value"/> is <see langword="default"/>.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotDefault<T>(T value, [CallerArgumentExpression("value")] string? name = null)
            where T : struct, IEquatable<T>
        {
            if (!value.Equals(default))
                return;

            Throw.ArgumentExceptionForIsNotDefault<T>(name);
        }

        /// <summary>
        ///     Asserts that the input value must be equal to a specified value.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="target"> The target <typeparamref name="T"/> value to test for. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentException">
        ///      Thrown if <paramref name="value"/> is != <paramref name="target"/>.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEqualTo<T>(T value, T target, [CallerArgumentExpression("value")] string? name = null)
            where T : IEquatable<T>
        {
            if (value.Equals(target))
                return;

            Throw.ArgumentExceptionForIsEqualTo(value, target, name);
        }

        /// <summary>
        ///     Asserts that the input value must be not equal to a specified value.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="target"> The target <typeparamref name="T"/> value to test for. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentException">
        ///      Thrown if <paramref name="value"/> is == <paramref name="target"/>.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEqualTo<T>(T value, T? target, [CallerArgumentExpression("value")] string? name = null)
            where T : IEquatable<T>
        {
            if (!value.Equals(target))
                return;

            Throw.ArgumentExceptionForIsNotEqualTo(value, target, name);
        }

        /// <summary>
        ///     Asserts that the input value must be less than a specified value.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="maximum"> The exclusive maximum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="value"/> is > = <paramref name="maximum"/>.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsLessThan<T>(T value, T? maximum, [CallerArgumentExpression("value")] string? name = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(maximum) < 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsLessThan(value, maximum, name);
        }

        /// <summary>
        ///     Asserts that the input value must be less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="maximum"> The inclusive maximum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///      Thrown if <paramref name="value"/> is > <paramref name="maximum"/>.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsLessThanOrEqualTo<T>(T value, T? maximum, [CallerArgumentExpression("value")] string? name = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(maximum) <= 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsLessThanOrEqualTo(value, maximum, name);
        }

        /// <summary>
        ///     Asserts that the input value must be greater than a specified value.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="minimum"> The exclusive minimum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///      Thrown if <paramref name="value"/> is &lt;= <paramref name="minimum"/>.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsGreaterThan<T>(T value, T? minimum, [CallerArgumentExpression("value")] string? name = null)
            where T : notnull, IComparable<T>
        {
            if (value.CompareTo(minimum) > 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsGreaterThan(value, minimum, name);
        }

        /// <summary>
        ///     Asserts that the input value must be greater than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="minimum"> The inclusive minimum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///      Thrown if <paramref name="value"/> is &lt; <paramref name="minimum"/>.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsGreaterThanOrEqualTo<T>(T value, T? minimum, [CallerArgumentExpression("value")] string? name = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) >= 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsGreaterThanOrEqualTo(value, minimum, name);
        }

        /// <summary>
        ///     Asserts that the input value must be in a given range.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="minimum"> The inclusive minimum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="maximum"> The exclusive maximum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="value"/> is &lt; <paramref name="minimum"/> or > = <paramref name="maximum"/>.
        /// </exception>
        /// <remarks>
        ///     This API asserts the equivalent of "<paramref name="value"/> in [<paramref name="minimum"/>, <paramref name="maximum"/>)", using arithmetic notation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRange<T>(T value, T minimum, T maximum, [CallerArgumentExpression("value")] string? name = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) >= 0 && value.CompareTo(maximum) < 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRange(value, minimum, maximum, name);
        }

        /// <summary>
        ///     Asserts that the input value must not be in a given range.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="minimum"> The inclusive minimum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="maximum"> The exclusive maximum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="value"/> is > = <paramref name="minimum"/> or &lt; <paramref name="maximum"/>.
        /// </exception>
        /// <remarks>
        ///     This API asserts the equivalent of "<paramref name="value"/> not in [<paramref name="minimum"/>, <paramref name="maximum"/>)", using arithmetic notation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRange<T>(T value, T? minimum, T? maximum, [CallerArgumentExpression("value")] string? name = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0 || value.CompareTo(maximum) >= 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRange(value, minimum, maximum, name);
        }

        /// <summary>
        ///     Asserts that the input value must be in a given interval.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="minimum"> The exclusive minimum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="maximum"> The exclusive maximum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="value"/> is &lt;= <paramref name="minimum"/> or > = <paramref name="maximum"/>.
        /// </exception>
        /// <remarks>
        ///     This API asserts the equivalent of "<paramref name="value"/> in (<paramref name="minimum"/>, <paramref name="maximum"/>)", using arithmetic notation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsBetween<T>(T value, T? minimum, T? maximum, [CallerArgumentExpression("value")] string? name = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) > 0 && value.CompareTo(maximum) < 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsBetween(value, minimum, maximum, name);
        }

        /// <summary>
        ///     Asserts that the input value must not be in a given interval.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="minimum"> The exclusive minimum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="maximum"> The exclusive maximum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///      Thrown if <paramref name="value"/> is > <paramref name="minimum"/> or &lt; <paramref name="maximum"/>.
        /// </exception>
        /// <remarks>
        ///     This API asserts the equivalent of "<paramref name="value"/> not in (<paramref name="minimum"/>, <paramref name="maximum"/>)", using arithmetic notation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotBetween<T>(T value, T? minimum, T? maximum, [CallerArgumentExpression("value")] string? name = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) <= 0 || value.CompareTo(maximum) >= 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotBetween(value, minimum, maximum, name);
        }

        /// <summary>
        ///     Asserts that the input value must be in a given interval.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="minimum"> The inclusive minimum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="maximum"> The inclusive maximum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///      Thrown if <paramref name="value"/> is &lt; <paramref name="minimum"/> or > <paramref name="maximum"/>.
        /// </exception>
        /// <remarks>
        /// This API asserts the equivalent of "<paramref name="value"/> in [<paramref name="minimum"/>, <paramref name="maximum"/>]", using arithmetic notation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsBetweenOrEqualTo<T>(T value, T? minimum, T? maximum, [CallerArgumentExpression("value")] string? name = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) >= 0 && value.CompareTo(maximum) <= 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsBetweenOrEqualTo(value, minimum, maximum, name);
        }

        /// <summary>
        ///     Asserts that the input value must not be in a given interval.
        /// </summary>
        /// <typeparam name="T"> The type of the value. </typeparam>
        /// <param name="value"> The input <typeparamref name="T"/> value to test. </param>
        /// <param name="minimum"> The inclusive minimum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="maximum"> The inclusive maximum <typeparamref name="T"/> value that is accepted. </param>
        /// <param name="name"> The name of the input parameter being tested. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="value"/> is > = <paramref name="minimum"/> or &lt;= <paramref name="maximum"/>.
        /// </exception>
        /// <remarks>
        ///     This API asserts the equivalent of "<paramref name="value"/> not in [<paramref name="minimum"/>, <paramref name="maximum"/>]", using arithmetic notation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotBetweenOrEqualTo<T>(T value, T? minimum, T? maximum, [CallerArgumentExpression("value")] string? name = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0 || value.CompareTo(maximum) > 0)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotBetweenOrEqualTo(value, minimum, maximum, name);
        }
    }
}
