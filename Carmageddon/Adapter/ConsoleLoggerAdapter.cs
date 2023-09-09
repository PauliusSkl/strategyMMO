using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Adapter
{
    public class ConsoleLoggerAdapter : IConsoleLogger
    {
        private ConsoleLoggerAdaptee _adaptee = new ConsoleLoggerAdaptee();

        public void LogMessage(string message, bool inline)
        {
            Debug.WriteLine("Logging messsge: ");
            if (inline)
                _adaptee.PrintInLine(message);
            else
                _adaptee.Print(message);
        }
    }
}
