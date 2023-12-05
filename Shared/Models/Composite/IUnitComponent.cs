using Shared.Models.Bridge;
using Shared.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Composite
{
    public interface IUnitComponent
    {
        Element Element { get; set; }
        void OnTurnEnd();
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Attack { get; set; }
        int Range { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Speed { get; set; }
        bool Upgraded { get; set; }
        string Color { get; set; }
        string Image { get; set; }
        string Type { get; set; }
        int Kills { get; set; }

        void SetState(IState state);
        IState GetState();
        void ReceiveDamage(int damage);
        void SetHp(int hp);
    }
}
