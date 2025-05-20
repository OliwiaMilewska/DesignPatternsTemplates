using Flyweight;

var factory = new FormatFactory();

var normalArial = factory.GetFormat("Arial", 12, false);
var boldArial = factory.GetFormat("Arial", 12, true);
var italicTimes = factory.GetFormat("Times New Roman", 14, false);
var boldTimes = factory.GetFormat("Times New Roman", 14, true);
var reusedArial = factory.GetFormat("Arial", 12, false); // These should reuse the same Arial 12 false format

var characters = new List<FormattedCharacter>
        {
            new FormattedCharacter('H', 0, normalArial),
            new FormattedCharacter('e', 1, normalArial),
            new FormattedCharacter('l', 2, boldArial),
            new FormattedCharacter('l', 3, boldArial),
            new FormattedCharacter('o', 4, reusedArial),
            new FormattedCharacter('W', 5, italicTimes),
            new FormattedCharacter('o', 6, italicTimes),
            new FormattedCharacter('r', 7, boldTimes),
            new FormattedCharacter('l', 8, boldTimes),
            new FormattedCharacter('d', 9, boldTimes)
        };

foreach (var ch in characters)
    ch.Render();


Console.ReadKey();

/*
    "Arial_12_False" is reused 3 times.

    "Arial_12_True" and other formats are created once and reused.

    Only 4 unique flyweights are ever created despite 10 characters.
 */