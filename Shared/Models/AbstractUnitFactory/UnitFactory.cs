using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.AbstractUnitFactory
{
    public interface UnitFactory
    {
        Unit CreateArcher(string color);
        Unit CreateWarrior(string color);
        Unit CreateMage(string color);
        Unit CreateTank(string color);
    }
}
