using Factory._1_SimpleFactory;
using Factory.Shared.Products;

namespace Factory.Tests
{
    public class SimpleFactoryTests
    {
        [Fact]
        public void CreateFurniture_ReturnsWoodenChair()
        {
            var furniture = FurnitureSimpleFactory.CreateFurniture(FurnitureType.Chair, MaterialType.Wood);
            Assert.IsType<WoodenChair>(furniture);
        }

        [Fact]
        public void CreateFurniture_ReturnsMetalChair()
        {
            var furniture = FurnitureSimpleFactory.CreateFurniture(FurnitureType.Chair, MaterialType.Metal);
            Assert.IsType<MetalChair>(furniture);
        }

        [Fact]
        public void CreateFurniture_ReturnsWoodenTable()
        {
            var furniture = FurnitureSimpleFactory.CreateFurniture(FurnitureType.Table, MaterialType.Wood);
            Assert.IsType<WoodenTable>(furniture);
        }

        [Fact]
        public void CreateFurniture_ReturnsMetalTable()
        {
            var furniture = FurnitureSimpleFactory.CreateFurniture(FurnitureType.Table, MaterialType.Metal);
            Assert.IsType<MetalTable>(furniture);
        }

        [Fact]
        public void CreateFurniture_InvalidCombination_ThrowsException()
        {
            var invalidFurnitureType = (FurnitureType)999;
            var invalidMaterial = (MaterialType)999;

            Assert.Throws<ArgumentException>(() =>
                FurnitureSimpleFactory.CreateFurniture(invalidFurnitureType, invalidMaterial));
        }
    }
}