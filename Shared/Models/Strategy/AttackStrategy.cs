using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Strategy
{
    public class AttackStrategy : IEffectStrategy
    {

        public void ApplyEffect(Unit unit)
        { 
            unit.Attack += 50;
            unit.attackRaised = true;
        }

        public string GetName() => "Attack";
    }
}
