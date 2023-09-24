using WarGame.API.Models;
using WarGame.API.State;

namespace WarGame.Server.Models
{
    public class Warrior
    {
        public int Health { get; set; }
        public int Attack { get; set; }

        public int Range { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Speed { get; set; }

    }
}
