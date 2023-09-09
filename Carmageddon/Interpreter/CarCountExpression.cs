using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Interpreter
{
    public class CarCountExpression : Expression
    {
        public override void Interpret(InterpreterContext context, SynchronizationContext syncContext, Form2 form)
        {
            if(context.Parameter3 > 0)
            {
                Console.WriteLine("Car count: " + context.Parameter3);
            }
            else
            {
                Console.WriteLine("No cars found!");
            }
        }
    }
}
