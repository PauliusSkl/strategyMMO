using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.Command;

namespace Shared.Models
{
    public class CommandInvoker
    {
        private readonly Stack<ICommand> history = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            history.Push(command);
        }

        public void UndoLastCommand()
        {
            if (history.Count > 0)
            {
                ICommand lastCommand = history.Pop();
                lastCommand.Undo();
            }
        }

        public ICommand GetLastCommand()
        {
            if (history.Count > 0)
            {
                return history.Peek();
            }

            return null;
        }
    }

}
