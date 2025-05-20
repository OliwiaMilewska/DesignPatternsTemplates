namespace Flyweight
{
    // Flyweight (shared state)
    public class CharacterFormat
    {
        public string FontFamily { get; }
        public int FontSize { get; }
        public bool Bold { get; }

        public CharacterFormat(string fontFamily, int fontSize, bool bold)
        {
            FontFamily = fontFamily;
            FontSize = fontSize;
            Bold = bold;
        }

        public void Apply(string character, int position)
        {
            Console.WriteLine($"[{position}] Char: '{character}' Font: {FontFamily}, Size: {FontSize}, Bold: {Bold}");
        }
    }
}
