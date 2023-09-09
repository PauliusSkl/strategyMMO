using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Facade
{
    // Subsystem class
    public class VisibilityUtils
    {
        // Subsystem method
        public bool IsVisible(bool visibility)
        {
            if (!visibility)
            {
                return false;
            }

            return true;
        }
    }
}
