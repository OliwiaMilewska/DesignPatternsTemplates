using Prototype.Prototypes;

namespace Prototype.Tests
{
    public class PrototypePatternTests
    {
        [Fact]
        public void CircleClone_ShouldCreateNewInstance()
        {
            var originalCircle = new Circle { X = 10, Y = 10, Radius = 20, Color = "Red", Id = 1 };

            var clonedCircle = (Circle)originalCircle.Clone();

            Assert.NotSame(originalCircle, clonedCircle); // Ensure different instances
            Assert.Equal(originalCircle.X, clonedCircle.X);
            Assert.Equal(originalCircle.Y, clonedCircle.Y);
            Assert.Equal(originalCircle.Color, clonedCircle.Color);
            Assert.Equal(originalCircle.Id, clonedCircle.Id);
            Assert.Equal(originalCircle.Radius, clonedCircle.Radius);
        }

        [Fact]
        public void RectangleClone_ShouldCreateNewInstance()
        {
            var originalRectangle = new Rectangle { X = 5, Y = 5, Width = 10, Height = 20, Color = "Blue", Id = 2 };

            var clonedRectangle = (Rectangle)originalRectangle.Clone();

            Assert.NotSame(originalRectangle, clonedRectangle);
            Assert.Equal(originalRectangle.X, clonedRectangle.X);
            Assert.Equal(originalRectangle.Y, clonedRectangle.Y);
            Assert.Equal(originalRectangle.Color, clonedRectangle.Color);
            Assert.Equal(originalRectangle.Id, clonedRectangle.Id);
            Assert.Equal(originalRectangle.Width, clonedRectangle.Width);
            Assert.Equal(originalRectangle.Height, clonedRectangle.Height);
        }

        [Fact]
        public void ClonedCircle_ShouldBeIndependentOfOriginal()
        {
            var originalCircle = new Circle { X = 10, Y = 10, Radius = 20, Color = "Red", Id = 1 };

            var clonedCircle = (Circle)originalCircle.Clone();
            originalCircle.Color = "Green";
            originalCircle.Id = 99;

            Assert.NotEqual(originalCircle.Color, clonedCircle.Color);
            Assert.NotEqual(originalCircle.Id, clonedCircle.Id);
        }

        [Fact]
        public void ClonedRectangle_ShouldBeIndependentOfOriginal()
        {
            var originalRectangle = new Rectangle { X = 5, Y = 5, Width = 10, Height = 20, Color = "Blue", Id = 2 };

            var clonedRectangle = (Rectangle)originalRectangle.Clone();
            originalRectangle.Color = "Yellow";
            originalRectangle.Id = 77;

            Assert.NotEqual(originalRectangle.Color, clonedRectangle.Color);
            Assert.NotEqual(originalRectangle.Id, clonedRectangle.Id);
        }
    }
}