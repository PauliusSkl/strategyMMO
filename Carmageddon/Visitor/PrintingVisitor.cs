using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Visitor
{
    public abstract class PrintingVisitor
    {
        public abstract void PrintCarInfo(Car car);
    }
}
