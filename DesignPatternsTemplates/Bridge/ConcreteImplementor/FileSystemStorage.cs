using Bridge.Implementor;

namespace Bridge.ConcreteImplementor
{
    public class FileSystemStorage : IStorage
    {
        private Dictionary<string, object> _fs = new Dictionary<string, object>();

        public void Save(string key, object data)
        {
            _fs[key] = data;
            Console.WriteLine($"[FileSystem] Saved {key}: {data}");
        }

        public object Find(string key)
        {
            _fs.TryGetValue(key, out var data);
            Console.WriteLine($"[FileSystem] Found {key}: {data}");
            return data;
        }

        public void Delete(string key)
        {
            if (_fs.Remove(key))
                Console.WriteLine($"[FileSystem] Deleted {key}");
            else
                Console.WriteLine($"[FileSystem] {key} not found");
        }
    }
}
