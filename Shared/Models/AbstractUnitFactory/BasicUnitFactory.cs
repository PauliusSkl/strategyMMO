using Shared.Models.Builder;

namespace Shared.Models.AbstractUnitFactory
{
    public class BasicUnitFactory : UnitFactory
    {
        public Archer CreateArcher(string color, int x, int y)
        {
            return new ArcherBuilder()
                .SetHealth(50)
                .SetMaxHealth(50)
                .SetAttack(50)
                .SetRange(2)
                .SetSpeed(1)
                .SetKills(0)
                .SetUpgraded(false)
                .SetPosition(x, y)
                .SetType("Archer")
                .SetColor(color)
                .SetArrows(5)
                .Build();
        }

        public Warrior CreateWarrior(string color, int x, int y)
        {
            return new WarriorBuilder()
                 .SetHealth(200)
                 .SetMaxHealth(200)
                 .SetAttack(50)
                 .SetRange(1)
                 .SetSpeed(2)
                 .SetKills(0)
                 .SetUpgraded(false)
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
                 .SetAttack(100)
                 .SetRange(2)
                 .SetSpeed(1)
                 .SetKills(0)
                 .SetUpgraded(false)
                 .SetPosition(x, y)
                 .SetType("Mage")
                 .SetColor(color)
                 .SetMana(5)
                 .Build();
        }

        public Tank CreateTank(string color, int x, int y)
        {
            return new TankBuilder()
                 .SetHealth(300)
                 .SetMaxHealth(300)
                 .SetAttack(10)
                 .SetRange(1)
                 .SetSpeed(1)
                 .SetKills(0)
                 .SetUpgraded(false)
                 .SetPosition(x, y)
                 .SetType("Tank")
                 .SetColor(color)
                 .Build();
        }
    }

}
