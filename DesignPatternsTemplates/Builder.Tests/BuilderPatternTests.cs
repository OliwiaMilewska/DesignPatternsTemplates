using Builder.Builders;

namespace Builder.Tests
{
    public class BuilderPatternTests
    {
        [Fact]
        public void HouseBuilder_ShouldCreateCorrectProduct()
        {
            var houseBuilder = new HouseBuilder();

            houseBuilder.BuildPartA();
            houseBuilder.BuildPartB();
            houseBuilder.BuildPartC();
            var product = houseBuilder.GetProduct();

            Assert.Contains("Part A House", product);
            Assert.Contains("Part B House", product);
            Assert.Contains("Part C House", product);
        }

        [Fact]
        public void ApartmentBuilder_ShouldCreateCorrectProduct()
        {
            var aptBuilder = new ApartmentBuilder();

            aptBuilder.BuildPartA();
            aptBuilder.BuildPartB();
            aptBuilder.BuildPartC();
            var product = aptBuilder.GetProduct();

            Assert.Contains("Part A Apt", product);
            Assert.Contains("Part B Apt", product);
            Assert.Contains("Part C Apt", product);
        }

        [Fact]
        public void Builder_ShouldResetProduct()
        {
            var houseBuilder = new HouseBuilder();
            houseBuilder.BuildPartA();
            houseBuilder.BuildPartB();

            houseBuilder.Reset();
            var product = houseBuilder.GetProduct();

            Assert.Equal("No parts built yet.\n", product);
        }

        [Fact]
        public void Director_ShouldBuildCompleteHome()
        {
            var houseBuilder = new HouseBuilder();
            var director = new Director(houseBuilder);

            director.BuildHome();
            var product = houseBuilder.GetProduct();

            Assert.Contains("Part A House", product);
            Assert.Contains("Part B House", product);
            Assert.Contains("Part C House", product);
        }

        [Fact]
        public void Director_ShouldChangeBuilderSuccessfully()
        {
            var houseBuilder = new HouseBuilder();
            var aptBuilder = new ApartmentBuilder();
            var director = new Director(houseBuilder);

            director.BuildHome();
            var houseProduct = houseBuilder.GetProduct();
            director.ChangeBuilder(aptBuilder);
            director.BuildHome();
            var aptProduct = aptBuilder.GetProduct();

            Assert.Contains("Part A House", houseProduct);
            Assert.Contains("Part B House", houseProduct);
            Assert.Contains("Part C House", houseProduct);

            Assert.Contains("Part A Apt", aptProduct);
            Assert.Contains("Part B Apt", aptProduct);
            Assert.Contains("Part C Apt", aptProduct);
        }
    }
}