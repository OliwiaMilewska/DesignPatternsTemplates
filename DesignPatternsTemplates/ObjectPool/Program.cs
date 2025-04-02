using ObjectPool;

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

Console.ReadKey();