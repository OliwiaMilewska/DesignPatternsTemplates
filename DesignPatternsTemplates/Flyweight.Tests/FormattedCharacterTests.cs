namespace Flyweight.Tests
{
    public class FormattedCharacterTests
    {
        [Fact]
        public void Render_ShouldNotThrow_WithValidData()
        {
            var format = new CharacterFormat("Arial", 12, false);
            var character = new FormattedCharacter('A', 0, format);

            var exception = Record.Exception(() => character.Render());
            Assert.Null(exception);
        }

        [Fact]
        public void FormattedCharacter_ShouldHoldCorrectData()
        {
            var format = new CharacterFormat("Courier New", 11, false);
            var formattedChar = new FormattedCharacter('Z', 42, format);

            Assert.Equal('Z', formattedChar.Character);
            Assert.Equal(42, formattedChar.Position);
        }
    }
}
