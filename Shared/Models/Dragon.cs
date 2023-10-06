using Shared.Models.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Dragon : Unit, IDragonPrototype
    {

        public List<Nest> Nest { get; set; }
        public Dragon(int x, int y, string image, List<Nest> nests)
        {
            X = x;
            Y = y;
            Image = image;
            Range = 2;
            Health = 200;
            MaxHealth = 200;
            Attack = 100;
            Color = "enemy";
            Nest = nests;
        }

        public Dragon ShallowClone()
        {
            Dragon clone = (Dragon)this.MemberwiseClone();
            clone.Nest = this.Nest;
            clone.Health = MaxHealth * 2;
            clone.Attack = Attack * 2;
            return clone;
        }

        public Dragon DeepClone()
        {
            Dragon clone = (Dragon)this.MemberwiseClone();
            clone.Nest = new List<Nest>();
            foreach (var nest in this.Nest)
            {
                Nest nestas = new Nest(nest.X, nest.Y, nest.Image);
                clone.Nest.Add(nestas);
            }
            clone.Health = MaxHealth * 2;
            clone.Attack = Attack * 2;
            return clone;
        }
    }
}
