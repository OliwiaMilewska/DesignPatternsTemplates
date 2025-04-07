using Factory._2_FactoryMethod.Products;
using Factory._2_FactoryMethod;
using Factory.Shared.Products;

namespace Factory.Tests
{
    public class FactoryMethodTests
    {
        [Fact]
        public void MetalTableFactory_CreatesMetalTable()
        {
            FurnitureFactoryMethod factory = new MetalTableFactory();
            var product = factory.CreateFurniture();

            Assert.IsType<MetalTable>(product);
            Assert.Equal("Metal", product.GetMaterial());
        }

        [Fact]
        public void WoodenChairFactory_CreatesWoodenChair()
        {
            FurnitureFactoryMethod factory = new WoodenChairFactory();
            var product = factory.CreateFurniture();

            Assert.IsType<WoodenChair>(product);
            Assert.Equal("Wood", product.GetMaterial());
        }

        [Fact]
        public void MetalChairFactory_CreatesMetalChair()
        {
            FurnitureFactoryMethod factory = new MetalChairFactory();
            var product = factory.CreateFurniture();

            Assert.IsType<MetalChair>(product);
            Assert.Equal("Metal", product.GetMaterial());
        }

        [Fact]
        public void WoodenTableFactory_CreatesWoodenTable()
        {
            FurnitureFactoryMethod factory = new WoodenTableFactory();
            var product = factory.CreateFurniture();

            Assert.IsType<WoodenTable>(product);
            Assert.Equal("Wood", product.GetMaterial());
        }
    }
}
