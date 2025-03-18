using Singleton._3_Serialization;
using System.Text.Json;

namespace Singleton.Tests
{
    public class SerializationTests
    {
        [Fact]
        public void Serialization_ShouldReturnSameInstance_AfterDeserialization()
        {
            var originalInstance = SerializationSingleton.GetInstance();
            originalInstance.SetValue(55);

            var deserializedInstance = SerializeAndDeserialize(originalInstance);

            Assert.Same(originalInstance, deserializedInstance);
            Assert.Equal(55, deserializedInstance.Value);
        }

        private SerializationSingleton SerializeAndDeserialize(SerializationSingleton instance)
        {
            using (var memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize(memoryStream, instance);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return JsonSerializer.Deserialize<SerializationSingleton>(memoryStream);
            }
        }
    }
}
