using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Visitor
{
    public class DebugVisitor : PrintingVisitor
    {
        public override void PrintCarInfo(Car car)
        {
            Debug.WriteLine("Car selected: " + car.Health + " " + car.Length);
        }
    }
}
