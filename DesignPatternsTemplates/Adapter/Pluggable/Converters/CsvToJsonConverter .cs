using Newtonsoft.Json;

namespace Adapter.Pluggable.Converters
{
    public class CsvToJsonConverter : IDataConverter
    {
        public string Convert(string csv)
        {
            var lines = csv.Split('\n');
            var headers = lines[0].Split(',');

            var rows = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                var values = lines[i].Split(',');

                var row = new Dictionary<string, string>();
                for (int j = 0; j < headers.Length; j++)
                {
                    row[headers[j].Trim()] = values[j].Trim();
                }

                rows.Add(row);
            }

            return JsonConvert.SerializeObject(rows, Formatting.Indented);
        }
    }
}
