using Carmageddon.API.Models;

namespace Carmageddon.API.Strategy
{
    public class PlayerNames : IStrategy
    {
        public GameStatusModel DoOperation(GameStatusModel model)
        {
            model.PlayerNames = PlayersList.GetPlayerNames();
            return model;
        }
    }
}
