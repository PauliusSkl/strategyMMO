using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.State
{
    public abstract class CarState
    {
        public abstract void HandleStateChange(StateContext context);
    }
}
