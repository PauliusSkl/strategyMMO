using Shared.Models;
using WarGame.API.Iterator;

namespace WarGame.API.Strategy;

public class PlayerNames : IStrategy
{
    public GameStatusModel DoOperation(GameStatusModel model)
    {
        var playerList = new ListAggregate<Player>(PlayersList.GetPlayers());
        var iterator = playerList.CreateIterator();
        var names = new List<string>();

        while (!iterator.IsDone()) names.Add(iterator.Next()!.Username);

        model.PlayerNames = names;
        return model;
    }
}
