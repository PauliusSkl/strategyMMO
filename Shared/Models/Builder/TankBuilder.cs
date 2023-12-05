namespace Shared.Models.Builder
{
    public class TankBuilder : IUnitBuilder<Tank>
    {
        private Tank unit = new Tank();

        public IUnitBuilder<Tank> SetHealth(int health)
        {
            unit.Health = health;
            return this;
        }

        public IUnitBuilder<Tank> SetMaxHealth(int maxHealth)
        {
            unit.MaxHealth = maxHealth;
            return this;
        }

        public IUnitBuilder<Tank> SetAttack(int attack)
        {
            unit.Attack = attack;
            return this;
        }

        public IUnitBuilder<Tank> SetRange(int range)
        {
            unit.Range = range;
            return this;
        }

        public IUnitBuilder<Tank> SetSpeed(int speed)
        {
            unit.Speed = speed;
            return this;
        }

        public IUnitBuilder<Tank> SetKills(int kills)
        {
            unit.Kills = kills;
            return this;
        }

        public IUnitBuilder<Tank> SetUpgraded(bool upgraded)
        {
            unit.Upgraded = upgraded;
            return this;
        }

        public IUnitBuilder<Tank> SetPosition(int x, int y)
        {
            unit.X = x;
            unit.Y = y;
            return this;
        }

        public IUnitBuilder<Tank> SetType(string type)
        {
            unit.Type = type;
            return this;
        }

        public IUnitBuilder<Tank> SetColor(string color)
        {
            unit.Color = color;
            return this;
        }

        public Tank Build()
        {
            return unit;
        }
    }
}
