using Newtonsoft.Json;
using System.Xml;

namespace Adapter.Pluggable.Converters
{
    public class XmlToJsonConverter : IDataConverter
    {
        public string Convert(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
