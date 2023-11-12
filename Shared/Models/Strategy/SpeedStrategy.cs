using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Strategy
{
    public class SpeedStrategy : IEffectStrategy
    {
        public void ApplyEffect(Unit unit)
        {
            //if (!unit.speedRaised)
            //{
            //    unit.Speed += 1;
            //    unit.speedRaised = true;
            //}
            unit.Speed += 1;
            unit.speedRaised = true;
        }

        public string GetName() => "Speed";
    }
}
