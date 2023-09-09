using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.API.Iterator
{
    public interface IAggregate
    {
        Iterator CreateIterator();
    }
}
