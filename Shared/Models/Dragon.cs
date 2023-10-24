using Shared.Models.Bridge;
using Shared.Models.Prototype;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Dragon : Unit, IDragonPrototype
    {

        public List<Nest> Nest { get; set; }
        public Element Element { get; set; }
        public Dragon(int x, int y, List<Nest> nests, Element element)
        {
            X = x;
            Y = y;
            Range = 2;
            Health = 200;
            MaxHealth = 200;
            Attack = 100;
            Color = "neutral";
            Nest = nests;
            Element = element;
        }
        public void ApplyElement()
        {
            Element.ApplyElement(this);
        }

        public Dragon ShallowClone()
        {
            Dragon clone = (Dragon)this.MemberwiseClone();
            clone.Nest = this.Nest;
            clone.Element = this.Element;
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
                Nest nestas = new Nest(nest.X, nest.Y, nest.Element);
                clone.Nest.Add(nestas);
            }
            clone.Element = this.Element;
            clone.Health = MaxHealth * 2;
            clone.Attack = Attack * 2;
            return clone;
        }
    }
}
