namespace ObjectPool.SimpleLock
{
    public class SimpleObject
    {
        static object _lock = new object();
        static int _nextId = 1; //Static so Objects have permanent unique id

        public SimpleObject()
        {
            lock (_lock)
            {
                PermanentId = _nextId++;
            }
        }

        public string? Name { get; set; }

        public int PermanentId { get; private set; }
    }
}
