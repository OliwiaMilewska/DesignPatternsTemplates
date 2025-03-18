namespace Singleton._2_ThreadSafe
{
    // Thread-Safe Singleton using Lazy<T>
    public sealed class ThreadSafeLazySingleton
    {
        /// <summary>
        /// Initialization using Lazy<T> guarantees thread safety internally
        /// </summary>
        private static readonly Lazy<ThreadSafeLazySingleton> _instance = new Lazy<ThreadSafeLazySingleton>(() => new ThreadSafeLazySingleton());

        private static int _value = 0;

        private ThreadSafeLazySingleton() { }

        public int GetValue() => _value;

        public static ThreadSafeLazySingleton GetInstance(int value)
        {
            if (_value == 0)
            {
                Console.WriteLine($"First ThreadSafeLazySingleton initialization value: {value}");
                _value = value;
            }

            return _instance.Value;
        }
    }
}
