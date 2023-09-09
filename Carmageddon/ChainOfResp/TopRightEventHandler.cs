using Carmageddon.Forms.Models;
using System.Diagnostics;

namespace Carmageddon.Forms.ChainOfResp
{
    public class TopRightEventHandler : ShotEventHandler
    {
        public static (int, int) ShotBonus { private get; set; }

        public override int HandleShotEvent(Type type, int coordX, int coordY)
        {
            Send(typeof(BottomRightEventHandler).FullName, ShotBonus, false);
            if (coordX >= 250 && coordY < 250)
            {
                if (type == typeof(Cannon))
                {
                    Debug.WriteLine("Top right bonus applied for Cannon: " + ShotBonus.Item1);

                    return ShotBonus.Item1;
                }
                else
                {
                    Debug.WriteLine("Top right bonus applied for MG: " + ShotBonus.Item2);

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

        public override void Receive(string from, (int, int) message, bool isResponse)
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
