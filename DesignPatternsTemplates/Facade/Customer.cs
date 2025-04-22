namespace Facade
{
    public class Customer
    {
        private string _name;
        public bool HasGoodCredit;

        public Customer(string name, bool hasGoodCredit)
        {
            _name = name;
            HasGoodCredit = hasGoodCredit;
        }

        public string Name => _name;
    }
}
