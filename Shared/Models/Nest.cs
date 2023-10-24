using Shared.Models.Bridge;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Nest : Unit
    {
        public Element Element { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        public string Image { get; set; } = string.Empty;

        public Nest(int x, int y, Element element)
        {
            X = x;
            Y = y;
            Color = "neutral";
            Health = 500;
            MaxHealth = 500;
            Attack = 0;
            Element = element;
        }

        public void ApplyElement()
        {
            Element.ApplyElement(this);
        }
    }
}
