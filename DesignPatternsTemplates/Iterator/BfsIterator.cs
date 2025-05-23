using System.Collections;

namespace Iterator
{
    public class BfsIterator<T> : IEnumerator<T>
    {
        private readonly TreeNode<T> _root;
        private readonly Queue<TreeNode<T>> _queue = new();
        private TreeNode<T>? _current;

        public BfsIterator(TreeNode<T> root)
        {
            _root = root;
            Reset();
        }

        public T Current => _current!.Value;
        object IEnumerator.Current => Current!;
        public bool MoveNext()
        {
            if (_queue.Count == 0) return false;

            _current = _queue.Dequeue();

            foreach (var child in _current.Children)
                _queue.Enqueue(child);

            return true;
        }

        public void Reset()
        {
            _queue.Clear();
            _queue.Enqueue(_root);
            _current = null;
        }

        public void Dispose() { }
    }

}
