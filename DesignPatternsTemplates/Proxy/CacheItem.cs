namespace Proxy
{
    public class CacheItem
    {
        public string Data { get; }
        public DateTime Timestamp { get; }

        public CacheItem(string data, DateTime timestamp)
        {
            Data = data;
            Timestamp = timestamp;
        }
    }
}
