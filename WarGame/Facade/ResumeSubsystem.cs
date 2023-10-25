using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Forms.Facade
{
    public class ResumeSubsystem
    {
        private PauseSubsystem pauseSubsystem;

        public ResumeSubsystem(PauseSubsystem pauseSubsystem)
        {
            this.pauseSubsystem = pauseSubsystem;
        }

        public bool IsPaused
        {
            get { return pauseSubsystem.IsPaused; }
        }

        public void Resume()
        {
            pauseSubsystem.Resume();
        }
    }
}
