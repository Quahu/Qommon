using NUnit.Framework;
using Qommon.Collections.Specialized;

namespace Qommon.Tests.Collections.Specialized;

public class BitVectorTests : QommonFixture
{
    [Order(0)]
    public class BitVector64Tests : QommonFixture
    {
        private BitVector64 vector = new(0b101010101010101010101010101010101010101010101010101010101010101);

        [Test]
        public void IsSetBit()
        {
            for (var i = 0; i < 64; i++)
            {
                Assert.AreEqual(i % 2 == 0, vector.IsSet(i));
            }
        }

        [Test]
        public void SetBit()
        {
            for (var i = 0; i < 64; i++)
            {
                if (i % 2 != 0)
                    vector.Set(i);
            }

            Assert.AreEqual(ulong.MaxValue, vector.Data);
        }

        [Test]
        public void ResetBit()
        {
            for (var i = 0; i < 64; i++)
            {
                if (i % 2 == 0)
                    vector.Reset(i);
            }

            Assert.AreEqual(0, vector.Data);
        }

        [Test]
        public void FlipBit()
        {
            var original = vector.Data;
            for (var i = 0; i < 64; i++)
            {
                vector.Flip(i);
            }

            Assert.AreEqual(~original, vector.Data);
        }

        [Test]
        public new void ToString()
        {
            // tests for leading 0s
            Assert.AreEqual("BitVector64{0101010101010101010101010101010101010101010101010101010101010101}", vector.ToString());
        }
    }

    [Order(1)]
    public class BitVectorATests : QommonFixture
    {
        [Test]
        public void ExpandVector()
        {
            var vector = new BitVectorA();

            // empty
            Assert.AreEqual(0, vector.Data.GetBitLength());

            // 8th bit set
            vector.Set(7);
            Assert.AreEqual(8, vector.Data.GetBitLength());

            // 9th bit set
            vector.Set(8);
            Assert.AreEqual(9, vector.Data.GetBitLength());

            // 9th bit unset, back to 8 bits
            vector.Reset(8);
            Assert.AreEqual(8, vector.Data.GetBitLength());
        }
    }
}