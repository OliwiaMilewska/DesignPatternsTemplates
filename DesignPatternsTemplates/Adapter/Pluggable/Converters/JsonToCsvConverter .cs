using Newtonsoft.Json;

namespace Adapter.Pluggable.Converters
{
    public class JsonToCsvConverter : IDataConverter
    {
        public string Convert(string json)
        {
            var table = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            if (table == null || table.Count == 0)
                return "";

            var headers = string.Join(",", table[0].Keys);
            var rows = new List<string> { headers };

            foreach (var row in table)
            {
                var values = string.Join(",", row.Values);
                rows.Add(values);
            }

            return string.Join("\n", rows);
        }
    }
}
