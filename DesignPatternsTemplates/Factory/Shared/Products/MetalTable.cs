using Factory.Shared.Interface;

namespace Factory.Shared.Products
{
    public class MetalTable : IFurniture
    {
        public void Create() => Console.WriteLine("Metal Table Created");
        public string GetMaterial() => "Metal";
    }
}
