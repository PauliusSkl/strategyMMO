using Carmageddon.API.Models;

namespace Carmageddon.API.Strategy
{
    public class PlayerCount : IStrategy
    {
        public GameStatusModel DoOperation(GameStatusModel model)
        {
            model.PlayerCount = PlayersList.GetCount();
            return model;
        }
    }
}
