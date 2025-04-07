using Adapter.TwoWayAdapter;
using Newtonsoft.Json;
using System.Xml;

namespace Adapter.Tests
{
    public class TwoWayTests
    {
        private readonly JsonXmlAdapter _adapter = new JsonXmlAdapter();

        [Fact]
        public void ConvertToJson_ShouldConvertXmlToJson()
        {
            string xml = "<Person><Name>John</Name><Age>35</Age></Person>";

            string json = _adapter.ConvertToJson(xml);

            Assert.Contains("\"Name\": \"John\"", json);
            Assert.Contains("\"Age\": \"35\"", json);
        }

        [Fact]
        public void ConvertToXml_ShouldConvertJsonToXml()
        {
            string json = "{ \"Person\": { \"Name\": \"Jane\", \"Age\": 28 } }";

            string xml = _adapter.ConvertToXml(json);

            Assert.Contains("<Name>Jane</Name>", xml);
            Assert.Contains("<Age>28</Age>", xml);
        }

        [Fact]
        public void RoundTrip_XmlToJsonAndBack_ShouldPreserveStructure()
        {
            string originalXml = "<Person><Name>Alice</Name><Age>30</Age></Person>";

            string json = _adapter.ConvertToJson(originalXml);
            string backToXml = _adapter.ConvertToXml(json);

            Assert.Contains("<Name>Alice</Name>", backToXml);
            Assert.Contains("<Age>30</Age>", backToXml);
        }

        [Fact]
        public void RoundTrip_JsonToXmlAndBack_ShouldPreserveStructure()
        {
            string originalJson = "{ \"Person\": { \"Name\": \"Bob\", \"Age\": 42 } }";

            string xml = _adapter.ConvertToXml(originalJson);
            string backToJson = _adapter.ConvertToJson(xml);

            Assert.Contains("\"Name\": \"Bob\"", backToJson);
            Assert.Contains("\"Age\": \"42\"", backToJson);
        }

        [Fact]
        public void ConvertToJson_WithEmptyXml_ThrowsException()
        {
            string emptyXml = "";

            Assert.Throws<XmlException>(() => _adapter.ConvertToJson(emptyXml));
        }

        [Fact]
        public void ConvertToXml_WithInvalidJson_ThrowsException()
        {
            string badJson = "{ not valid json }";

            Assert.Throws<JsonReaderException>(() => _adapter.ConvertToXml(badJson));
        }
    }
}
