using System.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;

namespace Carmageddon.Forms.Models
{
    public class MachineGun : Weapon
    {
        public async override Task<(bool, Type)> Shoot(int coordX, int coordY, string username)
        {
            bool isHit = false;
            await foreach (var hit in BattleHub.StreamAsync<bool>("CheckShot", typeof(MachineGun).Name, coordX, coordY, username))
            {
                isHit = hit;
                break;
            }
            ShotsLeft--;
            Debug.WriteLine("Machinegun shot made!");
            if(isHit)
            {
                Debug.WriteLine("Enemy hit!");
            }

            return (isHit, typeof(MachineGun));
        }
    }
}
