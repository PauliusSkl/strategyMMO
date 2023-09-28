using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared.Models
{
    public abstract class Obstacle
    {
        public enum ObstacleType
        {
            lava,
            water,
            mountain,
        }


        public int X { get; set; }

        public int Y { get; set; }

        public string Image { get; set; } = string.Empty;

        public abstract List<string> DisplayInfo();
    }
}
