#if NET6_0_OR_GREATER
using System;
using System.Buffers;
using System.Runtime.InteropServices;

namespace Qommon.Buffers;

/// <summary>
///     Represents a <see cref="MemoryManager{T}"/> over unmanaged memory.
/// </summary>
/// <typeparam name="T"> The unmanaged type of elements. </typeparam>
public unsafe class NativeMemoryManager<T> : MemoryManager<T>
    where T : unmanaged
{
    /// <inheritdoc />
    public override Memory<T> Memory => CreateMemory(_elementCount);

    private void* _ptr;
    private readonly int _elementCount;

    /// <summary>
    ///     Instantiates a new <see cref="NativeMemoryManager{T}"/>
    ///     with the specified element count.
    /// </summary>
    /// <param name="elementCount"> The amount of <typeparamref name="T"/> elements. </param>
    /// <param name="zeroed"> Whether the unmanaged memory should be zeroed on allocation. </param>
    public NativeMemoryManager(nuint elementCount, bool zeroed = false)
    {
        var elementSize = (nuint) sizeof(T);
        _ptr = zeroed
            ? NativeMemory.AllocZeroed(elementCount, elementSize)
            : NativeMemory.Alloc(elementCount, elementSize);

        _elementCount = (int) elementCount;
    }

    /// <summary>
    ///     Instantiates a new <see cref="NativeMemoryManager{T}"/>
    ///     with the specified pointer and element count.
    /// </summary>
    /// <param name="ptr"> The pointer to the unmanaged memory. </param>
    /// <param name="elementCount"> The amount of <typeparamref name="T"/> elements. </param>
    public NativeMemoryManager(void* ptr, nuint elementCount)
    {
        _ptr = ptr;
        _elementCount = (int) elementCount;
    }

    /// <inheritdoc />
    public override Span<T> GetSpan()
    {
        return new(_ptr, _elementCount);
    }

    /// <summary>
    ///     Does nothing as the memory is unmanaged.
    /// </summary>
    /// <param name="elementIndex"> The element index. </param>
    /// <returns>
    ///     A <see cref="MemoryHandle"/> with the pointer offset by the given element index.
    /// </returns>
    public override MemoryHandle Pin(int elementIndex = 0)
    {
        return new((T*) _ptr + elementIndex);
    }

    /// <summary>
    ///     Does nothing as the memory is unmanaged.
    /// </summary>
    public override void Unpin()
    { }

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        NativeMemory.Free(_ptr);
        _ptr = null;
    }
}
#endif
