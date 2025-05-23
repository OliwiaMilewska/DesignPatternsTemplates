namespace Composite.ModernApproach
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Node { get; set; } = default!;
        public List<TreeNode<T>> Children { get; } = new();

        public TreeNode<T> Add(T child)
        {
            var newNode = new TreeNode<T> { Node = child };
            Children.Add(newNode);
            return newNode;
        }

        public void Remove(T child)
        {
            foreach (var node in Children)
            {
                if (node.Node.CompareTo(child) == 0)
                {
                    Children.Remove(node);
                    return;
                }
            }
        }

        public static void Display(TreeNode<T> node, int indentation)
        {
            var line = new string('-', indentation);
            Console.WriteLine(line + " " + node.Node);
            foreach (var child in node.Children)
            {
                Display(child, indentation + 1);
            }
        }
    }
}
