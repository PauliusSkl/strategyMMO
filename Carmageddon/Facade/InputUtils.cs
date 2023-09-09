using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Facade
{
    // Subsystem class
    public class InputUtils
    {
        // Subsystem method
        public bool InputIsNotEmpty(ClickInput input)
        {
            if (input != null)
            {
                return true;
            }

            return false;
        }
    }
}
