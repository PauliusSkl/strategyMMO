using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.API.State
{
    public abstract class CarState
    {
        public abstract void HandleStateChange(StateContext context, int health);
    }
}
