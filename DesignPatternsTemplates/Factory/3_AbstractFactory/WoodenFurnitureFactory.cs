using Factory.Shared.Interface;
using Factory.Shared.Products;

namespace Factory._3_AbstractFactory
{
    public class WoodenFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateChair() => new WoodenChair();
        public IFurniture CreateTable() => new WoodenTable();
    }
}
