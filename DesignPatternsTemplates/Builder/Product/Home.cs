namespace Builder.Product
{
    public class Home
    {
        private List<object> _parts = [];

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public string ListParts()
        {
            if (_parts.Count == 0)
                return "No parts built yet.\n";

            return "Product parts: " + string.Join(", ", _parts) + "\n";
        }
    }
}
