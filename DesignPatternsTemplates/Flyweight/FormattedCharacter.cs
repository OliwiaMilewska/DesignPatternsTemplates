namespace Flyweight
{
    public class FormattedCharacter
    {
        public char Character { get; }
        public int Position { get; }
        private readonly CharacterFormat _format;

        public FormattedCharacter(char character, int position, CharacterFormat format)
        {
            Character = character;
            Position = position;
            _format = format;
        }

        public void Render()
        {
            _format.Apply(Character.ToString(), Position);
        }
    }
}
