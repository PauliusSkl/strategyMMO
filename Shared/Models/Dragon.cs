using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Dragon : Unit
    {

        public List<Nest> Nest { get; set; }
        public Dragon(int x, int y, string image)
        {
            X = x;
            Y = y;
            Image = image;
            Range = 2;
            Health = 200;
            Attack = 100;
            Color = "enemy";
        }
    }
}
