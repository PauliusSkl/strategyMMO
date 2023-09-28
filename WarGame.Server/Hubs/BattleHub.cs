using Microsoft.AspNetCore.SignalR;
using Shared.Models;
using System.Runtime.CompilerServices;

namespace WarGame.API.Hubs;

public class BattleHub : Hub
{
    public async IAsyncEnumerable<bool> ConfirmPlayer([EnumeratorCancellation] CancellationToken cancellationToken, string username)
    {
        if (username == null)
        {
            yield return false;
        }

        var player = PlayersList.GetPlayer(username);

        yield return true;

        await Task.Delay(1000, cancellationToken);
    }

    public async Task UpdatePictureCoordinates(string pictureName, int x, int y)
    {
        await Clients.All.SendAsync("ReceivePictureCoordinates", pictureName, x, y);
    }

    public async Task UpdateWarriorsStats(List<Unit> warriors)
    {
        await Clients.All.SendAsync("ReceiveWarriorsStats", warriors);
    }


    //😭
    //public async Task UpdateObstaclesOnGrid(List<Obstacle> obstacles)
    //{
    //    await Clients.Others.SendAsync("ReceiveObstaclesOnGrid", obstacles);
    //}

    public async Task UpdateObstaclesOnGrid(int x, int y, string type)
    {
        await Clients.Others.SendAsync("ReceiveObstaclesOnGrid", x, y, type);
    }
}
