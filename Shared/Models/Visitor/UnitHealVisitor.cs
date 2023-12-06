namespace Shared.Models.Visitor;

public class UnitHealVisitor : IVisitor
{
    public void VisitArcher(Archer archer)
    {
        archer.Health++;
    }

    public void VisitMage(Mage mage)
    {
        mage.Health += 2;
    }

    public void VisitTank(Tank tank)
    {
        tank.Health += 3;
    }

    public void VisitWarrior(Warrior warrior)
    {
        warrior.Health += 4;
    }
}
