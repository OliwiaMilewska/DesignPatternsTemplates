namespace Prototype.Prototypes
{
    // Concrete Prototype: Circle
    public class Circle : IShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }
        public int Radius { get; set; }

        public Circle() { }

        public Circle(Circle source)
        {
            X = source.X;
            Y = source.Y;
            Color = source.Color;
            Id = source.Id;
            Radius = source.Radius;
        }

        public IShape Clone()
        {
            return new Circle(this);
        }
    }
}
