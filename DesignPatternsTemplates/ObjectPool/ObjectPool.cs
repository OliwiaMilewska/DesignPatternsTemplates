namespace ObjectPool
{
    public class ObjectPool<T> where T : class
    {
        private readonly Stack<T> _availableObjects; // LIFO stack for available objects
        private readonly Func<T> _objectGenerator;   // Function to create new objects
        private readonly int _maxSize;               // Max number of objects in the pool
        private int _currentSize;                    // Current number of objects created

        public ObjectPool(Func<T> objectGenerator, int maxSize)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _availableObjects = new Stack<T>();
            _maxSize = maxSize;
            _currentSize = 0; // Initially, no objects are created
        }

        public T? GetObject()
        {
            if (_availableObjects.Count > 0)
            {
                return _availableObjects.Pop();  // Return an object from the pool if available
            }
            else if (_currentSize < _maxSize)
            {
                _currentSize++; // Increase the number of created objects
                return _objectGenerator(); // Create a new object if the pool size has not been reached
            }
            else
            {
                Console.WriteLine("Pool size limit reached, cannot create more objects.");
                return null;
            }
        }

        public void ReturnObject(T obj)
        {
            if (_availableObjects.Count < _maxSize)
                _availableObjects.Push(obj); // Return an object to the pool if the pool size limit has not been reached
            else
                Console.WriteLine("Object pool is full. Object is discarded."); // If the pool is full, discard the object
        }
    }
}
