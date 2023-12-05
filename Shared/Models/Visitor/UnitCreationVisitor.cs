using Shared.Models.AbstractUnitFactory;

namespace Shared.Models.Visitor;

public class UnitCreationVisitor : IVisitor
{
    private readonly BasicUnitFactory _basicUnitFactory = new BasicUnitFactory();
    private readonly string imagesFolder = Path.Combine(AppContext.BaseDirectory, "Resources");
    private readonly string color;
    private readonly List<Unit> units;

    public UnitCreationVisitor(string color, List<Unit> units)
    {
        this.color = color;
        this.units = units;
    }

    public void VisitWarrior(Warrior warrior)
    {
        warrior = _basicUnitFactory.CreateWarrior(color, 0, 0);
        warrior.Color = color;
        warrior.Image = Path.Combine(imagesFolder, $"warrior_{color}.png");
        units.Add(warrior);
    }

    public void VisitArcher(Archer archer)
    {
        archer = _basicUnitFactory.CreateArcher(color, 0, 0);
        archer.Color = color;
        archer.Image = Path.Combine(imagesFolder, $"archer_{color}.png");
        units.Add(archer);
    }

    public void VisitMage(Mage mage)
    {
        mage = _basicUnitFactory.CreateMage(color, 0, 0);
        mage.Color = color;
        mage.Image = Path.Combine(imagesFolder, $"mage_{color}.png");
        units.Add(mage);
    }

    public void VisitTank(Tank tank)
    {
        tank = _basicUnitFactory.CreateTank(color, 0, 0);
        tank.Color = color;
        tank.Image = Path.Combine(imagesFolder, $"tank_{color}.png");
        units.Add(tank);
    }
}
