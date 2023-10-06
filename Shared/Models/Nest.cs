using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Nest
    {

        public int X { get; set; }

        public int Y { get; set; }

        public int Health { get; set; } = 500;

        public string Image { get; set; } = string.Empty;

        public Nest(int x, int y, string image)
        {
            X = x;
            Y = y;
            Image = image;
        }
    }
}
