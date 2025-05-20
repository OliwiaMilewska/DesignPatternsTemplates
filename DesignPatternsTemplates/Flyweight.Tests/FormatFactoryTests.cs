namespace Flyweight.Tests
{
    public class FormatFactoryTests
    {
        [Fact]
        public void GetFormat_ShouldReturnSameInstance_ForSameProperties()
        {
            var factory = new FormatFactory();

            var format1 = factory.GetFormat("Arial", 12, false);
            var format2 = factory.GetFormat("Arial", 12, false);

            Assert.Same(format1, format2);
        }

        [Fact]
        public void GetFormat_ShouldReturnDifferentInstances_ForDifferentProperties()
        {
            var factory = new FormatFactory();

            var format1 = factory.GetFormat("Arial", 12, false);
            var format2 = factory.GetFormat("Arial", 12, true);
            var format3 = factory.GetFormat("Times New Roman", 12, false);
            var format4 = factory.GetFormat("Arial", 14, false);

            Assert.NotSame(format1, format2);
            Assert.NotSame(format1, format3);
            Assert.NotSame(format1, format4);
            Assert.NotSame(format2, format3);
        }

        [Fact]
        public void CharacterFormat_ShouldStoreCorrectValues()
        {
            var format = new CharacterFormat("Verdana", 10, true);

            Assert.Equal("Verdana", format.FontFamily);
            Assert.Equal(10, format.FontSize);
            Assert.True(format.Bold);
        }
    }
}