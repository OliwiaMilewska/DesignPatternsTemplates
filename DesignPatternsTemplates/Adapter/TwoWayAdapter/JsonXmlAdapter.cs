using Newtonsoft.Json;
using System.Xml;

namespace Adapter.TwoWayAdapter
{
    public class JsonXmlAdapter : IJsonConverter, IXmlConverter
    {
        // Convert XML → JSON
        public string ConvertToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        // Convert JSON → XML
        public string ConvertToXml(string json)
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "Root");
            return doc.OuterXml;
        }
    }
}
