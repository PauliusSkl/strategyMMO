using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Models
{
    public class CarPart
    {
        public bool IsDestroyed { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public CarPart(int coordX, int coordY)
        {
            IsDestroyed = false;
            CoordX = coordX;
            CoordY = coordY;
        }
    }
}
