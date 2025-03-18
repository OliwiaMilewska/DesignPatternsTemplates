using Factory.Shared.Interface;

namespace Factory.Shared.Products
{
    public class WoodenTable : IFurniture
    {
        public void Create() => Console.WriteLine("Wooden Table Created");
        public string GetMaterial() => "Wood";
    }
}
