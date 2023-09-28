using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Shared.Models
{
    public class Lava : Obstacle
    {

        public int Damage { get; set; }

        public Lava(int x, int y, int damage)
        {
            X = x;
            Y = y;
            Damage = damage;
            Image = "Resources/obstacle_lava.png";
        }

        public override List<string> DisplayInfo()
        {
            List<string> info = new List<string>();
            info.Add("Name: Lava");
            info.Add("Damage: " + Damage.ToString());
            info.Add("Cords: " + X.ToString() + ";" + Y.ToString());

            return info;
        }
    }
}
