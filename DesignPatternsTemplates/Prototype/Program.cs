using Prototype.Prototypes;

List<IShape> shapes = new List<IShape>();

Circle circle = new Circle {X = 10, Y = 10, Radius = 20, Color = "Red", Id = 1 };
shapes.Add(circle);

Circle cloneCircle = (Circle)circle.Clone();
shapes.Add(cloneCircle);

Rectangle rectangle = new Rectangle { X = 5, Y = 5, Width = 10, Height = 20, Color = "Blue", Id = 2 };
shapes.Add(rectangle);

Console.WriteLine("Original values:");
foreach (var shape in shapes)
    DisplayValues(shape);

// Changes in first circle
shapes[0].Color = "Green";
shapes[0].Id = 99;

Console.WriteLine("\nAfter modification of the first shape:");
foreach (var shape in shapes)
    DisplayValues(shape);

Console.ReadKey();

# region Helper Methods

static void DisplayValues(IShape shape)
{
    Console.WriteLine("{0} - Color: {1}, X: {2}, Y: {3}, ID: {4}",
        shape.GetType().Name, shape.Color, shape.X, shape.Y, shape.Id);
}

#endregion