using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Qommon.Tests.Primitives
{
    public class MultiStringTests : QommonFixture
    {
        private static string? GetString(ReadOnlyMemory<char> value)
            => MemoryMarshal.TryGetString(value, out var text, out _, out _) ? text : null;

        [Test]
        public void CountAndIndex()
        {
            MultiString multiString = (string?) null;
            Assert.AreEqual(0, multiString.Count);
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = multiString[0]);

            multiString = "one";
            Assert.AreEqual(1, multiString.Count);
            Assert.AreEqual("one", GetString(multiString[0]));

            multiString = new[] { "one".AsMemory(), "two".AsMemory(), "three".AsMemory() };
            Assert.AreEqual(3, multiString.Count);
            Assert.AreEqual("one", GetString(multiString[0]));
            Assert.AreEqual("two", GetString(multiString[1]));
        }

        [Test]
        public void Enumerate()
        {
            MultiString multiString = (string?) null;
            var enumerator = multiString.GetEnumerator();
            Assert.IsFalse(enumerator.MoveNext());

            multiString = "one";
            enumerator = multiString.GetEnumerator();
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual("one", GetString(enumerator.Current));
            Assert.IsFalse(enumerator.MoveNext());

            multiString = new[] { "one".AsMemory(), "two".AsMemory(), "three".AsMemory() };
            enumerator = multiString.GetEnumerator();
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual("one", GetString(enumerator.Current));
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual("two", GetString(enumerator.Current));
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual("three", GetString(enumerator.Current));
            Assert.IsFalse(enumerator.MoveNext());
        }

        [Test]
        public void Modify()
        {
            var multiString = MultiString.CreateList(out var list);
            list.Add("one".AsMemory());
            Assert.AreEqual(1, multiString.Count);

            list.Add("two".AsMemory());
            Assert.AreEqual(2, multiString.Count);

            list.Clear();
            Assert.AreEqual(0, multiString.Count);
        }
    }
}
