using Shared.Models.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Forms.Interpreter
{
    public class Surrender : InterpreterExpression
    {
        public override void Interpret(InterpreterContext context, SynchronizationContext syncContext, GamePlayForm form)
        {
            Console.WriteLine("AS CIA");
            form.KillUnits(context.Parameter1);
        }
    }
}
