namespace Adapter.Simple
{
    public class StringAdapter : Adaptee, ITarget
    {
        public string Request(int i)
        {
            if (i == 0)
                throw new DivideByZeroException("Can't divide by zero!");

            return $"Result {i * 10} / {i * 2}: {NumericRequest(i * 10, i * 2)}";
        }
    }
}
