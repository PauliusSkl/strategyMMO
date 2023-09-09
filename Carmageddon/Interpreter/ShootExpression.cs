using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Interpreter
{
    public class ShootExpression : Expression
    {
        public override void Interpret(InterpreterContext context, SynchronizationContext syncContext, Form2 form)
        {
            (int x, int y) = ConvertCoordinates(context.Parameter1, context.Parameter2);
            var eventArgs = new MouseEventArgs(new MouseButtons(), 0, x, y, 0);

            syncContext.Post(form.ConsoleShoot, eventArgs);

            Console.WriteLine("\nBOOM!\n");
        }

        private (int, int) ConvertCoordinates(char x, char y)
        {
            int coordX, coordY;
            switch (x)
            {
                case 'A':
                    coordX = 1;
                    break;
                case 'B':
                    coordX = 51;
                    break;
                case 'C':
                    coordX = 101;
                    break;
                case 'D':
                    coordX = 151;
                    break;
                case 'E':
                    coordX = 201;
                    break;
                case 'F':
                    coordX = 251;
                    break;
                case 'G':
                    coordX = 301;
                    break;
                case 'H':
                    coordX = 351;
                    break;
                case 'I':
                    coordX = 401;
                    break;
                case 'J':
                    coordX = 451;
                    break;
                default:
                    coordX = 1;
                    break;
            }
            switch (y)
            {
                case '1':
                    coordY = 1;
                    break;
                case '2':
                    coordY = 51;
                    break;
                case '3':
                    coordY = 101;
                    break;
                case '4':
                    coordY = 151;
                    break;
                case '5':
                    coordY = 201;
                    break;
                case '6':
                    coordY = 251;
                    break;
                case '7':
                    coordY = 301;
                    break;
                case '8':
                    coordY = 351;
                    break;
                case '9':
                    coordY = 401;
                    break;
                case '0':
                    coordY = 451;
                    break;
                default:
                    coordY = 1;
                    break;
            }

            return (coordX, coordY);
        }

    }
}
