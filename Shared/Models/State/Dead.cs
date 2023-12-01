using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.State
{
    public class Dead : IState
    {
        public void HandleChange(Unit unit)
        {
            unit.SetState(this);
        }
    }
}
