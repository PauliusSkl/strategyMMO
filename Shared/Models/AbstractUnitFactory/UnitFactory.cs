using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.AbstractUnitFactory
{
    public interface UnitFactory
    {
        Unit CreateArcher(string color, int x, int y);
        Unit CreateWarrior(string color, int x, int y);
        Unit CreateMage(string color, int x, int y);
        Unit CreateTank(string color, int x, int y);
    }
}
