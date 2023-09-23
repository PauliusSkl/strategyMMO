using WarGame.Forms.ChainOfResp;
using WarGame.Forms.Models;

namespace WarGame.Forms.Bridge__Shooting_;

public abstract class AbstractShootingHandler
{
    public Weapon Weapon { get; set; }

    public abstract Task<(string, int)> HandleShot(ShotEventHandler eventHandler, int coordX, int coordY, string username);
}
