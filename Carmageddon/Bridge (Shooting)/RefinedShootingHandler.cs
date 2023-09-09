using Carmageddon.Forms.ChainOfResp;

namespace Carmageddon.Forms.Bridge__Shooting_
{
    public class RefinedShootingHandler : AbstractShootingHandler
    {
        public async override Task<(string, int)> HandleShot(ShotEventHandler eventHandler, int coordX, int coordY, string username)
        {
            (bool hit, Type type) = await Weapon.Shoot(coordX, coordY, username);

            var bonus = eventHandler.HandleShotEvent(type, coordX, coordY);
            Weapon.ShotsLeft += bonus;

            if (hit)
            {
                return (type.Name + "hit",bonus);
            }

            return (type.Name,bonus);
        }
    }
}
