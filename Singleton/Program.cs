using Singleton._1_Naive;
using Singleton._2_ThreadSafe;

static void RunNaiveSingletonInstances()
{
    Console.WriteLine("-------- Naive Singleton --------");
    var obj1 = NaiveSingleton.GetInstance();
    var obj2 = NaiveSingleton.GetInstance();

    Console.WriteLine($"Instance 1: {obj1.GetHashCode()}");
    Console.WriteLine($"Instance 2: {obj2.GetHashCode()}");
}

static void RunThreadSafeSingletonTests()
{
    Console.WriteLine("\n-------- Thread Safe Singleton --------");
    ExecuteThreads(GetSingletonInstance, 5);
}

static void RunThreadSafeLazySingletonTests()
{
    Console.WriteLine("\n-------- Thread Safe Lazy Singleton --------");
    ExecuteThreads(GetSingletonLazyInstance, 5);
}

static void ExecuteThreads(ThreadStart method, int threadCount)
{
    var threads = new List<Thread>();
    for (int i = 0; i < threadCount; i++)
        threads.Add(new Thread(method) { Name = $"Thread{i + 1}" });

    foreach (var thread in threads)
    {
        thread.Start();
        thread.Join();
    }
}

static void GetSingletonInstance()
{
    var testValue = new Random().Next(0, 15);
    Console.WriteLine($"Test Value from {Thread.CurrentThread.Name}: {testValue}");
    var obj = ThreadSafeSingleton.GetInstance(testValue);
    Console.WriteLine($"Singleton value from {Thread.CurrentThread.Name}: {obj.GetValue()}");
}

static void GetSingletonLazyInstance()
{
    var testValue = new Random().Next(0, 15);
    Console.WriteLine($"Test Value from {Thread.CurrentThread.Name}: {testValue}");
    var obj = ThreadSafeLazySingleton.GetInstance(testValue);
    Console.WriteLine($"Singleton value from {Thread.CurrentThread.Name}: {obj.GetValue()}");
}

RunNaiveSingletonInstances();
RunThreadSafeSingletonTests();
RunThreadSafeLazySingletonTests();
Console.ReadKey();