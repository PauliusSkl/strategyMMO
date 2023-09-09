using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.AbstractFactory
{
    public abstract class WeaponFactory
    {
        public abstract Cannon CreateCannon();
        public abstract MachineGun CreateMachineGun();
    }
}
