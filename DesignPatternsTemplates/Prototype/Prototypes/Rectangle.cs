namespace Prototype.Prototypes
{
    // Concrete Prototype: Rectangle
    public class Rectangle : IShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle() { }

        public Rectangle(Rectangle source)
        {
            X = source.X;
            Y = source.Y;
            Color = source.Color;
            Id = source.Id;
            Width = source.Width;
            Height = source.Height;
        }

        public IShape Clone()
        {
            return new Rectangle(this);
        }
    }
}
