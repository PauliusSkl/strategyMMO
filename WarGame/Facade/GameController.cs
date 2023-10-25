using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;
//using WarGame.Forms.GamePlayForm;

namespace WarGame.Forms.Facade
{
    public class GameFacade
    {
        private readonly PauseSubsystem _pauseSubsystem;
        private readonly ResumeSubsystem _resumeSubsystem;
        private readonly EndGameSubsystem _endGameSubsystem;

        public GameFacade(PauseSubsystem pauseSubsystem, ResumeSubsystem resumeSubsystem, EndGameSubsystem endGameSubsystem)
        {
            _pauseSubsystem = pauseSubsystem;
            _resumeSubsystem = resumeSubsystem;
            _endGameSubsystem = endGameSubsystem;
        }

        public void PauseGame()
        {
            _pauseSubsystem.Pause();
        }

        public void ResumeGame()
        {
            _resumeSubsystem.Resume();
        }

        public void EndGame()
        {
            _endGameSubsystem.End();
        }
    }
}
