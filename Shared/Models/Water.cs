using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Shared.Models
{
    public class Water : Obstacle
    {

        public int SlowLevel { get; set; }

        public Water(int x, int y, int slowLevel)
        {
            X = x;
            Y = y;
            SlowLevel = slowLevel;
            Image = "Resources/obstacle_water.png";
        }

        public override List<string> DisplayInfo()
        {
            List<string> info = new List<string>();
            info.Add("Name: Water");
            info.Add("Slow Level: " + SlowLevel.ToString());
            info.Add("Cords: " + X.ToString() + ";" + Y.ToString());

            return info;
        }
    }
}
