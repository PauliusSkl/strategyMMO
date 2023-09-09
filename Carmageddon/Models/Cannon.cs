using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace Carmageddon.Forms.Models
{
    public class Cannon : Weapon
    {
        public async override Task<(bool, Type)> Shoot(int coordX, int coordY, string username)
        {
            bool isHit = false;
            await foreach (var hit in BattleHub.StreamAsync<bool>("CheckShot", typeof(Cannon).Name, coordX, coordY, username))
            {
                isHit = hit;
                break;
            }
            ShotsLeft--;
            Debug.WriteLine("Cannon shot made!");
            if (isHit)
            {
                Debug.WriteLine("Enemy hit!");
            }

            return (isHit, typeof(Cannon));

        }
    }
}
