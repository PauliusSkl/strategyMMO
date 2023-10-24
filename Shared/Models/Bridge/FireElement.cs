using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Bridge
{
    public class FireElement : Element
    {
        public override void ApplyElement(Unit unit)
        {
            unit.Health -= 50;
            unit.MaxHealth -= 50;
            unit.Attack += 50;
            unit.Color = "fire";
        }
    }
}
