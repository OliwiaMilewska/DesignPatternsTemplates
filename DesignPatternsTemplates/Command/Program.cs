using Command;

var editor = new TextEditor();
var manager = new CommandManager();

manager.Execute(new InsertTextCommand(editor, "Hello"));
manager.Execute(new InsertTextCommand(editor, " World"));

Console.WriteLine($"Text: {editor.Text}");

manager.Undo();
Console.WriteLine($"Undo: {editor.Text}");

manager.Redo();
Console.WriteLine($"Redo: {editor.Text}");

manager.Execute(new DeleteTextCommand(editor, " World"));
Console.WriteLine($"Delete: {editor.Text}");

manager.Undo();
Console.WriteLine($"Undo Delete: {editor.Text}");

Console.ReadKey();