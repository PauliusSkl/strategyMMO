using Shared.Models;

namespace WarGame.API.Strategy;

public class GameStatus
{
    private readonly IStrategy _strategy;

    public GameStatus(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public GameStatusModel ExecuteStrategy(GameStatusModel model)
    {
        return _strategy.DoOperation(model);
    }
}
