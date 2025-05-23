namespace Command
{
    public class TextEditor
    {
        public string Text { get; private set; } = string.Empty;

        public string Insert(int index, string text)
        {
            Text = Text.Insert(index, text);
            return Text;
        }

        public string Delete(int index, int length)
        {
            var deleted = Text.Substring(index, length);
            Text = Text.Remove(index, length);
            return deleted;
        }
    }
}
