using Shared.Models;

namespace WarGame.API.Strategy;

public class PlayerCount : IStrategy
{
    public GameStatusModel DoOperation(GameStatusModel model)
    {
        model.PlayerCount = PlayersList.GetCount();
        return model;
    }
}
