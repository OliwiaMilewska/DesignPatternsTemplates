using Factory.Shared.Interface;
using Factory.Shared.Products;

namespace Factory._3_AbstractFactory
{
    public class MetalFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateChair() => new MetalChair();
        public IFurniture CreateTable() => new MetalTable();
    }
}
