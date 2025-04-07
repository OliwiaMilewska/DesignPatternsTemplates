using Adapter.Simple;

namespace Adapter.Tests
{
    public class SimpleTests
    {
        [Fact]
        public void Request_ReturnsExpectedFormattedResult()
        {
            var adapter = new StringAdapter();
            var result = adapter.Request(5);
            Assert.Equal("Result 50 / 10: 5", result);
        }

        [Theory]
        [InlineData(2, "Result 20 / 4: 5")]
        [InlineData(10, "Result 100 / 20: 5")]
        [InlineData(1, "Result 10 / 2: 5")]
        public void Request_ReturnsCorrectDivision(int input, string expected)
        {
            var adapter = new StringAdapter();
            var result = adapter.Request(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Request_WithZero_ThrowsDivideByZero()
        {
            var adapter = new StringAdapter();
            Assert.Throws<DivideByZeroException>(() => adapter.Request(0));
        }
    }
}
