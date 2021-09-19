using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Qommon
{
    public static partial class Guard
    {
        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must be <see langword="null"/> or empty.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="text"/> is neither <see langword="null"/> nor empty.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNullOrEmpty(string text, [CallerArgumentExpression("text")] string name = null)
        {
            if (string.IsNullOrEmpty(text))
                return;

            Throw.ArgumentExceptionForIsNullOrEmpty(text, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must not be <see langword="null"/> or empty.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNullOrEmpty([NotNull] string text, [CallerArgumentExpression("text")] string name = null)
        {
            if (!string.IsNullOrEmpty(text))
                return;

            Throw.ArgumentExceptionForIsNotNullOrEmpty(text, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must be <see langword="null"/> or whitespace.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="text"/> is neither <see langword="null"/> nor whitespace.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNullOrWhiteSpace(string text, [CallerArgumentExpression("text")] string name = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            Throw.ArgumentExceptionForIsNullOrWhiteSpace(text, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must not be <see langword="null"/> or whitespace.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="text"/> is <see langword="null"/> or whitespace.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNullOrWhiteSpace([NotNull] string text, [CallerArgumentExpression("text")] string name = null)
        {
            if (!string.IsNullOrWhiteSpace(text))
                return;

            Throw.ArgumentExceptionForIsNotNullOrWhiteSpace(text, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must be empty.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="text"/> is empty.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty(string text, [CallerArgumentExpression("text")] string name = null)
        {
            if (text.Length == 0)
                return;

            Throw.ArgumentExceptionForIsEmpty(text, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must not be empty.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="text"/> is empty.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty(string text, [CallerArgumentExpression("text")] string name = null)
        {
            if (text.Length != 0)
                return;

            Throw.ArgumentExceptionForIsNotEmpty(name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must be whitespace.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="text"/> is neither <see langword="null"/> nor whitespace.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsWhiteSpace(string text, [CallerArgumentExpression("text")] string name = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            Throw.ArgumentExceptionForIsWhiteSpace(text, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must not be <see langword="null"/> or whitespace.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="text"/> is <see langword="null"/> or whitespace.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotWhiteSpace(string text, [CallerArgumentExpression("text")] string name = null)
        {
            if (!string.IsNullOrWhiteSpace(text))
                return;

            Throw.ArgumentExceptionForIsNotWhiteSpace(text, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must have a size of a specified value.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="text"/> is != <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo(string text, int size, [CallerArgumentExpression("text")] string name = null)
        {
            if (text.Length == size)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(text, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must have a size not equal to a specified value.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="text"/> is == <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeNotEqualTo(string text, int size, [CallerArgumentExpression("text")] string name = null)
        {
            if (text.Length != size)
                return;

            Throw.ArgumentExceptionForHasSizeNotEqualTo(text, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must have a size over a specified value.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="text"/> is &lt;= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThan(string text, int size, [CallerArgumentExpression("text")] string name = null)
        {
            if (text.Length > size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThan(text, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must have a size of at least specified value.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="text"/> is &lt; <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThanOrEqualTo(string text, int size, [CallerArgumentExpression("text")] string name = null)
        {
            if (text.Length >= size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThanOrEqualTo(text, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must have a size of less than a specified value.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="text"/> is >= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThan(string text, int size, [CallerArgumentExpression("text")] string name = null)
        {
            if (text.Length < size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThan(text, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="string"/> instance must have a size of less than or equal to a specified value.
        /// </summary>
        /// <param name="text">The input <see cref="string"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="text"/> is > <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo(string text, int size, [CallerArgumentExpression("text")] string name = null)
        {
            if (text.Length <= size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(text, size, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="string"/> instance must have the same size of a destination <see cref="string"/> instance.
        /// </summary>
        /// <param name="source">The source <see cref="string"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="string"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is != the one of <paramref name="destination"/>.</exception>
        /// <remarks>The <see cref="string"/> type is immutable, but the name of this API is kept for consistency with the other overloads.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo(string source, string destination, [CallerArgumentExpression("source")] string name = null)
        {
            if (source.Length == destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="string"/> instance must have a size of less than or equal to that of a destination <see cref="string"/> instance.
        /// </summary>
        /// <param name="source">The source <see cref="string"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="string"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is > the one of <paramref name="destination"/>.</exception>
        /// <remarks>The <see cref="string"/> type is immutable, but the name of this API is kept for consistency with the other overloads.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo(string source, string destination, [CallerArgumentExpression("source")] string name = null)
        {
            if (source.Length <= destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the input index is valid for a given <see cref="string"/> instance.
        /// </summary>
        /// <param name="index">The input index to be used to access <paramref name="text"/>.</param>
        /// <param name="text">The input <see cref="string"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is not valid to access <paramref name="text"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRangeFor(int index, string text, [CallerArgumentExpression("text")] string name = null)
        {
            if ((uint) index < (uint) text.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRangeFor(index, text, name);
        }

        /// <summary>
        /// Asserts that the input index is not valid for a given <see cref="string"/> instance.
        /// </summary>
        /// <param name="index">The input index to be used to access <paramref name="text"/>.</param>
        /// <param name="text">The input <see cref="string"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is valid to access <paramref name="text"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRangeFor(int index, string text, [CallerArgumentExpression("text")] string name = null)
        {
            if ((uint) index >= (uint) text.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRangeFor(index, text, name);
        }
    }
}
