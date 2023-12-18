using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Forms.ChainOfResponsibility
{
    public class MovementHandlerChain
    {
        private List<IMovementHandler> handlers = new List<IMovementHandler>();

        public void AddHandler(IMovementHandler handler)
        {
            handlers.Add(handler);
        }

        public async Task HandleMovement(string buttonName, GamePlayForm gamePlayForm, PictureBox selectedPictureBox)
        {
            foreach (var handler in handlers)
            {
                await handler.HandleMovement(buttonName, gamePlayForm, selectedPictureBox);
                if (gamePlayForm.MovementHandled)
                {
                    break;
                }
            }
        }
    }
}
