using Shared.Models;

namespace WarGame.API;

public static class PlayersList
{
    private static readonly List<Player> _players = new();

    public static bool Exists(Player player)
    {
        return _players.Any(x => x.Username == player.Username);
    }

    public static void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public static List<Player> GetPlayers()
    {
        return _players;
    }

    public static Player GetEnemy(string username)
    {
        return _players.FirstOrDefault(x => x.Username != username);
    }

    public static Player GetPlayer(string username)
    {
        return _players.FirstOrDefault(x => x.Username == username);
    }

    public static int GetCount()
    {
        return _players.Count;
    }
}
