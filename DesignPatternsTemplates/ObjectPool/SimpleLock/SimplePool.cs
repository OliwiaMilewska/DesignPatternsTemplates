namespace ObjectPool.SimpleLock
{
    public class SimplePool<T> where T : new()
    {
        private readonly Stack<T> _availableObjects = new();
        private readonly Func<T> _objectGenerator;

        public SimplePool(Func<T> objectGenerator)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _availableObjects = new Stack<T>();
        }

        public T? GetObject()
        {
            lock (_availableObjects)
            {
                if (_availableObjects.Count > 0)
                {
                    return _availableObjects.Pop();
                }
                else
                {
                    return _objectGenerator();
                }
            }
        }

        public void ReturnObject(T obj)
        {
            lock (_availableObjects)
            {
                _availableObjects.Push(obj);
            }
        }
    }
}
