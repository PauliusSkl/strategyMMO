using Shared.Models.Bridge;
using Shared.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Composite
{
    public class Item : IUnitComponent
    {
        public Element Element { get; set; }
        public IState State { get; set; } = new FullHp();
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public int Range { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }
        public bool SpeedRaised { get; set; }
        public bool AttackRaised { get; set; }
        public bool Upgraded { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public int Kills { get; set; }
        public int ReceivedDamageTimes { get; set; }

        public void ReceiveDamage(int damage)
        {

        }

        public void SetHp(int hp)
        {

        }

        public void OnTurnEnd()
        {

        }

        public void SetState(IState state)
        {
        }

        public IState GetState()
        {
            return null;
        }
    }
}
