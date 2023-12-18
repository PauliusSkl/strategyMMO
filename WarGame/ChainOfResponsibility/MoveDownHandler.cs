﻿using Shared.Models.State;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace WarGame.Forms.ChainOfResponsibility
{
    public class MoveDownHandler : IMovementHandler
    {
        private IMovementHandler successor;
        private GamePlayForm gamePlayForm;

        public MoveDownHandler(GamePlayForm form)
        {
            gamePlayForm = form;
            successor = new MoveLeftHandler(form);
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
                MessageBox.Show("Im in down");
                if (buttonName != "downButton")
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
                if (currentY + 50 <= 470)
                {
                    int newY = currentY + 50;
                    gamePlayForm.handleBattle(selectedPictureBox, currentX, newY);
                }
                gamePlayForm.MovementHandled = true;
                await gamePlayForm._battleHub.InvokeAsync("UpdatePictureCoordinates", selectedPictureBox.Name, selectedPictureBox.Location.X, selectedPictureBox.Location.Y);
            }
        }
    }
}
