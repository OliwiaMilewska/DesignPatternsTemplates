namespace Adapter.Simple
{
    public class StringAdapter : Adaptee, ITarget
    {
        public string Request(int i)
        {
            return $"Result {i * 10} / {i * 2}: {NumericRequest(i * 10, i * 2)}";
        }
    }
}
