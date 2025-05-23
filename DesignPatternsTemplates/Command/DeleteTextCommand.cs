namespace Command
{
    public record DeleteTextCommand(TextEditor Editor, string TextToDelete) : ICommand
    {
        private int? Position { get; set; }
        private bool _executed = false;

        public void Execute()
        {
            var index = Editor.Text.IndexOf(TextToDelete, StringComparison.Ordinal);
            if (index == -1)
                throw new InvalidOperationException("Text to delete not found.");

            Position = index;
            Editor.Delete(index, TextToDelete.Length);
            _executed = true;
        }

        public void Undo()
        {
            if (!_executed || Position == null)
                throw new InvalidOperationException("Cannot undo before execute.");

            Editor.Insert(Position.Value, TextToDelete);
        }
    }
}
