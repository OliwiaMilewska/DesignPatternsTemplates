using Singleton._1_Naive;

namespace Singleton.Tests
{
    public class NaiveTests
    {
        [Fact]
        public void Singleton_ShouldReturnSameInstance()
        {
            var instance1 = NaiveSingleton.GetInstance();
            var instance2 = NaiveSingleton.GetInstance();

            Assert.Same(instance1, instance2);
        }
    }
}
