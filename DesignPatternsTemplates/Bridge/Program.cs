using Bridge.Abstraction;
using Bridge.ConcreteImplementor;
using Bridge.Implementor;

Console.WriteLine("Using Database:");
IStorage dbStorage = new DatabaseStorage();
DataManager dataManagerDb = new DataManager(dbStorage);
dataManagerDb.SaveData("user1", "Alice");
dataManagerDb.GetData("user1");
dataManagerDb.DeleteData("user1");

Console.WriteLine("\nUsing FileSystem:");
IStorage fsStorage = new FileSystemStorage();
DataManager dataManagerFs = new DataManager(fsStorage);
dataManagerFs.SaveData("user2", "Bob");
dataManagerFs.GetData("user2");
dataManagerFs.DeleteData("user2");

Console.ReadKey();