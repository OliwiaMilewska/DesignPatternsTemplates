using Adapter.Pluggable.Converters;

namespace Adapter.Pluggable
{
    public class PluggableAdapter
    {
        private ConversionType _activeType;

        public void SetActive(ConversionType type)
        {
            _activeType = type;
        }

        public string Convert(string input)
        {
            IDataConverter converter = _activeType switch
            {
                ConversionType.JsonToXml => new JsonToXmlConverter(),
                ConversionType.XmlToJson => new XmlToJsonConverter(),
                ConversionType.CsvToJson => new CsvToJsonConverter(),
                ConversionType.JsonToCsv => new JsonToCsvConverter(),
                _ => throw new InvalidOperationException("Unsupported conversion type")
            };

            return converter.Convert(input);
        }
    }
}
