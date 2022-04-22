using System;

namespace Qommon.Pooling;

public readonly partial struct RentedArray<T>
{
    public ArraySegment<T> AsArraySegment()
        => _segment;

    public Memory<T> AsMemory()
        => _segment;

    public Memory<T> AsMemory(int start)
        => _segment.AsMemory(start);

    public Memory<T> AsMemory(int start, int length)
        => _segment.AsMemory(start, length);

    public Span<T> AsSpan()
        => _segment;

    public Span<T> AsSpan(int start)
        => _segment.AsSpan(start);

    public Span<T> AsSpan(int start, int length)
        => _segment.AsSpan(start, length);

    public static implicit operator ArraySegment<T>(RentedArray<T> value)
        => value._segment;

    public static implicit operator Memory<T>(RentedArray<T> value)
        => value._segment;

    public static implicit operator ReadOnlyMemory<T>(RentedArray<T> value)
        => value._segment;

    public static implicit operator Span<T>(RentedArray<T> value)
        => value._segment;

    public static implicit operator ReadOnlySpan<T>(RentedArray<T> value)
        => value._segment;
}