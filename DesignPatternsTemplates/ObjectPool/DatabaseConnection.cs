namespace ObjectPool
{
    public class DatabaseConnection
    {
        public Guid ConnectionId { get; private set; }

        public DatabaseConnection(Guid id)
        {
            ConnectionId = id;
            Console.WriteLine($"Connection {ConnectionId} created.");
        }

        public void Open() => Console.WriteLine($"Connection {ConnectionId} opened.");

        public void Close() => Console.WriteLine($"Connection {ConnectionId} closed.");
    }
}
