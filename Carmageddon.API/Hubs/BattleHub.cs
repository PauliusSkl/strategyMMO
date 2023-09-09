using Carmageddon.API.Models;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace Carmageddon.API.Hubs
{
    public class BattleHub : Hub
    {
        public async IAsyncEnumerable<bool> ConfirmPlayer([EnumeratorCancellation] CancellationToken cancellationToken, string username)
        {
            if (username == null)
            {
                yield return false;
            }

            var player = PlayersList.GetPlayer(username);
            player.Confirmed = true;

            yield return true;

            await Task.Delay(1000, cancellationToken);
        }

        public async IAsyncEnumerable<string> GetTurn([EnumeratorCancellation] CancellationToken cancellationToken, 
            string username, bool turnMade)
        {
            if(username == null)
            {
                yield return "";
            }

            var players = PlayersList.GetPlayers();
            if(players == null || players.Count != 2)
            {
                yield return "";
            }

            if (!players[0].PlayerTurn && !players[1].PlayerTurn && players[0].Confirmed && players[1].Confirmed)
            {
                var rand = new Random();
                var idx = rand.Next(0, 2);
                players[idx].PlayerTurn = true;

                yield return CheckTurn(username);
            }

            if (turnMade)
            {
                yield return CheckTurn(username);
            }
            else
            {
                var player = PlayersList.GetPlayer(username);

                if (player.PlayerTurn)
                {
                    yield return "Your turn";
                }
                else
                {
                    yield return "Opponent turn";
                }
            }
            

            await Task.Delay(1000, cancellationToken);
        }

        private string CheckTurn(string username)
        {
            var player = PlayersList.GetPlayer(username);
            var enemy = PlayersList.GetEnemy(username);

            if (player.PlayerTurn)
            {
                player.PlayerTurn = false;
                enemy.PlayerTurn = true;
                return "Opponent turn";
            }
            else
            {
                enemy.PlayerTurn = false;
                player.PlayerTurn = true;
                return "Your turn";
            }
        }


        public async IAsyncEnumerable<bool> CheckShot([EnumeratorCancellation] CancellationToken cancellationToken, 
            string type, int coordX, int coordY, string username)
        {
            if(username == null)
            {
                yield return false;
            }
            else
            {
                yield return CheckCollision(coordX, coordY, username);
            }
                
            await Task.Delay(1000, cancellationToken);
        }

        public async IAsyncEnumerable<string> CheckIfAllCarsDestroyed([EnumeratorCancellation] CancellationToken cancellationToken, string username)
        {
            if (username == null)
            {
                yield return "";
            }
            else
            {
                var message = CheckAllCars(username);
                yield return message;
            }

            await Task.Delay(1000, cancellationToken);
        }

        public async IAsyncEnumerable<string> CheckCarState([EnumeratorCancellation] CancellationToken cancellationToken, 
            int coordX, int coordY, string username)
        {
            if (username == null)
            {
                yield return "";
            }
            else
            {
                var state = "";
                var stop = false;
                var cars = PlayersList.GetPlayerCars(username);
                foreach (var car in cars)
                {
                    foreach (var coord in car.Coordinates)
                    {
                        if (coord.CoordX == coordX && coord.CoordY == coordY)
                        {
                            state = car.Context.CarState.GetType().Name;
                            stop = true;
                            break;
                        }
                    }
                    if (stop)
                    {
                        break;
                    }
                }
                yield return state;
            }

            await Task.Delay(1000, cancellationToken);
        }

        private string CheckAllCars(string username)
        {
            var enemyPlayer = PlayersList.GetEnemy(username);
            var playerCars = PlayersList.GetPlayerCars(username);
            if (enemyPlayer == null)
            {
                return "";
            }

            if (playerCars == null)
            {
                return "";
            }

            if(enemyPlayer.Cars == null)
            {
                return "";
            }

            var enemyDestroyed = CheckAllCarsState(enemyPlayer.Cars);
            var playerDestroyed = CheckAllCarsState(playerCars);

            if(enemyDestroyed)
            {
                return "You won!";
            }
            if (playerDestroyed)
            {
                return "Opponent won!";
            }

            return "";
        }

        private bool CheckAllCarsState(List<Car> cars)
        {
            foreach (var car in cars)
            {
                foreach (var coord in car.Coordinates)
                {
                    if (!coord.IsDestroyed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckCollision(int coordX, int coordY, string username)
        {
            var enemyPlayer = PlayersList.GetEnemy(username);

            //return enemyPlayer.Cars.Any(car => car.Coordinates.Any(x => x.CoordX == coordX && x.CoordY == coordY && !x.IsDestroyed));
            if(enemyPlayer == null)
            {
                return false;
            }

            foreach (var car in enemyPlayer.Cars)
            {
                foreach (var coord in car.Coordinates)
                {
                    if(coord.CoordX == coordX && coord.CoordY == coordY && !coord.IsDestroyed)
                    {
                        car.Health--;
                        car.Context.ChangeState(car.Health);
                        coord.IsDestroyed = true;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
