using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class CommandManager
    {
        private readonly Stack<ICommand> _undo = new();
        private readonly Stack<ICommand> _redo = new();

        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        public void Undo()
        {
            if (_undo.TryPop(out var cmd))
            {
                cmd.Undo();
                _redo.Push(cmd);
            }
        }

        public void Redo()
        {
            if (_redo.TryPop(out var cmd))
            {
                cmd.Execute();
                _undo.Push(cmd);
            }
        }
    }
}
