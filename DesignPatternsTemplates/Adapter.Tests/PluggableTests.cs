using Adapter.Pluggable;
using Adapter.Pluggable.Converters;

namespace Adapter.Tests
{
    public class PluggableTests
    {
        [Fact]
        public void CsvToJsonConverter_ShouldConvertCorrectly()
        {
            // Arrange
            var csv = "Name,Age\nAlice,30\nBob,25";
            var converter = new CsvToJsonConverter();

            // Act
            var json = converter.Convert(csv);

            // Assert
            Assert.Contains("\"Name\": \"Alice\"", json);
            Assert.Contains("\"Age\": \"25\"", json);
        }

        [Fact]
        public void JsonToCsvConverter_ShouldConvertCorrectly()
        {
            // Arrange
            var json = "[{\"Name\":\"Alice\",\"Age\":30},{\"Name\":\"Bob\",\"Age\":25}]";
            var converter = new JsonToCsvConverter();

            // Act
            var csv = converter.Convert(json);

            // Assert
            Assert.Contains("Name,Age", csv);
            Assert.Contains("Alice,30", csv);
            Assert.Contains("Bob,25", csv);
        }

        [Fact]
        public void XmlToJsonConverter_ShouldConvertCorrectly()
        {
            // Arrange
            var xml = "<Person><Name>John</Name><Age>45</Age></Person>";
            var converter = new XmlToJsonConverter();

            // Act
            var json = converter.Convert(xml);

            // Assert
            Assert.Contains("\"Name\": \"John\"", json);
            Assert.Contains("\"Age\": \"45\"", json);
        }

        [Fact]
        public void JsonToXmlConverter_ShouldConvertCorrectly()
        {
            // Arrange
            var json = "{ \"Person\": { \"Name\": \"Eve\", \"Age\": 22 } }";
            var converter = new JsonToXmlConverter();

            // Act
            var xml = converter.Convert(json);

            // Assert
            Assert.Contains("<Name>Eve</Name>", xml);
            Assert.Contains("<Age>22</Age>", xml);
        }

        [Fact]
        public void PluggableAdapter_EnumSwitching_WorksCorrectly()
        {
            // Arrange
            var adapter = new PluggableAdapter();
            string csv = "Name,Age\nZoe,27";

            // Act
            adapter.SetActive(ConversionType.CsvToJson);
            string json = adapter.Convert(csv);

            adapter.SetActive(ConversionType.JsonToCsv);
            string backToCsv = adapter.Convert(json);

            // Assert
            Assert.Contains("\"Name\": \"Zoe\"", json);
            Assert.Contains("Zoe,27", backToCsv);
        }
    }
}