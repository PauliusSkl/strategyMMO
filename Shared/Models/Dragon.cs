using Shared.Models.Bridge;
using Shared.Models.Prototype;
using WarGame.API.Iterator;

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
            var nests = new GameObjAggregate<Nest>(Nest);
            var iterator = nests.CreateIterator();

            while (!iterator.IsDone())
            {
                var oldNest = iterator.Next();
                Nest nestas = new Nest(oldNest!.X, oldNest!.Y, oldNest!.Element);
                clone.Nest.Add(nestas);
            }

            clone.Element = this.Element;
            clone.Health = MaxHealth * 2;
            clone.Attack = Attack * 2;
            return clone;
        }
    }
}
