using System.Collections;
namespace Iterator
{
    public class TreeEnumerable<T> : IEnumerable<T>
    {
        private readonly TreeNode<T> _root;
        private readonly TraversalType _type;

        public TreeEnumerable(TreeNode<T> root, TraversalType type)
        {
            _root = root;
            _type = type;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _type switch
            {
                TraversalType.DepthFirst => new DfsIterator<T>(_root),
                TraversalType.BreadthFirst => new BfsIterator<T>(_root),
                _ => throw new NotSupportedException("Unknown traversal type")
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
