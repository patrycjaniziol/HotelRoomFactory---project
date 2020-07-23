using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HotelRoomFactory
{
    public class CommandManager
    {
        private Stack commandStack = new Stack();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            if(command is UndoableCommand)
            {
                commandStack.Push(command);
            }
        }

        public void Undo()
        {
            if(commandStack.Count > 0)
            {
                UndoableCommand command = (UndoableCommand)commandStack.Pop();
                command.Undo();
            }
        }
    }
}
