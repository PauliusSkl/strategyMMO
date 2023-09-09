using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Visitor
{
    public class ConsoleVisitor : PrintingVisitor
    {
        public override void PrintCarInfo(Car car)
        {
            Console.WriteLine("Car selected: " + car.Health + " " + car.Length);
        }
    }
}
