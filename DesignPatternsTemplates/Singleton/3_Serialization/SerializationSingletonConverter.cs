using System.Text.Json.Serialization;
using System.Text.Json;

namespace Singleton._3_Serialization
{
    public class SerializationSingletonConverter : JsonConverter<SerializationSingleton>
    {
        public override SerializationSingleton Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int? value = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    var instance = SerializationSingleton.GetInstance();
                    if (value.HasValue)
                        instance.SetValue(value.Value);
                    return instance;
                }

                // We look for "Value" in JSON
                if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "Value")
                {
                    reader.Read();
                    value = reader.GetInt32();
                }
            }

            // If there is no value, return Instance
            return SerializationSingleton.GetInstance();
        }

        public override void Write(Utf8JsonWriter writer, SerializationSingleton value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("Value", value.Value);
            writer.WriteEndObject();
        }
    }
}
