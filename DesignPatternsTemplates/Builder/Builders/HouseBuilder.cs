using Builder.Product;

namespace Builder.Builders
{
    public class HouseBuilder : IBuilder
    {
        private Home _home = new Home();

        public void BuildPartA()
        {
            _home.Add("Part A House");
        }

        public void BuildPartB()
        {
            _home.Add("Part B House");
        }

        public void BuildPartC()
        {
            _home.Add("Part C House");
        }

        public string GetProduct()
        {
            return _home.ListParts();
        }

        public void Reset()
        {
            _home = new Home();
        }
    }
}
