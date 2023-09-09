using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Interpreter
{
    public abstract class Expression
    {
        public abstract void Interpret(InterpreterContext context, SynchronizationContext syncContext, Form2 form);

    }
}
