// Test class that will do some calculations
namespace ObjectPool.Concurrent
{
    public class MyClass
    {
        public double GetValue(long i)
        {
            return Math.Sqrt(Math.Abs(i));
        }

        public MyClass()
        {
            Console.WriteLine("new MyClass()");
        }
    }
}
