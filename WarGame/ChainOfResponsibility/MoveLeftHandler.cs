using Shared.Models.State;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace WarGame.Forms.ChainOfResponsibility
{
    public class MoveLeftHandler : IMovementHandler
    {
        private IMovementHandler successor;
        private GamePlayForm gamePlayForm;

        public MoveLeftHandler(GamePlayForm form)
        {
            gamePlayForm = form;
            successor = new MoveRightHandler(form);
        }

        public void SetSuccessor(IMovementHandler successor)
        {
            this.successor = successor;
        }

        public IMovementHandler GetSuccessor()
        {
            return successor;
        }

        public async Task HandleMovement(string buttonName, GamePlayForm gamePlayForm, PictureBox selectedPictureBox)
        {
            if (selectedPictureBox != null)
            {
                MessageBox.Show("Im in left");
                if (buttonName != "leftButton")
                {
                    successor?.HandleMovement(buttonName, gamePlayForm, selectedPictureBox);
                    return;
                }
                Unit unit = gamePlayForm.GetWarriorFromPictureBox(selectedPictureBox);
                if (unit.GetState() is Stunned)
                {
                    return;
                }
                int currentY = selectedPictureBox.Location.Y;
                int currentX = selectedPictureBox.Location.X;
                if (currentX - 50 >= 420)
                {
                    int newX = currentX - 50;
                    gamePlayForm.handleBattle(selectedPictureBox, newX, currentY);
                }
                gamePlayForm.MovementHandled = true;
                await gamePlayForm._battleHub.InvokeAsync("UpdatePictureCoordinates", selectedPictureBox.Name, selectedPictureBox.Location.X, selectedPictureBox.Location.Y);
            }
        }
    }
}
