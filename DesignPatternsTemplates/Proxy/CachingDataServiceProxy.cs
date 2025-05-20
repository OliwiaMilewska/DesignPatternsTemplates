namespace Proxy
{
    public class CachingDataServiceProxy : IDataService
    {
        private readonly IDataService _realService;
        private readonly Dictionary<string, CacheItem> _cache = new();
        private readonly TimeSpan _cacheDuration;

        public CachingDataServiceProxy(IDataService realService, TimeSpan cacheDuration)
        {
            _realService = realService;
            _cacheDuration = cacheDuration;
        }

        public string GetData(string query)
        {
            if (_cache.TryGetValue(query, out CacheItem item))
            {
                if (DateTime.Now - item.Timestamp < _cacheDuration)
                {
                    Console.WriteLine("[Cache] Returning cached result for: " + query);
                    return item.Data;
                }
                else
                {
                    Console.WriteLine("[Cache] Cache expired for: " + query);
                    _cache.Remove(query);
                }
            }

            var result = _realService.GetData(query);
            _cache[query] = new CacheItem(result, DateTime.Now);
            return result;
        }
    }
}
