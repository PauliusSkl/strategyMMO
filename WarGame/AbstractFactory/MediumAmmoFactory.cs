using WarGame.Forms.Models;

namespace WarGame.Forms.AbstractFactory;

public class MediumAmmoFactory : WeaponFactory
{
    public override Cannon CreateCannon()
    {
        return new Cannon()
        {
            Damage = 3,
            ShotsLeft = 20,
            BattleHub = new BattleHub().GetInstance()
        };
    }

    public override MachineGun CreateMachineGun()
    {
        return new MachineGun()
        {
            Damage = 2,
            ShotsLeft = 40,
            BattleHub = new BattleHub().GetInstance()
        };
    }
}
