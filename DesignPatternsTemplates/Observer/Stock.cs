namespace Observer
{
    public class Stock(string symbol, double initialPrice) : ISubject
    {
        public string Symbol { get; } = symbol;
        private double _price = initialPrice;

        public double Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Console.WriteLine($"\n[Stock] {Symbol} price updated to {Price:C}");
                    Notify();
                }
            }
        }

        private readonly List<IObserver> _investors = [];

        public void Attach(IObserver observer)
        {
            _investors.Add(observer);
            Console.WriteLine($"[Stock] Investor subscribed to {Symbol}");
        }

        public void Detach(IObserver observer)
        {
            _investors.Remove(observer);
            Console.WriteLine($"[Stock] Investor unsubscribed from {Symbol}");
        }

        public void Notify() => _investors.ForEach(i => i.Update(this));
    }
}
