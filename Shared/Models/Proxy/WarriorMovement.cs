using Shared.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Proxy
{
    public class WarriorMovement : IWarriorMovement
    {
        private Unit unit;
        private Player player;
        private int movementCount;
        private bool gameStart;

        public WarriorMovement(Unit unit, Player player, int movementCount, bool gameStart)
        {
            this.unit = unit;
            this.player = player;
            this.movementCount = movementCount;
            this.gameStart = gameStart;
        }

        public bool CanEnableMovement()
        {
            return unit != null
                && player != null
                && unit.Color == player.Color
                && movementCount > 0
                && gameStart
                && !(unit.GetState() is Stunned);
        }
    }
}
