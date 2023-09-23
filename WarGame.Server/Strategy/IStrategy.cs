using WarGame.API.Models;

namespace WarGame.API.Strategy;

public interface IStrategy
{
    public GameStatusModel DoOperation(GameStatusModel model);
}
