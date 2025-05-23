namespace Composite.ModernApproach
{
    /// <summary>
    /// Car assembly with parts class - COMPOSITE
    /// </summary>
    public class Assembly(string name, int quantity) : IComponent
    {
        public string Name { get; set; } = name;
        public int Quantity { get; set; } = quantity;
        public List<IComponent> Parts { get; } = new();

        public void AddComponent(IComponent component) => Parts.Add(component);

        public double GetCost() => Parts.Sum(c => c.GetCost()) * Quantity;

        public override string ToString() => $"{Name} (x{Quantity}) - {GetCost():C}";

        public int CompareTo(IComponent? other) => ReferenceEquals(this, other) ? 0 : -1;
    }
}
