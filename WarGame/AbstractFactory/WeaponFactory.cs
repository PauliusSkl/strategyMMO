using WarGame.Forms.Models;

namespace WarGame.Forms.AbstractFactory;

public abstract class WeaponFactory
{
    public abstract Cannon CreateCannon();
    public abstract MachineGun CreateMachineGun();
}
