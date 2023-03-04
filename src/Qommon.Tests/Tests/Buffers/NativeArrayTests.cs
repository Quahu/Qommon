using NUnit.Framework;
using Qommon.Buffers;

namespace Qommon.Tests.Buffers;

public class NativeArrayTests : QommonFixture
{
    [Test]
    public void Constructor_SpanFilled_ValidMemory()
    {
        var array = new NativeArray<int>(1024);
        try
        {
            array.Span.Fill(42);

            Assert.That(array, Is.All.EqualTo(42));
        }
        finally
        {
            array.Free();
        }
    }
}
