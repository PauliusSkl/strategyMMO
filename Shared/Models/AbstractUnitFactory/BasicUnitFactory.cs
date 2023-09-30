using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.AbstractUnitFactory
{
    public class BasicUnitFactory : UnitFactory
    {
        public Unit CreateArcher(string color)
        {
            return new Unit
            {
                Health = 50,
                Attack = 50,
                Range = 2,
                Speed = 1,
                X = 0,
                Y = 0,
                Color = color,
            };
        }

        public Unit CreateWarrior(string color)
        {
            return new Unit
            {
                Health = 200,
                Attack = 50,
                Range = 1,
                Speed = 1,
                X = 0,
                Y = 0,
                Color = color,
            };
        }

        public Unit CreateMage(string color)
        {
            return new Unit
            {
                Health = 50,
                Attack = 100,
                Range = 2,
                Speed = 1,
                X = 0,
                Y = 0,
                Color = color,
            };
        }

        public Unit CreateTank(string color)
        {
            return new Unit
            {
                Health = 300,
                Attack = 10,
                Range = 1,
                Speed = 1,
                X = 0,
                Y = 0,
                Color = color,
            };
        }
    }

}
