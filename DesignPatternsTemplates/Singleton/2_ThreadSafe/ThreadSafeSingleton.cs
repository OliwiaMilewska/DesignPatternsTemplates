namespace Singleton._2_ThreadSafe
{
    // Thread-Safe Singleton using lock
    public sealed class ThreadSafeSingleton
    {
        /// <summary>
        /// Single instance of class Singleton
        /// </summary>
        private static ThreadSafeSingleton? _instance;

        /// <summary>
        /// Lock for threads to ensure usage of one instance
        /// </summary>
        private static object _lock = new object();

        /// <summary>
        /// Value to update by first thread that will create an instance
        /// </summary>
        private static int _value = 0;

        /// <summary>
        /// Private constructor
        /// </summary>
        private ThreadSafeSingleton() { }

        public static ThreadSafeSingleton GetInstance(int value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    Console.WriteLine($"First ThreadSafeSingleton initialization value: {value}");
                    _instance = new ThreadSafeSingleton();
                    _value = value;
                }
            }
            return _instance;
        }

        public int GetValue() => _value;
    }
}
