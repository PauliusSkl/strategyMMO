using Carmageddon.Forms.Models;
using System.Diagnostics;

namespace Carmageddon.Forms.ChainOfResp
{
    public class TopLeftEventHandler : ShotEventHandler
    {
        public static (int,int) ShotBonus { private get; set; }

        public override int HandleShotEvent(Type type, int coordX, int coordY)
        {
            if (coordX < 250 && coordY < 250)
            {
                Send(typeof(TopRightEventHandler).FullName, ShotBonus, false);
                if (type == typeof(Cannon))
                {
                    Debug.WriteLine("Top left bonus applied for Cannon: " + ShotBonus.Item1);

                    return ShotBonus.Item1;
                }
                else
                {
                    Debug.WriteLine("Top left bonus applied for MG: " + ShotBonus.Item2);

                    return ShotBonus.Item2;
                }
            }
            else
            {
                return base.HandleShotEvent(type, coordX, coordY);
            }
        }

        public override void Send(string to, (int, int) message, bool isResponse)
        {
            Mediator.Send(GetType().FullName, to, message, isResponse);
        }

        public override void Receive(string from, (int,int) message, bool isResponse)
        {
            (var oldA, var oldB) = ShotBonus;

            ShotBonus = message;

            if (!isResponse)
            {
                Send(from, (oldA, oldB), true);
            }
        }
    }
}
