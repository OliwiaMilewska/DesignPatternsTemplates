using System.Collections.Concurrent;

namespace ObjectPool.Concurrent
{
    public class ConcurrentPool<T> where T : new()
    {
        private readonly ConcurrentBag<T> _availableObjects = new();
        private readonly Func<T> _objectGenerator;
        private int _currentInUse;

        public ConcurrentPool(Func<T> objectGenerator)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _availableObjects = new ConcurrentBag<T>();
            _currentInUse = 0;
        }

        public T? GetObject()
        {
            T item;
            _currentInUse++;

            if (_availableObjects.TryTake(out item))
                return item;

            return _objectGenerator();
        }

        public void ReturnObject(T obj)
        {
            _currentInUse--;
            _availableObjects.Add(obj);
        }


        public int GetAvailable()
        {
            return _availableObjects.Count;
        }

        public int GetInUse()
        {
            return _currentInUse;
        }
    }
}
