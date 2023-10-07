using Shared.Models.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.AbstractUnitFactory
{
    public class UpgradedUnitFactory : UnitFactory
    {
        public Unit CreateArcher(string color, int x, int y)
        {
            return new ArcherBuilder()
                 .SetHealth(50)
                 .SetMaxHealth(50)
                 .SetAttack(100)
                 .SetRange(2)
                 .SetSpeed(3)
                 .SetKills(2)
                 .SetUpgraded(true)
                 .SetPosition(x, y)
                 .SetType("Archer")
                 .SetColor(color)
                 .Build();
        }

        public Unit CreateWarrior(string color, int x, int y)
        {
            return new WarriorBuilder()
                 .SetHealth(300)
                 .SetMaxHealth(300)
                 .SetAttack(100)
                 .SetRange(1)
                 .SetSpeed(2)
                 .SetKills(2)
                 .SetUpgraded(true)
                 .SetPosition(x, y)
                 .SetType("Warrior")
                 .SetColor(color)
                 .Build();
        }

        public Unit CreateMage(string color, int x, int y)
        {
            return new WarriorBuilder()
                 .SetHealth(50)
                 .SetMaxHealth(50)
                 .SetAttack(200)
                 .SetRange(2)
                 .SetSpeed(2)
                 .SetKills(2)
                 .SetUpgraded(true)
                 .SetPosition(x, y)
                 .SetType("Mage")
                 .SetColor(color)
                 .Build();
        }

        public Unit CreateTank(string color, int x, int y)
        {
            return new TankBuilder()
                 .SetHealth(500)
                 .SetMaxHealth(500)
                 .SetAttack(10)
                 .SetRange(1)
                 .SetSpeed(1)
                 .SetKills(2)
                 .SetUpgraded(true)
                 .SetPosition(x, y)
                 .SetType("Tank")
                 .SetColor(color)
                 .Build();
        }
    }
}
