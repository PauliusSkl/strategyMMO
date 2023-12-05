using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Composite
{
    public class HealthPotion : Item
    {
        public HealthPotion()
        {
            this.Health = 20;
            this.MaxHealth = 20;
        }
    }
}
