using Factory.Shared.Interface;

namespace Factory._3_AbstractFactory
{
    public interface IFurnitureFactory
    {
        IFurniture CreateChair();
        IFurniture CreateTable();
    }
}
