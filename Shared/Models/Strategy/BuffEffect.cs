using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Strategy
{
    public class BuffEffect : IEffectStrategy
    {
        public void ApplyEffect(Unit unit)
        {
            if (unit.Health + 40 > unit.MaxHealth)
            {
                unit.Health = unit.MaxHealth;
            }
            else
            {
                unit.Health += 40;
            }
        }
    }
}
