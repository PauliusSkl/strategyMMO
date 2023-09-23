using WarGame.API.Models;

namespace WarGame.API.Strategy;

public class PlayerNames : IStrategy
{
    public GameStatusModel DoOperation(GameStatusModel model)
    {
        model.PlayerNames = PlayersList.GetPlayerNames();
        return model;
    }
}
