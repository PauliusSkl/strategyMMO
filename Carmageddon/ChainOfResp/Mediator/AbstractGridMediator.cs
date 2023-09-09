using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.ChainOfResp.Mediator
{
    public abstract class AbstractGridMediator
    {
        public abstract void Register(ShotEventHandler participant);
        
        public abstract void Send(string from, string to, (int,int) message, bool isResponse);
    }
}
