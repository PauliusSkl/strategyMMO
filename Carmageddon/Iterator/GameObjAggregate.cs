using Carmageddon.Forms.Proxy;

namespace Carmageddon.Forms.IteratorPattern
{
    public class GameObjAggregate : IAggregate
    {
        List<object> items = new List<object>();

        //public Iterator CreateIterator()
        //{
        //    return new Iterator(this);
        //}

        public IteratorProxy CreateIterator()
        {
            return new IteratorProxy(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public object this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }

        public void ListToAggregate<T>(List<T> objects)
        {
            foreach (object obj in objects)
            {
                items.Add(obj);
            }
        }
    }
}
