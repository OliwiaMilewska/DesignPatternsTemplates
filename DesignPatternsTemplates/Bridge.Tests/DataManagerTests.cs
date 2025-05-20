using Bridge.Abstraction;
using Bridge.ConcreteImplementor;
using Bridge.Implementor;

namespace Bridge.Tests
{
    public class DataManagerTests
    {
        // Fake/mock storage for controlled testing
        private class MockStorage : IStorage
        {
            public Dictionary<string, object> Storage = new();

            public void Save(string key, object data)
            {
                Storage[key] = data;
            }

            public object Find(string key)
            {
                Storage.TryGetValue(key, out var data);
                return data;
            }

            public void Delete(string key)
            {
                Storage.Remove(key);
            }
        }

        [Fact]
        public void SaveData_ShouldStoreDataInStorage()
        {
            var mock = new MockStorage();
            var manager = new DataManager(mock);

            manager.SaveData("user1", "TestData");

            Assert.True(mock.Storage.ContainsKey("user1"));
            Assert.Equal("TestData", mock.Storage["user1"]);
        }

        [Fact]
        public void GetData_ShouldReturnSavedData()
        {
            var mock = new MockStorage();
            mock.Save("user2", "SomeValue");
            var manager = new DataManager(mock);

            var result = manager.GetData("user2");

            Assert.Equal("SomeValue", result);
        }

        [Fact]
        public void DeleteData_ShouldRemoveDataFromStorage()
        {
            var mock = new MockStorage();
            mock.Save("user3", "ToDelete");
            var manager = new DataManager(mock);

            manager.DeleteData("user3");

            Assert.False(mock.Storage.ContainsKey("user3"));
        }

        [Fact]
        public void DataManager_ShouldWorkWithDatabaseStorage()
        {
            var dbStorage = new DatabaseStorage();
            var manager = new DataManager(dbStorage);

            manager.SaveData("dbUser", "Alice");
            var result = manager.GetData("dbUser");

            Assert.Equal("Alice", result);

            manager.DeleteData("dbUser");
            var afterDelete = manager.GetData("dbUser");

            Assert.Null(afterDelete);
        }

        [Fact]
        public void DataManager_ShouldWorkWithFileSystemStorage()
        {
            var fsStorage = new FileSystemStorage();
            var manager = new DataManager(fsStorage);

            manager.SaveData("fsUser", "Bob");
            var result = manager.GetData("fsUser");

            Assert.Equal("Bob", result);

            manager.DeleteData("fsUser");
            var afterDelete = manager.GetData("fsUser");

            Assert.Null(afterDelete);
        }
    }
}