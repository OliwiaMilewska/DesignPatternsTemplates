using Moq;

namespace Proxy.Tests
{
    public class CachingDataServiceProxyTests
    {
        [Fact]
        public void FirstCall_ShouldInvokeRealService_AndCacheResult()
        {
            var mockService = new Mock<IDataService>();
            mockService.Setup(s => s.GetData("query1")).Returns("real result");

            var proxy = new CachingDataServiceProxy(mockService.Object, TimeSpan.FromSeconds(10));

            var result1 = proxy.GetData("query1");
            var result2 = proxy.GetData("query1");

            Assert.Equal("real result", result1);
            Assert.Equal(result1, result2);
            mockService.Verify(s => s.GetData("query1"), Times.Once);
        }

        [Fact]
        public void CallAfterCacheExpiry_ShouldInvokeRealServiceAgain()
        {
            var mockService = new Mock<IDataService>();
            mockService.SetupSequence(s => s.GetData("query2"))
                       .Returns("first call")
                       .Returns("second call");

            var proxy = new CachingDataServiceProxy(mockService.Object, TimeSpan.FromMilliseconds(5));

            var result1 = proxy.GetData("query2");
            Thread.Sleep(10);
            var result2 = proxy.GetData("query2");

            Assert.Equal("first call", result1);
            Assert.Equal("second call", result2);
            mockService.Verify(s => s.GetData("query2"), Times.Exactly(2));
        }

        [Fact]
        public void DifferentQueries_ShouldCacheSeparately()
        {
            var mockService = new Mock<IDataService>();
            mockService.Setup(s => s.GetData("a")).Returns("result A");
            mockService.Setup(s => s.GetData("b")).Returns("result B");

            var proxy = new CachingDataServiceProxy(mockService.Object, TimeSpan.FromSeconds(10));

            var resultA1 = proxy.GetData("a");
            var resultB1 = proxy.GetData("b");
            var resultA2 = proxy.GetData("a");
            var resultB2 = proxy.GetData("b");

            Assert.Equal("result A", resultA1);
            Assert.Equal("result B", resultB1);
            Assert.Equal(resultA1, resultA2);
            Assert.Equal(resultB1, resultB2);
            mockService.Verify(s => s.GetData("a"), Times.Once);
            mockService.Verify(s => s.GetData("b"), Times.Once);
        }
    }
}