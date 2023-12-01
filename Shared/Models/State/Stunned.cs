using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.State
{
    public class Stunned : IState
    {
        public void HandleChange(Unit unit)
        {
            if (unit.Health <= 0)
            {
                unit.SetState(new Dead());
            }else if(unit.Health == unit.MaxHealth){
                unit.SetState(new FullHp());
            }
            else if (unit.receivedDamageTimes % 2 != 0)
            {
                unit.SetState(new Damaged());
            }
            else if(unit.receivedDamageTimes == 0)
            {
                unit.SetState(new Damaged());
            }

            return;
        }
    }
}
