using Shared.Models.AbstractUnitFactory;

namespace Shared.Models.Visitor;
public class UnitUpgradeVisitor : IVisitor
{
    private readonly UpgradedUnitFactory _upgradedUnitFactory = new UpgradedUnitFactory();
    private readonly string imagesFolder = Path.Combine(AppContext.BaseDirectory, "Resources");

    public void VisitArcher(Archer archer)
    {
        archer = _upgradedUnitFactory.CreateArcher(archer.Color, archer.X, archer.Y);
        archer.Image = Path.Combine(imagesFolder, $"archer_upgraded_{archer.Color}.png");
    }

    public void VisitMage(Mage mage)
    {
        mage = _upgradedUnitFactory.CreateMage(mage.Color, mage.X, mage.Y);
        mage.Image = Path.Combine(imagesFolder, $"mage_{mage.Color}.png");
    }

    public void VisitTank(Tank tank)
    {
        tank = _upgradedUnitFactory.CreateTank(tank.Color, tank.X, tank.Y);
        tank.Image = Path.Combine(imagesFolder, $"tank_{tank.Color}.png");
    }

    public void VisitWarrior(Warrior warrior)
    {
        warrior = _upgradedUnitFactory.CreateWarrior(warrior.Color, warrior.X, warrior.Y);
        warrior.Image = Path.Combine(imagesFolder, $"warrior_upgraded_{warrior.Color}.png");
    }
}
