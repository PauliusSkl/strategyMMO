using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Proxy
{
    public class WarriorMovementProxy : IWarriorMovement
    {
        private WarriorMovement realMovement;

        public WarriorMovementProxy(WarriorMovement realMovement)
        {
            this.realMovement = realMovement;
        }

        public bool CanEnableMovement()
        {
            return realMovement.CanEnableMovement();
        }
        public bool PerformAdditionalCheck()
        {
            return true; 
        }
    }
}
