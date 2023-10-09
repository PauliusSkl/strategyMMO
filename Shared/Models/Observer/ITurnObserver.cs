using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Observer
{
    public interface ITurnObserver
    {
        void OnTurnEnd();
    }
}
