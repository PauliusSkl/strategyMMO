using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Strategy
{
    public class DebuffEffect : IEffectStrategy
    {
        public void ApplyEffect(Unit unit)
        {
            if (unit.Health - 30 < 0)
            {
                unit.Health = 0;
            }
            else
            {
                unit.Health -= 30;
            }
        }
    }
}
