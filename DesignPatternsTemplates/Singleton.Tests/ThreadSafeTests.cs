using Singleton._2_ThreadSafe;
using System.Collections.Concurrent;

namespace Singleton.Tests
{
    public class ThreadSafeTests
    {
        [Fact]
        public void ThreadSafeSingleton_ShouldReturnSameInstance()
        {
            var instance1 = ThreadSafeSingleton.GetInstance(5);
            var instance2 = ThreadSafeSingleton.GetInstance(10);

            Assert.Same(instance1, instance2);
            Assert.Equal(5, instance1.GetValue());
        }

        [Fact]
        public void ThreadSafeSingleton_ShouldBeThreadSafe()
        {
            var bag = new ConcurrentBag<ThreadSafeSingleton>();
            Parallel.For(0, 10, i =>
            {
                bag.Add(ThreadSafeSingleton.GetInstance(i));
            });

            Assert.All(bag, instance => Assert.Same(bag.First(), instance));
        }
    }
}