namespace Observer
{
    public class Investor(string name) : IObserver
    {
        public string Name { get; } = name;
        private readonly Dictionary<string, double> _watchlist = new();

        public void AddToWatchlist(string symbol, double targetPrice) =>
            _watchlist[symbol] = targetPrice;

        public void Update(ISubject subject)
        {
            if (subject is not Stock stock || !_watchlist.TryGetValue(stock.Symbol, out var target)) return;

            string reaction = stock.Price <= target
                ? $"BUY: {stock.Symbol} dropped to {stock.Price:C}. BUY signal (target {target:C})"
                : $"INFO: {stock.Symbol} at {stock.Price:C}. Waiting for target {target:C}.";

            Console.WriteLine($"[Investor: {Name}] {reaction}");
        }
    }
}
