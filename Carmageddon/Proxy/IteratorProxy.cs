using Carmageddon.Forms.IteratorPattern;

namespace Carmageddon.Forms.Proxy
{
    public class IteratorProxy : IAbstractIterator
    {
        private static GameObjAggregate _aggregate;
        private Iterator iterator;
        private object _lock = new object();


        public IteratorProxy(GameObjAggregate aggregate)
        {
            _aggregate = aggregate;
            lock (_lock)
            {
                if (iterator == null)
                {
                    iterator = new Iterator(aggregate);
                }
            }
        }

        public object CurrentItem()
        {
            return iterator.CurrentItem();
        }

        public object First()
        {
            return iterator.First();
        }

        public bool IsDone()
        {
            return iterator.IsDone();
        }

        public object Next()
        {
            return iterator.Next();
        }
    }
}
