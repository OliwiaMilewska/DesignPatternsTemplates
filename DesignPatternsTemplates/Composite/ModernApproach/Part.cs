namespace Composite.ModernApproach
{
    /// <summary>
    /// Car part class - LEAF
    /// </summary>
    public class Part(string name, int quantity, double cost) : IComponent
    {
        public string Name { get; set; } = name;
        public int Quantity { get; set; } = quantity;
        public double Cost { get; set; } = cost;

        public double GetCost() => Cost * Quantity;
        public override string ToString() => $"{Name} (x{Quantity}) - {GetCost():C}";
        public int CompareTo(IComponent? other) => ReferenceEquals(this, other) ? 0 : -1;
    }
}
