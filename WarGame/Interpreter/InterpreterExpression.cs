using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame;

namespace Shared.Models.Interpreter
{
    public abstract class InterpreterExpression
    {
        public abstract void Interpret(InterpreterContext context, SynchronizationContext syncContext, GamePlayForm form);
    }
}
