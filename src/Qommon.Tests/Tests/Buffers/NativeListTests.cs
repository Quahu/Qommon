using System;
using NUnit.Framework;
using Qommon.Buffers;

namespace Qommon.Tests.Buffers;

public class NativeListTests : QommonFixture
{
    [Test]
    public void Add_Item_ReturnsValidCount()
    {
        var list = new NativeList<int>();
        try
        {
            list.Add(42);

            Assert.AreEqual(1, list.Count);
        }
        finally
        {
            list.Free();
        }
    }

    [Test]
    public void Remove_AddedItem_ReturnsTrue()
    {
        var list = new NativeList<int>();
        try
        {
            list.Add(42);

            Assert.IsTrue(list.Remove(42));
        }
        finally
        {
            list.Free();
        }
    }

    [Test]
    public void Capacity_HigherValue_CopiesElements()
    {
        var list = new NativeList<int>();
        try
        {
            list.Add(42);

            list.Capacity = 16;

            Assert.AreEqual(16, list.Capacity);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(42, list[0]);
        }
        finally
        {
            list.Free();
        }
    }

    [Test]
    public void Insert_ExistingIndex_MovesElements()
    {
        var list = new NativeList<int>();
        try
        {
            list.Add(42);
            list.Insert(0, 1);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(42, list[1]);
        }
        finally
        {
            list.Free();
        }
    }

    [Test]
    public unsafe void Constructor_StackAllocatedPointer_ExpandsBufferWhenExceedingCapacity()
    {
        var bufferPointer = stackalloc int[1];
        var list = new NativeList<int>(bufferPointer, 1);
        try
        {
            list.Add(42);
            list.Add(1);

            Assert.AreNotEqual((IntPtr) bufferPointer, list.Pointer);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(42, list[0]);
            Assert.AreEqual(1, list[1]);
        }
        finally
        {
            list.Free();
        }
    }

    [Test]
    public unsafe void Constructor_Capacity_ExpandsBufferWhenExceedingCapacity()
    {
        var list = new NativeList<int>(1);
        try
        {
            list.Add(42);
            list.Add(1);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(42, list[0]);
            Assert.AreEqual(1, list[1]);
        }
        finally
        {
            list.Free();
        }
    }

    [Test]
    public void CastInt_Short_ReinterpretsCorrectly()
    {
        var list = new NativeList<int>(1);
        try
        {
            list.Add(42);

            Assert.AreEqual(1, list.Capacity);

            var shortList = list.Cast<short>();
            Assert.AreEqual(2, shortList.Capacity);
            Assert.AreEqual(2, shortList.Count);
        }
        finally
        {
            list.Free();
        }
    }
}
