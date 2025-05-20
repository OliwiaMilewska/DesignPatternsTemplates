using Proxy;

IDataService service = new CachingDataServiceProxy(realService: new RealDataService(),cacheDuration: TimeSpan.FromSeconds(5));

Console.WriteLine(service.GetData("select * from users"));
Console.WriteLine(service.GetData("select * from users")); // cache
Thread.Sleep(6000); // wait for cache to be expired
Console.WriteLine(service.GetData("select * from users")); // again usage of real service

Console.ReadKey();