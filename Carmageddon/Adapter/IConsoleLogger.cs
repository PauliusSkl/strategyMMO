using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Adapter
{
    public interface IConsoleLogger
    {
        public void LogMessage(string message, bool inline);
    }
}
