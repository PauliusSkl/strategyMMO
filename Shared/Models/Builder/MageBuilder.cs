namespace Shared.Models.Builder
{
    public class MageBuilder : IUnitBuilder<Mage>
    {
        private Mage unit = new Mage();

        public IUnitBuilder<Mage> SetHealth(int health)
        {
            unit.Health = health;
            return this;
        }

        public IUnitBuilder<Mage> SetMaxHealth(int maxHealth)
        {
            unit.MaxHealth = maxHealth;
            return this;
        }

        public IUnitBuilder<Mage> SetAttack(int attack)
        {
            unit.Attack = attack;
            return this;
        }

        public IUnitBuilder<Mage> SetRange(int range)
        {
            unit.Range = range;
            return this;
        }

        public IUnitBuilder<Mage> SetSpeed(int speed)
        {
            unit.Speed = speed;
            return this;
        }

        public IUnitBuilder<Mage> SetKills(int kills)
        {
            unit.Kills = kills;
            return this;
        }

        public IUnitBuilder<Mage> SetUpgraded(bool upgraded)
        {
            unit.Upgraded = upgraded;
            return this;
        }

        public IUnitBuilder<Mage> SetPosition(int x, int y)
        {
            unit.X = x;
            unit.Y = y;
            return this;
        }

        public IUnitBuilder<Mage> SetType(string type)
        {
            unit.Type = type;
            return this;
        }

        public IUnitBuilder<Mage> SetColor(string color)
        {
            unit.Color = color;
            return this;
        }


        public IUnitBuilder<Mage> SetMana(int mana)
        {
            unit.Mana = mana;
            return this;
        }

        public Mage Build()
        {
            return unit;
        }
    }
}
