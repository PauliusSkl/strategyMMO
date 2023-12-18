using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Forms.ChainOfResponsibility
{
    public interface IMovementHandler
    {
        Task HandleMovement(string buttonName, GamePlayForm gamePlayForm, PictureBox selectedPictureBox);
        void SetSuccessor(IMovementHandler successor);
        IMovementHandler GetSuccessor();
    }

}
