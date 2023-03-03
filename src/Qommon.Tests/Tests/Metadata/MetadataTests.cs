using System.Collections.Generic;
using NUnit.Framework;
using Qommon.Collections.ThreadSafe;
using Qommon.Metadata;

namespace Qommon.Tests.Metadata;

public class MetadataTests : QommonFixture
{
    private class TestMetadata : IMetadata
    {
        public IDictionary<string, object?>? Metadata { get; set; }

        public TestMetadata()
        {
            Metadata = new Dictionary<string, object?>();
        }

        public TestMetadata(IDictionary<string, object?>? metadata)
        {
            Metadata = metadata;
        }

        IDictionary<string, object?>? IMetadata.Metadata
        {
            get => Metadata;
            set => Metadata = value;
        }
    }

    private class TestThreadSafeMetadata : IThreadSafeMetadata
    {
        public IThreadSafeDictionary<string, object?>? Metadata { get; set; }

        public TestThreadSafeMetadata()
        {
            Metadata = ThreadSafeDictionary.Monitor.Create<string, object?>();
        }

        public TestThreadSafeMetadata(IThreadSafeDictionary<string, object?>? metadata)
        {
            Metadata = metadata;
        }

        IThreadSafeDictionary<string, object?>? IThreadSafeMetadata.Metadata
        {
            get => Metadata;
            set => Metadata = value;
        }
    }

    [Test]
    public void EnsureMetadataDictionaryExists_NoMetadata_ReturnsNewMetadata()
    {
        var metadata = new TestMetadata(null);
        metadata.EnsureMetadataDictionaryExists();

        Assert.IsNotNull(metadata.Metadata);
    }

    [Test]
    public void EnsureMetadataDictionaryExists_NoThreadSafeMetadata_ReturnsNewMetadata()
    {
        var metadata = new TestThreadSafeMetadata(null);
        metadata.EnsureMetadataDictionaryExists();

        Assert.IsNotNull(metadata.Metadata);
    }

    [Test]
    public void CopyMetadataTo_Metadata_CopiesItems()
    {
        var metadata = new TestMetadata();
        metadata.SetMetadata("a", 1);
        metadata.SetMetadata("b", 2);
        var target = new TestMetadata(null);
        metadata.CopyMetadataTo(target);

        Assert.IsNotNull(target.Metadata);
        CollectionAssert.AreEquivalent(metadata.Metadata, target.Metadata);
    }

    [Test]
    public void CopyMetadataTo_DictionaryMetadata_CopiesItems()
    {
        var metadata = new TestMetadata();
        metadata.SetMetadata("a", 1);
        metadata.SetMetadata("b", 2);
        var targetDictionary = new Dictionary<string, object?>();
        metadata.CopyMetadataTo(targetDictionary);

        CollectionAssert.AreEquivalent(metadata.Metadata, targetDictionary);
    }
}
