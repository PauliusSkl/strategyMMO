using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Bridge
{
    public class IceElement : Element
    {
        public override void ApplyElement(Unit unit)
        {
            unit.Health += 100;
            unit.MaxHealth += 100;
            unit.Attack -= 30;
            unit.Color = "ice";
        }
    }
}
