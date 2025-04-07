using Factory._3_AbstractFactory;
using Factory.Shared.Products;

namespace Factory.Tests
{
    public class AbstractFactoryTests
    {
        [Fact]
        public void MetalFurnitureFactory_CreatesMetalChair()
        {
            var factory = new MetalFurnitureFactory();
            var chair = factory.CreateChair();
            Assert.IsType<MetalChair>(chair);
        }

        [Fact]
        public void MetalFurnitureFactory_CreatesMetalTable()
        {
            var factory = new MetalFurnitureFactory();
            var table = factory.CreateTable();
            Assert.IsType<MetalTable>(table);
        }

        [Fact]
        public void WoodenFurnitureFactory_CreatesWoodenChair()
        {
            var factory = new WoodenFurnitureFactory();
            var chair = factory.CreateChair();
            Assert.IsType<WoodenChair>(chair);
        }

        [Fact]
        public void WoodenFurnitureFactory_CreatesWoodenTable()
        {
            var factory = new WoodenFurnitureFactory();
            var table = factory.CreateTable();
            Assert.IsType<WoodenTable>(table);
        }

        [Fact]
        public void FurnitureFactory_MetalAndWoodenFactories_ReturnDifferentTypes()
        {
            var metalFactory = new MetalFurnitureFactory();
            var woodenFactory = new WoodenFurnitureFactory();
            var metalChair = metalFactory.CreateChair();
            var woodenChair = woodenFactory.CreateChair();
            Assert.IsType<MetalChair>(metalChair);
            Assert.IsType<WoodenChair>(woodenChair);
        }
    }
}
