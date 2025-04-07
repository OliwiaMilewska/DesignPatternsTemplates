using ObjectPool;
using ObjectPool.Concurrent;
using ObjectPool.SimpleLock;

#region SimplePool

static void TestSimplePool()
{
    // Creating an object pool with a limit of 3 connections.
    var pool = new ObjectPool<DatabaseConnection>(() => new DatabaseConnection(Guid.NewGuid()), 3);

    // Getting an object from the pool
    var conn1 = pool.GetObject();
    conn1.Open();

    // Openning two more connections
    var conn2 = pool.GetObject();
    conn2.Open();
    var conn3 = pool.GetObject();
    conn3.Open();

    // Fourth one need to wait to release object
    var conn4 = pool.GetObject();
    conn1.Close();
    pool.ReturnObject(conn1);
    conn4 = pool.GetObject();
    conn4.Open();

    conn2.Close();
    pool.ReturnObject(conn2);
    conn3.Close();
    pool.ReturnObject(conn3);
    conn4.Close();
    pool.ReturnObject(conn4);
}
#endregion

#region SimplePoolWithLock
static void TestSimplePoolWithLock()
{
    var pool = new SimplePool<SimpleObject>(() => new SimpleObject());

    var obj1 = pool.GetObject();
    obj1.Name = "First";
    Show(obj1);

    var obj2 = pool.GetObject();
    obj2.Name = "Second";
    Show(obj2);

    pool.ReturnObject(obj1);

    var obj3 = pool.GetObject();
    obj3.Name = "Third";
    Show(obj3);
}

static void Show(SimpleObject obj)
{
    Console.WriteLine($"{obj.PermanentId} - {obj.Name}");
}
#endregion

#region ConcurrentPool
static void TestConcurrentPool()
{
    CancellationTokenSource cts = new CancellationTokenSource();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    Task.Run(() =>
    {
        if (Console.ReadKey().KeyChar == 'c' || Console.ReadKey().KeyChar == 'C')
            cts.Cancel();
    });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

    ConcurrentPool<MyClass> pool = new ConcurrentPool<MyClass>(() => new MyClass());

    Parallel.For(0, 50000, (i, loopState) =>
    {
        Console.WriteLine($"i = {i}\t Available = {pool.GetAvailable()}\t InUse = {pool.GetInUse()}");

        var mc = pool.GetObject();
        Console.WriteLine($"i = {i}\t Val = {mc.GetValue(i % 10)}\t"); // NEEDS MORE RESOURCES FOR IT

        pool.ReturnObject(mc);
        if (cts.Token.IsCancellationRequested)
            loopState.Stop();

    });

    Console.WriteLine($"Resources in pool needed to serve the jobs: {pool.GetAvailable()}");
    Console.ReadKey();
    cts.Dispose();
}
#endregion

//TestSimplePool();
//TestSimplePoolWithLock();
//TestConcurrentPool();

Console.ReadKey();