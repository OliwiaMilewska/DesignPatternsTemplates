namespace Proxy
{
    public class RealDataService : IDataService
    {
        public string GetData(string query)
        {
            Console.WriteLine($"[RealDataService] Processing query: {query}");
            Thread.Sleep(1000); // Simulation of processing large data
            return $"Result for '{query}' at {DateTime.Now}";
        }
    }
}
