using Carmageddon.API.Iterator;
using Carmageddon.API.Models;

namespace Carmageddon.API
{
    public static class PlayersList
    {
        private static List<Player> _players = new List<Player>();

        public static bool CheckIfExists(Player player)
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

        public static List<Car> GetPlayerCars(string username)
        {
            return _players.FirstOrDefault(x => x.Username == username).Cars;
        }

        public static int GetCount()
        {
            return _players.Count;
        }

        public static List<string> GetPlayerNames()
        {
            var names = new List<string>();
            foreach (var player in _players)
            {
                names.Add(player.Username);
            }
            return names;
        }

        public static void AddPlayerCars(Player player, List<Car> cars)
        {
            if (!CheckIfExists(player))
            {
                return;
            }

            var playerAggregate = new GameObjAggregate();
            playerAggregate.ListToAggregate(_players);
            var iterator = playerAggregate.CreateIterator();

            var user = (Player)iterator.First();
            while(user != null)
            {
                if(user.Username == player.Username)
                {
                    user.Cars = cars;
                }
                user = (Player)iterator.Next();
            }
        }
    }
}
