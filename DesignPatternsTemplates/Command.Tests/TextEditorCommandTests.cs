namespace Command.Tests
{
    public class TextEditorCommandTests
    {
        [Fact]
        public void InsertTextCommand_AppendsText()
        {
            var editor = new TextEditor();
            var command = new InsertTextCommand(editor, "Hello");

            command.Execute();

            Assert.Equal("Hello", editor.Text);
        }

        [Fact]
        public void InsertTextCommand_Undo_RemovesText()
        {
            var editor = new TextEditor();
            var command = new InsertTextCommand(editor, "Hello");

            command.Execute();
            Assert.Equal("Hello", editor.Text);

            command.Undo();

            Assert.Equal(string.Empty, editor.Text);
        }

        [Fact]
        public void DeleteTextCommand_DeletesFirstOccurrence_BySubstring()
        {
            var editor = new TextEditor();
            editor.Insert(0, "Hello Hello");

            var command = new DeleteTextCommand(editor, "Hello");
            command.Execute();

            Assert.Equal(" Hello", editor.Text);
        }

        [Fact]
        public void DeleteTextCommand_Undo_RestoresDeletedText()
        {
            var editor = new TextEditor();
            editor.Insert(0, "Hello Hello");

            var command = new DeleteTextCommand(editor, "Hello");
            command.Execute();
            command.Undo();

            Assert.Equal("Hello Hello", editor.Text);
        }

        [Fact]
        public void DeleteTextCommand_Throws_WhenTextNotFound()
        {
            var editor = new TextEditor();
            editor.Insert(0, "Hello World");

            var command = new DeleteTextCommand(editor, "XYZ");

            Assert.Throws<InvalidOperationException>(() => command.Execute());
        }

        [Fact]
        public void CommandManager_UndoRedo_WorksCorrectly()
        {
            var editor = new TextEditor();
            var manager = new CommandManager();

            manager.Execute(new InsertTextCommand(editor, "One"));
            manager.Execute(new InsertTextCommand(editor, " Two"));

            Assert.Equal("One Two", editor.Text);

            manager.Undo();
            Assert.Equal("One", editor.Text);

            manager.Redo();
            Assert.Equal("One Two", editor.Text);
        }

        [Fact]
        public void CommandManager_ClearRedoStack_OnNewCommand()
        {
            var editor = new TextEditor();
            var manager = new CommandManager();

            manager.Execute(new InsertTextCommand(editor, "Test"));
            manager.Undo();
            manager.Execute(new InsertTextCommand(editor, "New"));

            Assert.Equal("New", editor.Text);

            manager.Redo();
            Assert.Equal("New", editor.Text);
        }
    }
}