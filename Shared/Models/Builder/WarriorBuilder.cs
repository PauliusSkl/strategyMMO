namespace Shared.Models.Builder
{
    public class WarriorBuilder : IUnitBuilder<Warrior>
    {
        private Warrior unit = new Warrior();

        public IUnitBuilder<Warrior> SetHealth(int health)
        {
            unit.Health = health;
            return this;
        }

        public IUnitBuilder<Warrior> SetMaxHealth(int maxHealth)
        {
            unit.MaxHealth = maxHealth;
            return this;
        }

        public IUnitBuilder<Warrior> SetAttack(int attack)
        {
            unit.Attack = attack;
            return this;
        }

        public IUnitBuilder<Warrior> SetRange(int range)
        {
            unit.Range = range;
            return this;
        }

        public IUnitBuilder<Warrior> SetSpeed(int speed)
        {
            unit.Speed = speed;
            return this;
        }

        public IUnitBuilder<Warrior> SetKills(int kills)
        {
            unit.Kills = kills;
            return this;
        }

        public IUnitBuilder<Warrior> SetUpgraded(bool upgraded)
        {
            unit.Upgraded = upgraded;
            return this;
        }

        public IUnitBuilder<Warrior> SetPosition(int x, int y)
        {
            unit.X = x;
            unit.Y = y;
            return this;
        }

        public IUnitBuilder<Warrior> SetType(string type)
        {
            unit.Type = type;
            return this;
        }

        public IUnitBuilder<Warrior> SetColor(string color)
        {
            unit.Color = color;
            return this;
        }

        public Warrior Build()
        {
            return unit;
        }
    }
}
