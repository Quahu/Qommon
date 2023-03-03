using System.Threading.Tasks;
using NUnit.Framework;
using Qommon.Collections.ThreadSafe;

namespace Qommon.Tests.Tests.Collections.ThreadSafe;

public abstract class ThreadSafeDictionaryTests : QommonFixture
{
    [Timeout(WaitTimeout)]
    public abstract class ThreadSafeDictionaryFixture : QommonFixture
    {
        protected abstract ThreadSafeDictionary<int, string> CreateDictionary();

        private const int WaitTimeout = 10_000;
        private const int TaskCount = 10_000;

        [Test]
        public void Create_Passes()
        {
            CreateDictionary();
        }

        [Test]
        public void Add_Concurrent_NotCorrupted()
        {
            var dictionary = CreateDictionary();

            var tasks = new Task[TaskCount];
            for (var i = 0; i < TaskCount; i++)
            {
                var localIndex = i;
                tasks[i] = Task.Run(() =>
                {
                    dictionary.Add(localIndex, localIndex.ToString());
                });
            }

            var tasksFinished = Task.WaitAll(tasks, WaitTimeout);
            Assert.IsTrue(tasksFinished);

            Assert.AreEqual(TaskCount, dictionary.Count);
        }

        [Test]
        public void AddRemove_Concurrent_NotCorrupted()
        {
            var dictionary = CreateDictionary();

            var tasks = new Task[TaskCount];
            for (var i = 0; i < TaskCount; i++)
            {
                var localIndex = i;
                tasks[i] = Task.Run(() =>
                {
                    dictionary.Add(localIndex, localIndex.ToString());
                    dictionary.Remove(localIndex);
                });
            }

            var tasksFinished = Task.WaitAll(tasks, WaitTimeout);
            Assert.IsTrue(tasksFinished);

            Assert.AreEqual(0, dictionary.Count);
        }
    }

    [TestFixture]
    public class MonitorThreadSafeDictionaryTests : ThreadSafeDictionaryFixture
    {
        protected override ThreadSafeDictionary<int, string> CreateDictionary()
        {
            return ThreadSafeDictionary.Monitor.Create<int, string>();
        }
    }

    [TestFixture]
    public class ConcurrentThreadSafeDictionaryTests : ThreadSafeDictionaryFixture
    {
        protected override ThreadSafeDictionary<int, string> CreateDictionary()
        {
            return ThreadSafeDictionary.ConcurrentDictionary.Create<int, string>();
        }
    }
}
