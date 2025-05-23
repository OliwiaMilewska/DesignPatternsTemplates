namespace Iterator.Tests
{
    public class TreeTraversalTests
    {
        private TreeNode<string> BuildSampleTree()
        {
            // Tree:
            //      A
            //     / \
            //    B   C
            //   / \   \
            //  D   E   F

            var root = new TreeNode<string>("A");
            var b = new TreeNode<string>("B");
            var c = new TreeNode<string>("C");
            var d = new TreeNode<string>("D");
            var e = new TreeNode<string>("E");
            var f = new TreeNode<string>("F");

            root.AddChild(b);
            root.AddChild(c);
            b.AddChild(d);
            b.AddChild(e);
            c.AddChild(f);

            return root;
        }

        [Fact]
        public void DfsTraversal_ShouldReturnCorrectOrder()
        {
            var root = BuildSampleTree();
            var expected = new List<string> { "A", "B", "D", "E", "C", "F" };

            var result = new List<string>();
            foreach (var value in new TreeEnumerable<string>(root, TraversalType.DepthFirst))
            {
                result.Add(value);
            }

            Assert.Equal(expected, result);
        }

        [Fact]
        public void BfsTraversal_ShouldReturnCorrectOrder()
        {
            var root = BuildSampleTree();
            var expected = new List<string> { "A", "B", "C", "D", "E", "F" };

            var result = new List<string>();
            foreach (var value in new TreeEnumerable<string>(root, TraversalType.BreadthFirst))
            {
                result.Add(value);
            }

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Traversal_EmptyTree_ShouldOnlyReturnRoot()
        {
            var root = new TreeNode<string>("X");

            var dfs = new List<string>(new TreeEnumerable<string>(root, TraversalType.DepthFirst));
            var bfs = new List<string>(new TreeEnumerable<string>(root, TraversalType.BreadthFirst));

            Assert.Single(dfs, "X");
            Assert.Single(bfs, "X");
        }
    }
}