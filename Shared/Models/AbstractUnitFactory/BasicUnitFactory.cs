using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.AbstractUnitFactory
{
    public class BasicUnitFactory : UnitFactory
    {
        public Unit CreateArcher(string color, int x, int y)
        {
            return new Unit
            {
                Health = 50,
                MaxHealth = 50,
                Attack = 50,
                Range = 2,
                Speed = 1,
                Kills = 0,
                Upgraded = false,
                X = x,
                Y = y,
                Type = "Archer",
                Color = color,
            };
        }

        public Unit CreateWarrior(string color, int x, int y)
        {
            return new Unit
            {
                Health = 200,
                MaxHealth = 200,
                Attack = 50,
                Range = 1,
                Speed = 2,
                Kills = 0,
                Upgraded = false,
                X = x,
                Y = y,
                Type = "Warrior",
                Color = color,
            };
        }

        public Unit CreateMage(string color, int x, int y)
        {
            return new Unit
            {
                Health = 50,
                MaxHealth = 50,
                Attack = 100,
                Range = 2,
                Speed = 1,
                Kills = 0,
                Upgraded = false,
                X = x,
                Y = y,
                Type = "Mage",
                Color = color,
            };
        }

        public Unit CreateTank(string color, int x, int y)
        {
            return new Unit
            {
                Health = 300,
                MaxHealth = 300,
                Attack = 10,
                Range = 1,
                Speed = 1,
                Kills = 0,
                Upgraded = false,
                X = x,
                Y = y,
                Type = "Tank",
                Color = color,
            };
        }
    }

}
