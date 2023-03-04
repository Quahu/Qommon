using System;
using System.Buffers;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace Qommon.Buffers;

/// <summary>
///     Represents a <see cref="MemoryManager{T}"/> over unmanaged memory.
/// </summary>
/// <typeparam name="T"> The unmanaged type of elements. </typeparam>
public unsafe class NativeMemoryManager<T> : MemoryManager<T>
    where T : unmanaged
{
    /// <inheritdoc/>
    public override Memory<T> Memory => CreateMemory(_elementCount);

    private IntPtr _ptr;
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
        _ptr = (IntPtr) (zeroed
            ? NativeMemory.AllocZeroed(elementCount, elementSize)
            : NativeMemory.Alloc(elementCount, elementSize));

        _elementCount = (int) elementCount;
    }

    /// <summary>
    ///     Instantiates a new <see cref="NativeMemoryManager{T}"/>
    ///     with the specified <see cref="NativeMemory"/> pointer and element count.
    /// </summary>
    /// <param name="ptr"> The pointer to the unmanaged memory. </param>
    /// <param name="elementCount"> The amount of <typeparamref name="T"/> elements. </param>
    public NativeMemoryManager(void* ptr, nuint elementCount)
    {
        _ptr = (IntPtr) ptr;
        _elementCount = (int) elementCount;
    }

    /// <inheritdoc/>
    public override Span<T> GetSpan()
    {
        return new((void*) _ptr, _elementCount);
    }

    /// <summary>
    ///     Does nothing as the memory is unmanaged.
    /// </summary>
    /// <param name="elementIndex"> The element index. </param>
    /// <returns>
    ///     A <see cref="MemoryHandle"/> with the pointer offset by the given element index.
    /// </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override MemoryHandle Pin(int elementIndex = 0)
    {
        return new((T*) _ptr + elementIndex);
    }

    /// <summary>
    ///     Does nothing as the memory is unmanaged.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override void Unpin()
    { }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        var ptr = Interlocked.Exchange(ref _ptr, IntPtr.Zero);
        NativeMemory.Free((void*) ptr);
    }
}
