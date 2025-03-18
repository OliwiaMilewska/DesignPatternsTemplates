using System.Text.Json.Serialization;

namespace Singleton._3_Serialization
{
    [JsonConverter(typeof(SerializationSingletonConverter))]
    public sealed class SerializationSingleton
    {
        private static readonly Lazy<SerializationSingleton> _instance = new Lazy<SerializationSingleton>(() => new SerializationSingleton());

        public static SerializationSingleton GetInstance() => _instance.Value;

        public int Value { get; private set; }

        private SerializationSingleton()
        {
            Value = 0;
        }

        public void SetValue(int value) => Value = value;
    }
}
