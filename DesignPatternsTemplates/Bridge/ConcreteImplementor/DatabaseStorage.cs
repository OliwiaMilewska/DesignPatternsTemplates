using Bridge.Implementor;

namespace Bridge.ConcreteImplementor
{
    public class DatabaseStorage : IStorage
    {
        private Dictionary<string, object> _db = new Dictionary<string, object>();

        public void Save(string key, object data)
        {
            _db[key] = data;
            Console.WriteLine($"[Database] Saved {key}: {data}");
        }

        public object Find(string key)
        {
            _db.TryGetValue(key, out var data);
            Console.WriteLine($"[Database] Found {key}: {data}");
            return data;
        }

        public void Delete(string key)
        {
            if (_db.Remove(key))
                Console.WriteLine($"[Database] Deleted {key}");
            else
                Console.WriteLine($"[Database] {key} not found");
        }
    }
}
