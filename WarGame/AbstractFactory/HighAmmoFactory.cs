using WarGame.Forms.Models;

namespace WarGame.Forms.AbstractFactory;

public class HighAmmoFactory : WeaponFactory
{
    public override Cannon CreateCannon()
    {
        return new Cannon()
        {
            Damage = 3,
            ShotsLeft = 25,
            BattleHub = new BattleHub().GetInstance()
        };
    }

    public override MachineGun CreateMachineGun()
    {
        return new MachineGun()
        {
            Damage = 2,
            ShotsLeft = 50,
            BattleHub = new BattleHub().GetInstance()
        };
    }
}
