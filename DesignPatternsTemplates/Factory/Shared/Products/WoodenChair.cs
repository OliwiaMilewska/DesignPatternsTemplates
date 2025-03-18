using Factory.Shared.Interface;

namespace Factory.Shared.Products
{
    public class WoodenChair : IFurniture
    {
        public void Create() => Console.WriteLine("Wooden Chair Created");
        public string GetMaterial() => "Wood";
    }

}
