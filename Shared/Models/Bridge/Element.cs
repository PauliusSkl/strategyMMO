using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Bridge
{
    public abstract class Element
    {
        public abstract void ApplyElement(Unit unit);
    }
}
