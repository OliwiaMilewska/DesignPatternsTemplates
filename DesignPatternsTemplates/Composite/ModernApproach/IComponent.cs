namespace Composite.ModernApproach
{
    public interface IComponent : IComparable<IComponent>
    {
        string Name { get; set; }
        int Quantity { get; set; }
        double GetCost();
    }
}
