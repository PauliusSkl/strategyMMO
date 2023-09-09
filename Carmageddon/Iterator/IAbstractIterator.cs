using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.IteratorPattern
{
    public interface IAbstractIterator
    {
        object First();
        object Next();
        bool IsDone();
        object CurrentItem();
    }
}
