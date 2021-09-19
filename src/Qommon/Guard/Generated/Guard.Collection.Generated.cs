using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Qommon
{
    public static partial class Guard
    {
        /// <summary>
        /// Asserts that the input <see cref="Span{T}"/> instance must be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is != 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty<T>(Span<T> span, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length == 0)
                return;

            Throw.ArgumentExceptionForIsEmpty(span, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Span{T}"/> instance must not be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is == 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty<T>(Span<T> span, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length != 0)
                return;

            Throw.ArgumentExceptionForIsNotEmptyWithSpan<T>(name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Span{T}"/> instance contains no <see langword="null"> items.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="span"/> <see langword="null"> items .</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ContainsNoNullItems<T>(Span<T> span, [CallerArgumentExpression("span")] string name = null)
            where T : class
        {
            var foundNull = false;
            foreach (var item in span)
            {
                if (item == null)
                {
                    foundNull = true;
                    break;
                }
            }

            if (!foundNull)
                return;

            Throw.ArgumentExceptionForIsEmpty(span, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Span{T}"/> instance must have a size of a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is != <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(Span<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length == size)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Span{T}"/> instance must have a size not equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is == <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeNotEqualTo<T>(Span<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length != size)
                return;

            Throw.ArgumentExceptionForHasSizeNotEqualTo(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Span{T}"/> instance must have a size over a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is &lt;= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThan<T>(Span<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length > size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThan(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Span{T}"/> instance must have a size of at least or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is &lt; <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThanOrEqualTo<T>(Span<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length >= size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThanOrEqualTo(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Span{T}"/> instance must have a size of less than a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is >= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThan<T>(Span<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length < size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThan(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Span{T}"/> instance must have a size of less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is > <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(Span<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length <= size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(span, size, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="Span{T}"/> instance must have the same size of a destination <see cref="Span{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is != the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(Span<T> source, Span<T> destination, [CallerArgumentExpression("span")] string name = null)
        {
            if (source.Length == destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="Span{T}"/> instance must have a size of less than or equal to that of a destination <see cref="Span{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="Span{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is > the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(Span<T> source, Span<T> destination, [CallerArgumentExpression("span")] string name = null)
        {
            if (source.Length <= destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the input index is valid for a given <see cref="Span{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="span"/>.</param>
        /// <param name="span">The input <see cref="Span{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is not valid to access <paramref name="span"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRangeFor<T>(int index, Span<T> span, [CallerArgumentExpression("span")] string name = null)
        {
            if ((uint)index < (uint)span.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRangeFor(index, span, name);
        }

        /// <summary>
        /// Asserts that the input index is not valid for a given <see cref="Span{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Span{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="span"/>.</param>
        /// <param name="span">The input <see cref="Span{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is valid to access <paramref name="span"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRangeFor<T>(int index, Span<T> span, [CallerArgumentExpression("span")] string name = null)
        {
            if ((uint)index >= (uint)span.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRangeFor(index, span, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlySpan{T}"/> instance must be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is != 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty<T>(ReadOnlySpan<T> span, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length == 0)
                return;

            Throw.ArgumentExceptionForIsEmpty(span, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlySpan{T}"/> instance must not be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is == 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty<T>(ReadOnlySpan<T> span, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length != 0)
                return;

            Throw.ArgumentExceptionForIsNotEmptyWithReadOnlySpan<T>(name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlySpan{T}"/> instance contains no <see langword="null"> items.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="span"/> <see langword="null"> items .</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ContainsNoNullItems<T>(ReadOnlySpan<T> span, [CallerArgumentExpression("span")] string name = null)
            where T : class
        {
            var foundNull = false;
            foreach (var item in span)
            {
                if (item == null)
                {
                    foundNull = true;
                    break;
                }
            }

            if (!foundNull)
                return;

            Throw.ArgumentExceptionForIsEmpty(span, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlySpan{T}"/> instance must have a size of a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is != <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(ReadOnlySpan<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length == size)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlySpan{T}"/> instance must have a size not equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is == <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeNotEqualTo<T>(ReadOnlySpan<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length != size)
                return;

            Throw.ArgumentExceptionForHasSizeNotEqualTo(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlySpan{T}"/> instance must have a size over a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is &lt;= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThan<T>(ReadOnlySpan<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length > size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThan(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlySpan{T}"/> instance must have a size of at least or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is &lt; <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThanOrEqualTo<T>(ReadOnlySpan<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length >= size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThanOrEqualTo(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlySpan{T}"/> instance must have a size of less than a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is >= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThan<T>(ReadOnlySpan<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length < size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThan(span, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlySpan{T}"/> instance must have a size of less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="span"/> is > <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(ReadOnlySpan<T> span, int size, [CallerArgumentExpression("span")] string name = null)
        {
            if (span.Length <= size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(span, size, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="ReadOnlySpan{T}"/> instance must have the same size of a destination <see cref="ReadOnlySpan{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is != the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(ReadOnlySpan<T> source, Span<T> destination, [CallerArgumentExpression("span")] string name = null)
        {
            if (source.Length == destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="ReadOnlySpan{T}"/> instance must have a size of less than or equal to that of a destination <see cref="ReadOnlySpan{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="ReadOnlySpan{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is > the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(ReadOnlySpan<T> source, Span<T> destination, [CallerArgumentExpression("span")] string name = null)
        {
            if (source.Length <= destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the input index is valid for a given <see cref="ReadOnlySpan{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="span"/>.</param>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is not valid to access <paramref name="span"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRangeFor<T>(int index, ReadOnlySpan<T> span, [CallerArgumentExpression("span")] string name = null)
        {
            if ((uint)index < (uint)span.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRangeFor(index, span, name);
        }

        /// <summary>
        /// Asserts that the input index is not valid for a given <see cref="ReadOnlySpan{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlySpan{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="span"/>.</param>
        /// <param name="span">The input <see cref="ReadOnlySpan{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is valid to access <paramref name="span"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRangeFor<T>(int index, ReadOnlySpan<T> span, [CallerArgumentExpression("span")] string name = null)
        {
            if ((uint)index >= (uint)span.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRangeFor(index, span, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Memory{T}"/> instance must be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is != 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty<T>(Memory<T> memory, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length == 0)
                return;

            Throw.ArgumentExceptionForIsEmpty(memory, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Memory{T}"/> instance must not be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is == 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty<T>(Memory<T> memory, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length != 0)
                return;

            Throw.ArgumentExceptionForIsNotEmpty<Memory<T>>(name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Memory{T}"/> instance contains no <see langword="null"> items.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="memory"/> <see langword="null"> items .</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ContainsNoNullItems<T>(Memory<T> memory, [CallerArgumentExpression("memory")] string name = null)
            where T : class
        {
            var foundNull = false;
            foreach (var item in memory.Span)
            {
                if (item == null)
                {
                    foundNull = true;
                    break;
                }
            }

            if (!foundNull)
                return;

            Throw.ArgumentExceptionForIsEmpty(memory, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Memory{T}"/> instance must have a size of a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is != <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(Memory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length == size)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Memory{T}"/> instance must have a size not equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is == <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeNotEqualTo<T>(Memory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length != size)
                return;

            Throw.ArgumentExceptionForHasSizeNotEqualTo(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Memory{T}"/> instance must have a size over a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is &lt;= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThan<T>(Memory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length > size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThan(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Memory{T}"/> instance must have a size of at least or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is &lt; <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThanOrEqualTo<T>(Memory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length >= size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThanOrEqualTo(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Memory{T}"/> instance must have a size of less than a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is >= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThan<T>(Memory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length < size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThan(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="Memory{T}"/> instance must have a size of less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is > <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(Memory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length <= size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(memory, size, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="Memory{T}"/> instance must have the same size of a destination <see cref="Memory{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is != the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(Memory<T> source, Memory<T> destination, [CallerArgumentExpression("memory")] string name = null)
        {
            if (source.Length == destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="Memory{T}"/> instance must have a size of less than or equal to that of a destination <see cref="Memory{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="Memory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is > the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(Memory<T> source, Memory<T> destination, [CallerArgumentExpression("memory")] string name = null)
        {
            if (source.Length <= destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the input index is valid for a given <see cref="Memory{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="memory"/>.</param>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is not valid to access <paramref name="memory"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRangeFor<T>(int index, Memory<T> memory, [CallerArgumentExpression("memory")] string name = null)
        {
            if ((uint)index < (uint)memory.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRangeFor(index, memory, name);
        }

        /// <summary>
        /// Asserts that the input index is not valid for a given <see cref="Memory{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="Memory{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="memory"/>.</param>
        /// <param name="memory">The input <see cref="Memory{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is valid to access <paramref name="memory"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRangeFor<T>(int index, Memory<T> memory, [CallerArgumentExpression("memory")] string name = null)
        {
            if ((uint)index >= (uint)memory.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRangeFor(index, memory, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlyMemory{T}"/> instance must be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is != 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty<T>(ReadOnlyMemory<T> memory, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length == 0)
                return;

            Throw.ArgumentExceptionForIsEmpty(memory, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlyMemory{T}"/> instance must not be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is == 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty<T>(ReadOnlyMemory<T> memory, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length != 0)
                return;

            Throw.ArgumentExceptionForIsNotEmpty<ReadOnlyMemory<T>>(name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlyMemory{T}"/> instance contains no <see langword="null"> items.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="memory"/> <see langword="null"> items .</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ContainsNoNullItems<T>(ReadOnlyMemory<T> memory, [CallerArgumentExpression("memory")] string name = null)
            where T : class
        {
            var foundNull = false;
            foreach (var item in memory.Span)
            {
                if (item == null)
                {
                    foundNull = true;
                    break;
                }
            }

            if (!foundNull)
                return;

            Throw.ArgumentExceptionForIsEmpty(memory, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlyMemory{T}"/> instance must have a size of a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is != <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(ReadOnlyMemory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length == size)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlyMemory{T}"/> instance must have a size not equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is == <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeNotEqualTo<T>(ReadOnlyMemory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length != size)
                return;

            Throw.ArgumentExceptionForHasSizeNotEqualTo(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlyMemory{T}"/> instance must have a size over a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is &lt;= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThan<T>(ReadOnlyMemory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length > size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThan(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlyMemory{T}"/> instance must have a size of at least or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is &lt; <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThanOrEqualTo<T>(ReadOnlyMemory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length >= size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThanOrEqualTo(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlyMemory{T}"/> instance must have a size of less than a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is >= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThan<T>(ReadOnlyMemory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length < size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThan(memory, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ReadOnlyMemory{T}"/> instance must have a size of less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="memory"/> is > <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(ReadOnlyMemory<T> memory, int size, [CallerArgumentExpression("memory")] string name = null)
        {
            if (memory.Length <= size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(memory, size, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="ReadOnlyMemory{T}"/> instance must have the same size of a destination <see cref="ReadOnlyMemory{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is != the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(ReadOnlyMemory<T> source, Memory<T> destination, [CallerArgumentExpression("memory")] string name = null)
        {
            if (source.Length == destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="ReadOnlyMemory{T}"/> instance must have a size of less than or equal to that of a destination <see cref="ReadOnlyMemory{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="ReadOnlyMemory{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is > the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(ReadOnlyMemory<T> source, Memory<T> destination, [CallerArgumentExpression("memory")] string name = null)
        {
            if (source.Length <= destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the input index is valid for a given <see cref="ReadOnlyMemory{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="memory"/>.</param>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is not valid to access <paramref name="memory"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRangeFor<T>(int index, ReadOnlyMemory<T> memory, [CallerArgumentExpression("memory")] string name = null)
        {
            if ((uint)index < (uint)memory.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRangeFor(index, memory, name);
        }

        /// <summary>
        /// Asserts that the input index is not valid for a given <see cref="ReadOnlyMemory{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ReadOnlyMemory{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="memory"/>.</param>
        /// <param name="memory">The input <see cref="ReadOnlyMemory{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is valid to access <paramref name="memory"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRangeFor<T>(int index, ReadOnlyMemory<T> memory, [CallerArgumentExpression("memory")] string name = null)
        {
            if ((uint)index >= (uint)memory.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRangeFor(index, memory, name);
        }

        /// <summary>
        /// Asserts that the input <see typeparamref="T"/> array instance must be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="array">The input <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="array"/> is != 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty<T>(T[] array, [CallerArgumentExpression("array")] string name = null)
        {
            if (array.Length == 0)
                return;

            Throw.ArgumentExceptionForIsEmpty(array, name);
        }

        /// <summary>
        /// Asserts that the input <see typeparamref="T"/> array instance must not be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="array">The input <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="array"/> is == 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty<T>(T[] array, [CallerArgumentExpression("array")] string name = null)
        {
            if (array.Length != 0)
                return;

            Throw.ArgumentExceptionForIsNotEmpty<T[]>(name);
        }

        /// <summary>
        /// Asserts that the input <see typeparamref="T"/> array instance contains no <see langword="null"> items.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="array">The input <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="array"/> <see langword="null"> items .</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ContainsNoNullItems<T>(T[] array, [CallerArgumentExpression("array")] string name = null)
            where T : class
        {
            var foundNull = false;
            foreach (var item in array)
            {
                if (item == null)
                {
                    foundNull = true;
                    break;
                }
            }

            if (!foundNull)
                return;

            Throw.ArgumentExceptionForIsEmpty(array, name);
        }

        /// <summary>
        /// Asserts that the input <see typeparamref="T"/> array instance must have a size of a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="array">The input <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="array"/> is != <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(T[] array, int size, [CallerArgumentExpression("array")] string name = null)
        {
            if (array.Length == size)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(array, size, name);
        }

        /// <summary>
        /// Asserts that the input <see typeparamref="T"/> array instance must have a size not equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="array">The input <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="array"/> is == <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeNotEqualTo<T>(T[] array, int size, [CallerArgumentExpression("array")] string name = null)
        {
            if (array.Length != size)
                return;

            Throw.ArgumentExceptionForHasSizeNotEqualTo(array, size, name);
        }

        /// <summary>
        /// Asserts that the input <see typeparamref="T"/> array instance must have a size over a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="array">The input <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="array"/> is &lt;= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThan<T>(T[] array, int size, [CallerArgumentExpression("array")] string name = null)
        {
            if (array.Length > size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThan(array, size, name);
        }

        /// <summary>
        /// Asserts that the input <see typeparamref="T"/> array instance must have a size of at least or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="array">The input <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="array"/> is &lt; <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThanOrEqualTo<T>(T[] array, int size, [CallerArgumentExpression("array")] string name = null)
        {
            if (array.Length >= size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThanOrEqualTo(array, size, name);
        }

        /// <summary>
        /// Asserts that the input <see typeparamref="T"/> array instance must have a size of less than a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="array">The input <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="array"/> is >= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThan<T>(T[] array, int size, [CallerArgumentExpression("array")] string name = null)
        {
            if (array.Length < size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThan(array, size, name);
        }

        /// <summary>
        /// Asserts that the input <see typeparamref="T"/> array instance must have a size of less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="array">The input <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="array"/> is > <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(T[] array, int size, [CallerArgumentExpression("array")] string name = null)
        {
            if (array.Length <= size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(array, size, name);
        }

        /// <summary>
        /// Asserts that the source <see typeparamref="T"/> array instance must have the same size of a destination <see typeparamref="T"/> array instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="source">The source <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="destination">The destination <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is != the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(T[] source, T[] destination, [CallerArgumentExpression("array")] string name = null)
        {
            if (source.Length == destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the source <see typeparamref="T"/> array instance must have a size of less than or equal to that of a destination <see typeparamref="T"/> array instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="source">The source <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="destination">The destination <see typeparamref="T"/> array instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is > the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(T[] source, T[] destination, [CallerArgumentExpression("array")] string name = null)
        {
            if (source.Length <= destination.Length)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(source, destination, name);
        }

        /// <summary>
        /// Asserts that the input index is valid for a given <see typeparamref="T"/> array instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="array"/>.</param>
        /// <param name="array">The input <see typeparamref="T"/> array instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is not valid to access <paramref name="array"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRangeFor<T>(int index, T[] array, [CallerArgumentExpression("array")] string name = null)
        {
            if ((uint)index < (uint)array.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRangeFor(index, array, name);
        }

        /// <summary>
        /// Asserts that the input index is not valid for a given <see typeparamref="T"/> array instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see typeparamref="T"/> array instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="array"/>.</param>
        /// <param name="array">The input <see typeparamref="T"/> array instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is valid to access <paramref name="array"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRangeFor<T>(int index, T[] array, [CallerArgumentExpression("array")] string name = null)
        {
            if ((uint)index >= (uint)array.Length)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRangeFor(index, array, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="List{T}"/> instance must be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="list">The input <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="list"/> is != 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty<T>(List<T> list, [CallerArgumentExpression("list")] string name = null)
        {
            if (list.Count == 0)
                return;

            Throw.ArgumentExceptionForIsEmpty((ICollection<T>)list, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="List{T}"/> instance must not be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="list">The input <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="list"/> is == 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty<T>(List<T> list, [CallerArgumentExpression("list")] string name = null)
        {
            if (list.Count != 0)
                return;

            Throw.ArgumentExceptionForIsNotEmpty<List<T>>(name);
        }

        /// <summary>
        /// Asserts that the input <see cref="List{T}"/> instance contains no <see langword="null"> items.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="list">The input <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="list"/> <see langword="null"> items .</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ContainsNoNullItems<T>(List<T> list, [CallerArgumentExpression("list")] string name = null)
            where T : class
        {
            var foundNull = false;
            foreach (var item in list)
            {
                if (item == null)
                {
                    foundNull = true;
                    break;
                }
            }

            if (!foundNull)
                return;

            Throw.ArgumentExceptionForIsEmpty((ICollection<T>)list, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="List{T}"/> instance must have a size of a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="list">The input <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="list"/> is != <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(List<T> list, int size, [CallerArgumentExpression("list")] string name = null)
        {
            if (list.Count == size)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo((ICollection<T>)list, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="List{T}"/> instance must have a size not equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="list">The input <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="list"/> is == <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeNotEqualTo<T>(List<T> list, int size, [CallerArgumentExpression("list")] string name = null)
        {
            if (list.Count != size)
                return;

            Throw.ArgumentExceptionForHasSizeNotEqualTo((ICollection<T>)list, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="List{T}"/> instance must have a size over a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="list">The input <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="list"/> is &lt;= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThan<T>(List<T> list, int size, [CallerArgumentExpression("list")] string name = null)
        {
            if (list.Count > size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThan((ICollection<T>)list, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="List{T}"/> instance must have a size of at least or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="list">The input <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="list"/> is &lt; <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThanOrEqualTo<T>(List<T> list, int size, [CallerArgumentExpression("list")] string name = null)
        {
            if (list.Count >= size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThanOrEqualTo((ICollection<T>)list, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="List{T}"/> instance must have a size of less than a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="list">The input <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="list"/> is >= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThan<T>(List<T> list, int size, [CallerArgumentExpression("list")] string name = null)
        {
            if (list.Count < size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThan((ICollection<T>)list, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="List{T}"/> instance must have a size of less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="list">The input <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="list"/> is > <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(List<T> list, int size, [CallerArgumentExpression("list")] string name = null)
        {
            if (list.Count <= size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo((ICollection<T>)list, size, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="List{T}"/> instance must have the same size of a destination <see cref="List{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is != the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(List<T> source, List<T> destination, [CallerArgumentExpression("list")] string name = null)
        {
            if (source.Count == destination.Count)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo((ICollection<T>)source, destination.Count, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="List{T}"/> instance must have a size of less than or equal to that of a destination <see cref="List{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="List{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is > the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(List<T> source, List<T> destination, [CallerArgumentExpression("list")] string name = null)
        {
            if (source.Count <= destination.Count)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo((ICollection<T>)source, destination.Count, name);
        }

        /// <summary>
        /// Asserts that the input index is valid for a given <see cref="List{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="list"/>.</param>
        /// <param name="list">The input <see cref="List{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is not valid to access <paramref name="list"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRangeFor<T>(int index, List<T> list, [CallerArgumentExpression("list")] string name = null)
        {
            if ((uint)index < (uint)list.Count)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRangeFor(index, (ICollection<T>)list, name);
        }

        /// <summary>
        /// Asserts that the input index is not valid for a given <see cref="List{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="List{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="list"/>.</param>
        /// <param name="list">The input <see cref="List{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is valid to access <paramref name="list"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRangeFor<T>(int index, List<T> list, [CallerArgumentExpression("list")] string name = null)
        {
            if ((uint)index >= (uint)list.Count)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRangeFor(index, (ICollection<T>)list, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ICollection{T}"/> instance must be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is != 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty<T>(ICollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count == 0)
                return;

            Throw.ArgumentExceptionForIsEmpty(collection, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ICollection{T}"/> instance must not be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is == 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty<T>(ICollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count != 0)
                return;

            Throw.ArgumentExceptionForIsNotEmpty<ICollection<T>>(name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ICollection{T}"/> instance contains no <see langword="null"> items.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="collection"/> <see langword="null"> items .</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ContainsNoNullItems<T>(ICollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
            where T : class
        {
            var foundNull = false;
            foreach (var item in collection)
            {
                if (item == null)
                {
                    foundNull = true;
                    break;
                }
            }

            if (!foundNull)
                return;

            Throw.ArgumentExceptionForIsEmpty(collection, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ICollection{T}"/> instance must have a size of a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is != <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(ICollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count == size)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ICollection{T}"/> instance must have a size not equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is == <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeNotEqualTo<T>(ICollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count != size)
                return;

            Throw.ArgumentExceptionForHasSizeNotEqualTo(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ICollection{T}"/> instance must have a size over a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is &lt;= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThan<T>(ICollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count > size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThan(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ICollection{T}"/> instance must have a size of at least or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is &lt; <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThanOrEqualTo<T>(ICollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count >= size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThanOrEqualTo(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ICollection{T}"/> instance must have a size of less than a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is >= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThan<T>(ICollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count < size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThan(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="ICollection{T}"/> instance must have a size of less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is > <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(ICollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count <= size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(collection, size, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="ICollection{T}"/> instance must have the same size of a destination <see cref="ICollection{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is != the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(ICollection<T> source, ICollection<T> destination, [CallerArgumentExpression("collection")] string name = null)
        {
            if (source.Count == destination.Count)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination.Count, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="ICollection{T}"/> instance must have a size of less than or equal to that of a destination <see cref="ICollection{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="ICollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is > the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(ICollection<T> source, ICollection<T> destination, [CallerArgumentExpression("collection")] string name = null)
        {
            if (source.Count <= destination.Count)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination.Count, name);
        }

        /// <summary>
        /// Asserts that the input index is valid for a given <see cref="ICollection{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="collection"/>.</param>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is not valid to access <paramref name="collection"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRangeFor<T>(int index, ICollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
        {
            if ((uint)index < (uint)collection.Count)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRangeFor(index, collection, name);
        }

        /// <summary>
        /// Asserts that the input index is not valid for a given <see cref="ICollection{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="ICollection{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="collection"/>.</param>
        /// <param name="collection">The input <see cref="ICollection{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is valid to access <paramref name="collection"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRangeFor<T>(int index, ICollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
        {
            if ((uint)index >= (uint)collection.Count)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRangeFor(index, collection, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="IReadOnlyCollection{T}"/> instance must be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is != 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsEmpty<T>(IReadOnlyCollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count == 0)
                return;

            Throw.ArgumentExceptionForIsEmpty(collection, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="IReadOnlyCollection{T}"/> instance must not be empty.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is == 0.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotEmpty<T>(IReadOnlyCollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count != 0)
                return;

            Throw.ArgumentExceptionForIsNotEmpty<IReadOnlyCollection<T>>(name);
        }

        /// <summary>
        /// Asserts that the input <see cref="IReadOnlyCollection{T}"/> instance contains no <see langword="null"> items.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="collection"/> <see langword="null"> items .</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ContainsNoNullItems<T>(IReadOnlyCollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
            where T : class
        {
            var foundNull = false;
            foreach (var item in collection)
            {
                if (item == null)
                {
                    foundNull = true;
                    break;
                }
            }

            if (!foundNull)
                return;

            Throw.ArgumentExceptionForIsEmpty(collection, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="IReadOnlyCollection{T}"/> instance must have a size of a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is != <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(IReadOnlyCollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count == size)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="IReadOnlyCollection{T}"/> instance must have a size not equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is == <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeNotEqualTo<T>(IReadOnlyCollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count != size)
                return;

            Throw.ArgumentExceptionForHasSizeNotEqualTo(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="IReadOnlyCollection{T}"/> instance must have a size over a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is &lt;= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThan<T>(IReadOnlyCollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count > size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThan(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="IReadOnlyCollection{T}"/> instance must have a size of at least or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is &lt; <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeGreaterThanOrEqualTo<T>(IReadOnlyCollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count >= size)
                return;

            Throw.ArgumentExceptionForHasSizeGreaterThanOrEqualTo(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="IReadOnlyCollection{T}"/> instance must have a size of less than a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is >= <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThan<T>(IReadOnlyCollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count < size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThan(collection, size, name);
        }

        /// <summary>
        /// Asserts that the input <see cref="IReadOnlyCollection{T}"/> instance must have a size of less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="size">The target size to test.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="collection"/> is > <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(IReadOnlyCollection<T> collection, int size, [CallerArgumentExpression("collection")] string name = null)
        {
            if (collection.Count <= size)
                return;

            Throw.ArgumentExceptionForHasSizeLessThanOrEqualTo(collection, size, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="IReadOnlyCollection{T}"/> instance must have the same size of a destination <see cref="IReadOnlyCollection{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is != the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeEqualTo<T>(IReadOnlyCollection<T> source, ICollection<T> destination, [CallerArgumentExpression("collection")] string name = null)
        {
            if (source.Count == destination.Count)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination.Count, name);
        }

        /// <summary>
        /// Asserts that the source <see cref="IReadOnlyCollection{T}"/> instance must have a size of less than or equal to that of a destination <see cref="IReadOnlyCollection{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="source">The source <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="destination">The destination <see cref="IReadOnlyCollection{T}"/> instance to check the size for.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentException">Thrown if the size of <paramref name="source"/> is > the one of <paramref name="destination"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HasSizeLessThanOrEqualTo<T>(IReadOnlyCollection<T> source, ICollection<T> destination, [CallerArgumentExpression("collection")] string name = null)
        {
            if (source.Count <= destination.Count)
                return;

            Throw.ArgumentExceptionForHasSizeEqualTo(source, destination.Count, name);
        }

        /// <summary>
        /// Asserts that the input index is valid for a given <see cref="IReadOnlyCollection{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="collection"/>.</param>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is not valid to access <paramref name="collection"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsInRangeFor<T>(int index, IReadOnlyCollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
        {
            if ((uint)index < (uint)collection.Count)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsInRangeFor(index, collection, name);
        }

        /// <summary>
        /// Asserts that the input index is not valid for a given <see cref="IReadOnlyCollection{T}"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of items in the input <see cref="IReadOnlyCollection{T}"/> instance.</typeparam>
        /// <param name="index">The input index to be used to access <paramref name="collection"/>.</param>
        /// <param name="collection">The input <see cref="IReadOnlyCollection{T}"/> instance to use to validate <paramref name="index"/>.</param>
        /// <param name="name">The name of the input parameter being tested.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is valid to access <paramref name="collection"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotInRangeFor<T>(int index, IReadOnlyCollection<T> collection, [CallerArgumentExpression("collection")] string name = null)
        {
            if ((uint)index >= (uint)collection.Count)
                return;

            Throw.ArgumentOutOfRangeExceptionForIsNotInRangeFor(index, collection, name);
        }
    }
}
