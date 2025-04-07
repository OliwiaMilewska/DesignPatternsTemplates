using Adapter.Pluggable;
using Adapter.Simple;
using Adapter.TwoWayAdapter;

static void TestSimpleAdapter()
{
    Console.WriteLine("------- SimpleAdapter -------");
    Adaptee first = new Adaptee();
    Console.WriteLine(first.NumericRequest(5, 3));

    ITarget second = new StringAdapter();
    Console.WriteLine(second.Request(5));
}

static void TestTwoWayAdapter()
{
    Console.WriteLine("\n------- TwoWayAdapter -------");
    string sampleXml = "<Person><Name>John</Name><Age>30</Age></Person>";
    string sampleJson = "{ \"Person\": { \"Name\": \"Jane\", \"Age\": 25 } }";

    JsonXmlAdapter adapter = new JsonXmlAdapter();

    // XML to JSON
    Console.WriteLine("XML to JSON:");
    string json = adapter.ConvertToJson(sampleXml);
    Console.WriteLine(json);

    // JSON to XML
    Console.WriteLine("\nJSON to XML:");
    string xml = adapter.ConvertToXml(sampleJson);
    Console.WriteLine(xml);
}

static void TestPluggableAdapter()
{
    Console.WriteLine("\n------- PluggableAdapter -------");
    var adapter = new PluggableAdapter();

    string json = "[{ \"Name\": \"Alice\", \"Age\": 30 }, { \"Name\": \"Bob\", \"Age\": 25 }]";
    string csv = "Name,Age\nCharlie,40\nDiana,35";

    adapter.SetActive(ConversionType.CsvToJson);
    Console.WriteLine("CSV to JSON:\n" + adapter.Convert(csv));

    adapter.SetActive(ConversionType.JsonToCsv);
    Console.WriteLine("\nJSON to CSV:\n" + adapter.Convert(json));
}

TestSimpleAdapter();
TestTwoWayAdapter();
TestPluggableAdapter();

Console.ReadKey();