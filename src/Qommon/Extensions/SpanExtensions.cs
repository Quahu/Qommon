using System;

namespace Qommon;

/// <summary>
///     Represents <see cref="Span{T}"/> extensions.
/// </summary>
public static class SpanExtensions
{
    /// <inheritdoc cref="string.GetHashCode(ReadOnlySpan{char},StringComparison)"/>
    /// <remarks>
    ///     Equivalent of calling <see cref="string.GetHashCode(ReadOnlySpan{char},StringComparison)"/>
    /// </remarks>
    public static int GetHashCode(this Span<char> span, StringComparison stringComparison)
    {
        return string.GetHashCode(span, stringComparison);
    }

    /// <inheritdoc cref="string.GetHashCode(ReadOnlySpan{char},StringComparison)"/>
    /// <remarks>
    ///     Equivalent of calling <see cref="string.GetHashCode(ReadOnlySpan{char},StringComparison)"/>
    /// </remarks>
    public static int GetHashCode(this ReadOnlySpan<char> span, StringComparison stringComparison)
    {
        return string.GetHashCode(span, stringComparison);
    }
}
