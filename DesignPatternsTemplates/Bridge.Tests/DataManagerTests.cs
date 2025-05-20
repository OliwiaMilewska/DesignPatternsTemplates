using Bridge.Abstraction;
using Bridge.Implementor;
using Moq;

namespace Bridge.Tests
{
    public class DataManagerWithMoqTests
    {
        [Fact]
        public void SaveData_CallsStorageSaveMethod()
        {
            var mockStorage = new Mock<IStorage>();
            var manager = new DataManager(mockStorage.Object);

            string key = "user1";
            string data = "Test Data";

            manager.SaveData(key, data);

            mockStorage.Verify(s => s.Save(key, data), Times.Once);
        }

        [Fact]
        public void GetData_CallsStorageFindMethod_AndReturnsCorrectValue()
        {
            var mockStorage = new Mock<IStorage>();
            var manager = new DataManager(mockStorage.Object);

            string key = "user2";
            string expectedData = "Found Data";

            mockStorage.Setup(s => s.Find(key)).Returns(expectedData);

            var result = manager.GetData(key);

            Assert.Equal(expectedData, result);
            mockStorage.Verify(s => s.Find(key), Times.Once);
        }

        [Fact]
        public void DeleteData_CallsStorageDeleteMethod()
        {
            var mockStorage = new Mock<IStorage>();
            var manager = new DataManager(mockStorage.Object);

            string key = "user3";

            manager.DeleteData(key);

            mockStorage.Verify(s => s.Delete(key), Times.Once);
        }
    }
}