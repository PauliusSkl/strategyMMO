using Microsoft.AspNetCore.SignalR.Client;

namespace Carmageddon.Forms.Models
{
    public abstract class Weapon
    {
        public int Damage { get; set; }
        public int ShotsLeft { get; set; }
        public HubConnection BattleHub { get; set; }

        public abstract Task<(bool, Type)> Shoot(int coordX, int coordY, string username);
    }
}
