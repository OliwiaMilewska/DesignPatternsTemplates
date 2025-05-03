namespace Singleton._1_Naive
{
    // Naive Singleton
    public sealed class NaiveSingleton
    {
        /// <summary>
        /// Single instance of class Singleton
        /// </summary>
        private static NaiveSingleton? _instance;

        /// <summary>
        /// Private constructor
        /// </summary>
        private NaiveSingleton() { }

        public static NaiveSingleton GetInstance() => _instance ??= new NaiveSingleton();
    }
}
