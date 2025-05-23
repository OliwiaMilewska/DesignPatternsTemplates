using Composite.ModernApproach;

namespace Composite.Tests
{
    public class TreeNodeTests
    {
        [Fact]
        public void AddNode_AddsChildToChildrenList()
        {
            var root = new TreeNode<Part> { Node = new Part("Root", 1, 0) };
            var child = new Part("Child", 1, 10.0);
            var childNode = root.Add(child);

            Assert.Single(root.Children);
            Assert.Equal(child, root.Children[0].Node);
        }

        [Fact]
        public void RemoveNode_RemovesCorrectNode()
        {
            var root = new TreeNode<Part> { Node = new Part("Root", 1, 0) };
            var child1 = new Part("Child1", 1, 10.0);
            var child2 = new Part("Child2", 1, 20.0);

            root.Add(child1);
            root.Add(child2);

            root.Remove(child1);
            Assert.Single(root.Children);
            Assert.Equal("Child2", root.Children[0].Node.Name);
        }
    }
}
