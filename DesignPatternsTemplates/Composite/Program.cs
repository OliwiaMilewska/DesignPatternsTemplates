using Composite.ModernApproach;
using Composite.Simple;

// SIMPLE EXAMPE
//SimpleComposite();

// MORE MODERN APPROACH
AssemblyCar();

Console.ReadKey();

static void SimpleComposite()
{
    var root = new Composite.Simple.Composite("root");
    root.Add(new Leaf("Leaf A"));
    root.Add(new Leaf("Leaf B"));
    root.Display(1);
    Console.WriteLine("\n");

    var comp = new Composite.Simple.Composite("Composite X");
    comp.Add(new Leaf("Leaf XA"));
    comp.Add(new Leaf("Leaf XB"));
    comp.Display(1);
    Console.WriteLine("\n");

    root.Add(comp);
    root.Display(1);
    Console.WriteLine("\n");

    comp.Add(new Leaf("Leaf C"));
    comp.Display(1);
    Console.WriteLine("\n");

    var leaf = new Leaf("Leaf D");
    root.Add(leaf);
    root.Display(1);
    Console.WriteLine("\n");
    root.Remove(leaf);
    root.Display(1);
    Console.WriteLine("\n");
}

static void AssemblyCar()
{
    // Create parts
    var engine = new Part("Engine", 1, 5000.0);
    var tires = new Part("Tires", 4, 1000.0);
    var frame = new Part("Frame", 1, 2000.0);
    var doors = new Part("Doors", 4, 1000.0);
    var windows = new Part("Windows", 6, 500.0);

    // Create body assembly
    var body = new Assembly("Body", 1);
    body.AddComponent(frame);
    body.AddComponent(doors);
    body.AddComponent(windows);

    // Create car assembly
    var car = new Assembly("Car", 1);
    car.AddComponent(engine);
    car.AddComponent(tires);
    car.AddComponent(body);

    // Build tree
    var root = new TreeNode<IComponent> { Node = car };
    var engineNode = root.Add(engine);
    var tiresNode = root.Add(tires);
    var bodyNode = root.Add(body);
    bodyNode.Add(frame);
    bodyNode.Add(doors);
    bodyNode.Add(windows);

    // Display tree
    TreeNode<IComponent>.Display(root, 1);

    // Show total cost
    Console.WriteLine($"\nTotal Car Cost: {car.GetCost():C}");
}