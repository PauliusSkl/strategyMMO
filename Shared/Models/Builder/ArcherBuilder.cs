namespace Shared.Models.Builder
{
    public class ArcherBuilder : IUnitBuilder<Archer>
    {
        private Archer unit = new Archer();

        public IUnitBuilder<Archer> SetHealth(int health)
        {
            unit.Health = health;
            return this;
        }

        public IUnitBuilder<Archer> SetMaxHealth(int maxHealth)
        {
            unit.MaxHealth = maxHealth;
            return this;
        }

        public IUnitBuilder<Archer> SetAttack(int attack)
        {
            unit.Attack = attack;
            return this;
        }

        public IUnitBuilder<Archer> SetRange(int range)
        {
            unit.Range = range;
            return this;
        }

        public IUnitBuilder<Archer> SetSpeed(int speed)
        {
            unit.Speed = speed;
            return this;
        }

        public IUnitBuilder<Archer> SetKills(int kills)
        {
            unit.Kills = kills;
            return this;
        }

        public IUnitBuilder<Archer> SetUpgraded(bool upgraded)
        {
            unit.Upgraded = upgraded;
            return this;
        }

        public IUnitBuilder<Archer> SetPosition(int x, int y)
        {
            unit.X = x;
            unit.Y = y;
            return this;
        }

        public IUnitBuilder<Archer> SetType(string type)
        {
            unit.Type = type;
            return this;
        }

        public IUnitBuilder<Archer> SetColor(string color)
        {
            unit.Color = color;
            return this;
        }

        public IUnitBuilder<Archer> SetArrows(int arrows)
        {
            unit.Arrows = arrows;
            return this;
        }

        public Archer Build()
        {
            return unit;
        }
    }
}
