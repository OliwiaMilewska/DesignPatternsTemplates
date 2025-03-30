using Builder.Product;

namespace Builder.Builders
{
    public class ApartmentBuilder : IBuilder
    {
        private Home _home = new Home();

        public void BuildPartA()
        {
            _home.Add("Part A Apt");
        }

        public void BuildPartB()
        {
            _home.Add("Part B Apt");
        }

        public void BuildPartC()
        {
            _home.Add("Part C Apt");
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
