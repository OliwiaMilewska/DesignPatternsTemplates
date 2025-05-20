namespace Bridge.Implementor
{
    public interface IStorage
    {
        void Save(string key, object data);
        object Find(string key);
        void Delete(string key);
    }
}
