using Bridge.Implementor;

namespace Bridge.Abstraction
{
    public class DataManager
    {
        protected IStorage Storage;

        public DataManager(IStorage storage)
        {
            Storage = storage;
        }

        public void SaveData(string key, object data)
        {
            Storage.Save(key, data);
        }

        public object GetData(string key)
        {
            return Storage.Find(key);
        }

        public void DeleteData(string key)
        {
            Storage.Delete(key);
        }
    }
}
