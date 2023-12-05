namespace Shared.Models.Visitor;

public interface IVisitor
{
    void VisitWarrior(Warrior warrior);
    void VisitArcher(Archer archer);
    void VisitMage(Mage mage);
    void VisitTank(Tank tank);
}
