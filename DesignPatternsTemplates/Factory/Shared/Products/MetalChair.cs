using Factory.Shared.Interface;

namespace Factory.Shared.Products
{
    public class MetalChair : IFurniture
    {
        public void Create() => Console.WriteLine("Metal Chair Created");
        public string GetMaterial() => "Metal";
    }
}
