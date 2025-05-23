namespace Command
{
    public record InsertTextCommand(TextEditor Editor, string TextToInsert) : ICommand
    {
        private int Position { get; } = Editor.Text.Length;

        public void Execute() => Editor.Insert(Position, TextToInsert);

        public void Undo() => Editor.Delete(Position, TextToInsert.Length);
    }
}
