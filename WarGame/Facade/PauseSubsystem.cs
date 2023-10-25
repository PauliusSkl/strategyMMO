using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Forms.Facade
{
    public class PauseSubsystem
    {
        private bool isPaused = false;

        public bool IsPaused
        {
            get { return isPaused; }
        }

        public void Pause()
        {
            isPaused = true;
        }

        public void Resume() 
        {
            isPaused = false;
        }
    }
}
