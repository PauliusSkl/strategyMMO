using WarGame.API.Models;

namespace WarGame.API.Strategy;

public class MovesCount : IStrategy
{
    public GameStatusModel DoOperation(GameStatusModel model)
    {
        model.MovesCount++;
        return model;
    }
}
