namespace Flyweight
{
    // Flyweight Factory
    public class FormatFactory
    {
        private readonly Dictionary<string, CharacterFormat> _formats = new();

        public CharacterFormat GetFormat(string fontFamily, int fontSize, bool bold)
        {
            string key = $"{fontFamily}_{fontSize}_{bold}";

            if (!_formats.ContainsKey(key))
            {
                _formats[key] = new CharacterFormat(fontFamily, fontSize, bold);
                Console.WriteLine($"[Factory] Created new format: {key}");
            }

            return _formats[key];
        }
    }
}
