using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.API.State
{
    public class Damaged : CarState
    {
        public override void HandleStateChange(StateContext context, int health)
        {
            if(health == 0)
            {
                context.CarState = new Destroyed();
            }
            else
            {
                context.CarState = new Damaged();
            }
        }
    }
}
