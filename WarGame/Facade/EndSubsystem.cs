using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Forms.Facade
{
    public class EndGameSubsystem
    {
        public event EventHandler<string> GameEnded;

        public void End()
        {
            string endMessage = "GGs!";

            GameEnded?.Invoke(this, endMessage);
        }
    }
}
