using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Builder
{
    public class TankBuilder : IUnitBuilder
    {
        private Unit unit = new Unit();

        public IUnitBuilder SetHealth(int health)
        {
            unit.Health = health;
            return this;
        }

        public IUnitBuilder SetMaxHealth(int maxHealth)
        {
            unit.MaxHealth = maxHealth;
            return this;
        }

        public IUnitBuilder SetAttack(int attack)
        {
            unit.Attack = attack;
            return this;
        }

        public IUnitBuilder SetRange(int range)
        {
            unit.Range = range;
            return this;
        }

        public IUnitBuilder SetSpeed(int speed)
        {
            unit.Speed = speed;
            return this;
        }

        public IUnitBuilder SetKills(int kills)
        {
            unit.Kills = kills;
            return this;
        }

        public IUnitBuilder SetUpgraded(bool upgraded)
        {
            unit.Upgraded = upgraded;
            return this;
        }

        public IUnitBuilder SetPosition(int x, int y)
        {
            unit.X = x;
            unit.Y = y;
            return this;
        }

        public IUnitBuilder SetType(string type)
        {
            unit.Type = type;
            return this;
        }

        public IUnitBuilder SetColor(string color)
        {
            unit.Color = color;
            return this;
        }

        public Unit Build()
        {
            return unit;
        }
    }
}
