namespace Prototype.Prototypes
{
    // Base Prototype Interface
    public interface IShape
    {
        int X { get; set; }
        int Y { get; set; }
        string Color { get; set; }
        int Id { get; set; }

        IShape Clone();
    }
}
