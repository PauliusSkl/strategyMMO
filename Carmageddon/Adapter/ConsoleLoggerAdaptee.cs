using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Adapter
{
    public class ConsoleLoggerAdaptee
    {
        public void Print(string message)
        {
            Debug.WriteLine(message);
        }

        public void PrintInLine(string message)
        {
            Debug.Write(message);
        }
    }
}
