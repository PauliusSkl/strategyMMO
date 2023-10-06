using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Prototype
{
    public interface IDragonPrototype
    {
        Dragon ShallowClone();

        Dragon DeepClone();
    }
}
