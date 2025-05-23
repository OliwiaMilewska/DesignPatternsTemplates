using Composite.ModernApproach;
using Assembly = Composite.ModernApproach.Assembly;

namespace Composite.Tests
{
    public class ComponentTests
    {
        [Fact]
        public void Part_GetCost_ReturnsCorrectValue()
        {
            var part = new Part("Wheel", 4, 250.0);
            Assert.Equal(1000.0, part.GetCost());
        }

        [Fact]
        public void Assembly_GetCost_ReturnsSumOfComponents()
        {
            var part1 = new Part("Frame", 1, 2000.0);
            var part2 = new Part("Window", 2, 500.0);
            var assembly = new Assembly("Body", 1);
            assembly.AddComponent(part1);
            assembly.AddComponent(part2);

            var expected = 2000.0 + 1000.0;
            Assert.Equal(expected, assembly.GetCost());
        }

        [Fact]
        public void NestedAssemblies_CalculateTotalCostCorrectly()
        {
            var engine = new Part("Engine", 1, 5000.0);
            var tires = new Part("Tires", 4, 1000.0);

            var body = new Assembly("Body", 1);
            body.AddComponent(new Part("Frame", 1, 2000.0));
            body.AddComponent(new Part("Doors", 4, 1000.0));
            body.AddComponent(new Part("Windows", 6, 500.0));

            var car = new Assembly("Car", 1);
            car.AddComponent(engine);
            car.AddComponent(tires);
            car.AddComponent(body);

            double expected = 5000 + 4000 + 2000 + 4000 + 3000;
            Assert.Equal(expected, car.GetCost());
        }
    }
}