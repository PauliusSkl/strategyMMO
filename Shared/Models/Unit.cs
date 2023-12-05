using Shared.Models.Bridge;
using Shared.Models.Composite;
using Shared.Models.Observer;
using Shared.Models.State;

namespace Shared.Models;
public class Unit : IUnitComponent, ITurnObserver
{
    private readonly List<IUnitComponent> items = new List<IUnitComponent>();
    public Element Element { get; set; }

    public void OnTurnEnd()
    {
        if (this.GetState() is Damaged)
        {
            this.SetHp(this.Health + 10);
        }

        if (this.GetState() is Stunned)
        {
            this.receivedDamageTimes--;
            this.SetHp(this.Health);
        }
    }

    public void AddItem(IUnitComponent item)
    {
        items.Add(item);
        this.Health += item.Health;
        this.Attack += item.Attack;
        this.MaxHealth += item.MaxHealth;
        this.Range += item.Range;
    }

    public void RemoveItem(IUnitComponent item)
    {
        items.Remove(item);
        this.Health -= item.Health;
        this.Attack -= item.Attack;
        this.MaxHealth -= item.MaxHealth;
        this.Range -= item.Range;
    }

    private IState State { get; set; } = new FullHp();
    public int Health { get; set; }

    public int MaxHealth { get; set; }

    public int Attack { get; set; }

    public int Range { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public int Speed { get; set; }

    public bool speedRaised { get; set; } = false;

    public bool attackRaised { get; set; } = false;
    public bool Upgraded { get; set; } = false;
    public string Color { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Kills { get; set; }

    public int receivedDamageTimes { get; set; } = 0;


    public void SetState(IState state)
    {
        State = state;
    }

    public IState GetState()
    {
        return State;
    }

    public void ReceiveDamage(int damage)
    {
        Health -= damage;
        receivedDamageTimes++;

        State.HandleChange(this);
    }

    public void SetHp(int hp)
    {
        this.Health = hp;
        State.HandleChange(this);
    }
}
