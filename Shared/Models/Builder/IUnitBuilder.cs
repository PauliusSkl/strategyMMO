using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Builder
{
    public interface IUnitBuilder
    {
        IUnitBuilder SetHealth(int health);
        IUnitBuilder SetMaxHealth(int maxHealth);
        IUnitBuilder SetAttack(int attack);
        IUnitBuilder SetRange(int range);
        IUnitBuilder SetSpeed(int speed);
        IUnitBuilder SetKills(int kills);
        IUnitBuilder SetUpgraded(bool upgraded);
        IUnitBuilder SetPosition(int x, int y);
        IUnitBuilder SetType(string type);
        IUnitBuilder SetColor(string color);
        Unit Build();
    }
}
