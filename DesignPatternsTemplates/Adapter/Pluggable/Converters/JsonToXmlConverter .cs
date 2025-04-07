using Newtonsoft.Json;

namespace Adapter.Pluggable.Converters
{
    public class JsonToXmlConverter : IDataConverter
    {
        public string Convert(string json)
        {
            var doc = JsonConvert.DeserializeXmlNode(json, "Root");
            return doc.OuterXml;
        }
    }

}
