using System.Collections;

namespace Iterator
{
    public class DfsIterator<T> : IEnumerator<T>
    {
        private readonly TreeNode<T> _root;
        private readonly Stack<IEnumerator<TreeNode<T>>> _stack = new();

        private TreeNode<T>? _current;

        public DfsIterator(TreeNode<T> root)
        {
            _root = root;
            Reset();
        }

        public T Current => _current!.Value;
        object IEnumerator.Current => Current!;

        public bool MoveNext()
        {
            while (_stack.Count > 0)
            {
                var iterator = _stack.Peek();

                if (iterator.MoveNext())
                {
                    _current = iterator.Current;
                    _stack.Push(_current.Children.GetEnumerator());
                    return true;
                }
                else
                {
                    _stack.Pop();
                }
            }

            return false;
        }

        public void Reset()
        {
            _stack.Clear();
            _stack.Push(new List<TreeNode<T>> { _root }.GetEnumerator());
            _current = null;
        }

        public void Dispose() { }
    }
}
