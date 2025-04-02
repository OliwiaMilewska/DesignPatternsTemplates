namespace ObjectPool.Tests
{
    public class ObjectPoolTests
    {
        // A helper method to create mock objects for testing.
        private DatabaseConnection CreateDatabaseConnection()
        {
            return new DatabaseConnection(Guid.NewGuid());
        }

        [Fact]
        public void GetObject_ShouldCreateNewObject_WhenPoolIsEmpty()
        {
            var pool = new ObjectPool<DatabaseConnection>(() => CreateDatabaseConnection(), 3);

            var conn = pool.GetObject();

            Assert.NotNull(conn);
            Assert.IsType<DatabaseConnection>(conn);
        }

        [Fact]
        public void GetObject_ShouldReturnNull_WhenPoolLimitIsReached()
        {
            var pool = new ObjectPool<DatabaseConnection>(() => CreateDatabaseConnection(), 2);

            var conn1 = pool.GetObject();
            var conn2 = pool.GetObject();

            var conn3 = pool.GetObject();

            Assert.Null(conn3);
        }

        [Fact]
        public void GetObject_ShouldReturnExistingObject_WhenPoolHasAvailableObjects()
        {
            var pool = new ObjectPool<DatabaseConnection>(() => CreateDatabaseConnection(), 3);

            var conn1 = pool.GetObject();
            pool.ReturnObject(conn1);

            var conn2 = pool.GetObject();

            Assert.Same(conn1, conn2);
        }
    }
}