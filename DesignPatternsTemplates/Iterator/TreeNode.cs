namespace Iterator
{
    public class TreeNode<T>
    {
        public T Value { get; }
        public List<TreeNode<T>> Children { get; } = new();

        public TreeNode(T value) => Value = value;

        public void AddChild(TreeNode<T> child) => Children.Add(child);

        public IEnumerable<T> GetDfsEnumerable() => new TreeEnumerable<T>(this, TraversalType.DepthFirst);

        public IEnumerable<T> GetBfsEnumerable() => new TreeEnumerable<T>(this, TraversalType.BreadthFirst);

        public void PrintTree(string indent = "", bool last = true)
        {
            Console.Write(indent);
            Console.Write(last ? "└─" : "├─");
            Console.WriteLine(Value);

            for (int i = 0; i < Children.Count; i++)
                Children[i].PrintTree(indent + (last ? "  " : "│ "), i == Children.Count - 1);
        }
    }
}
