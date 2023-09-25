using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Forms.Models
{
    public class Unit
    {
        public int Health { get; set; }
        public int Attack { get; set; }

        public int Range { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Speed { get; set; }

        public string Color { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

    }
}
