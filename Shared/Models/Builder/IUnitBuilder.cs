namespace Shared.Models.Builder
{
    public interface IUnitBuilder<T> where T : Unit
    {
        IUnitBuilder<T> SetHealth(int health);
        IUnitBuilder<T> SetMaxHealth(int maxHealth);
        IUnitBuilder<T> SetAttack(int attack);
        IUnitBuilder<T> SetRange(int range);
        IUnitBuilder<T> SetSpeed(int speed);
        IUnitBuilder<T> SetKills(int kills);
        IUnitBuilder<T> SetUpgraded(bool upgraded);
        IUnitBuilder<T> SetPosition(int x, int y);
        IUnitBuilder<T> SetType(string type);
        IUnitBuilder<T> SetColor(string color);
        IUnitBuilder<T> SetMana(int mana)
        {
            // Do nothing by default
            return this;
        }
        IUnitBuilder<T> SetArrows(int mana)
        {
            // Do nothing by default
            return this;
        }
        T Build();
    }
}
