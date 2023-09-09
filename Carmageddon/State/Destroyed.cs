using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.State
{
    public class Destroyed : CarState
    {
        public override void HandleStateChange(StateContext context)
        {
            context.CarState = null;
        }
    }
}
