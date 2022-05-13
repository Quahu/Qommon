using System.Collections.Generic;
using NUnit.Framework;
using Qommon.Collections.Synchronized;
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

    private class TestSynchronizedMetadata : ISynchronizedMetadata
    {
        public ISynchronizedDictionary<string, object?>? Metadata { get; set; }

        public TestSynchronizedMetadata()
        {
            Metadata = new SynchronizedDictionary<string, object?>();
        }

        public TestSynchronizedMetadata(ISynchronizedDictionary<string, object?>? metadata)
        {
            Metadata = metadata;
        }

        ISynchronizedDictionary<string, object?>? ISynchronizedMetadata.Metadata
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
    public void EnsureMetadataDictionaryExists_NoSynchronizedMetadata_ReturnsNewMetadata()
    {
        var metadata = new TestSynchronizedMetadata(null);
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
