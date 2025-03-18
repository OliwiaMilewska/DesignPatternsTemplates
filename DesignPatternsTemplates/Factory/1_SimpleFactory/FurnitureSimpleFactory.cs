using Factory.Shared.Interface;
using Factory.Shared.Products;

namespace Factory._1_SimpleFactory
{
    public enum FurnitureType { Chair, Table }
    public enum MaterialType { Wood, Metal }

    public class FurnitureSimpleFactory
    {
        public static IFurniture CreateFurniture(FurnitureType type, MaterialType material)
        {
            return (type, material) switch
            {
                (FurnitureType.Chair, MaterialType.Wood) => new WoodenChair(),
                (FurnitureType.Chair, MaterialType.Metal) => new MetalChair(),
                (FurnitureType.Table, MaterialType.Wood) => new WoodenTable(),
                (FurnitureType.Table, MaterialType.Metal) => new MetalTable(),
                _ => throw new ArgumentException("Invalid furniture type or material")
            };
        }
    }
}
