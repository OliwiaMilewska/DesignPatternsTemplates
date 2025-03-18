using Factory.Shared.Interface;
using Factory.Shared.Products;

namespace Factory._2_FactoryMethod.Products
{
    public class WoodenChairFactory : FurnitureFactoryMethod
    {
        public override IFurniture CreateFurniture() => new WoodenChair();
    }
}
