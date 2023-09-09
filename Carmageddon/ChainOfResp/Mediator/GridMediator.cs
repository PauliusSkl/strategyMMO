using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.ChainOfResp.Mediator
{
    public class GridMediator : AbstractGridMediator
    {
        private Dictionary<string, ShotEventHandler> participants = new();
        
        public override void Register(ShotEventHandler participant)
        {
            if (!participants.ContainsValue(participant))
            {
                participants[participant.GetType().FullName] = participant;
            }
            participant.Mediator = this;
        }

        public override void Send(string from, string to, (int,int) message, bool isResponse)
        {
            var participant = participants[to];
            if (participant != null)
            {
                participant.Receive(from, message, isResponse);
            }
        }
    }
}
