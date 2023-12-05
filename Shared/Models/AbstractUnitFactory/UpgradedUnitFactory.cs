using Shared.Models.Builder;

namespace Shared.Models.AbstractUnitFactory
{
    public class UpgradedUnitFactory : UnitFactory
    {
        public Archer CreateArcher(string color, int x, int y)
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
                 .SetArrows(5)
                 .Build();
        }

        public Warrior CreateWarrior(string color, int x, int y)
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

        public Mage CreateMage(string color, int x, int y)
        {
            return new MageBuilder()
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
                 .SetMana(10)
                 .Build();
        }

        public Tank CreateTank(string color, int x, int y)
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
