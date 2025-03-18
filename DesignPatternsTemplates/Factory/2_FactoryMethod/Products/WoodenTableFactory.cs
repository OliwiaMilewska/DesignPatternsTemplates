using Factory.Shared.Interface;
using Factory.Shared.Products;

namespace Factory._2_FactoryMethod.Products
{
    public class WoodenTableFactory : FurnitureFactoryMethod
    {
        public override IFurniture CreateFurniture() => new WoodenTable();
    }
}
