using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Visitor
{
    public class FileVisitor : PrintingVisitor
    {
        private string fileName = "carPlacingLog.txt";
        public override void PrintCarInfo(Car car)
        {
            using (var sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine("Car selected: " + car.Health + " " + car.Length + " " + DateTime.Now);
            }
        }
    }
}
