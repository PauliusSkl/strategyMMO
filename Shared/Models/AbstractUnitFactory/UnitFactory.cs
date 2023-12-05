namespace Shared.Models.AbstractUnitFactory
{
    public interface UnitFactory
    {
        Archer CreateArcher(string color, int x, int y);
        Warrior CreateWarrior(string color, int x, int y);
        Mage CreateMage(string color, int x, int y);
        Tank CreateTank(string color, int x, int y);
    }
}
