using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.IteratorPattern
{
    public class Iterator : IAbstractIterator
    {
        GameObjAggregate _aggregate;
        int current = 0;

        public Iterator(GameObjAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public object CurrentItem()
        {
            return _aggregate[current];
        }

        public object First()
        {
            return _aggregate[0];
        }

        public bool IsDone()
        {
            return current >= _aggregate.Count;
        }

        public object Next()
        {
            object item = null;

            if(current < _aggregate.Count - 1)
            {
                item = _aggregate[++current];
            }

            return item;
        }
    }
}
