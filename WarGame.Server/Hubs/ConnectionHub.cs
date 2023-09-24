﻿using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using WarGame.API.Models;
using WarGame.API.Strategy;

namespace WarGame.API.Hubs;

public class ConnectionHub : Hub
{
    private static readonly GameStatusModel _gameStatusModel = new()
    {
        PlayerCount = 0,
        BattleDuration = DateTime.MinValue,
        MovesCount = 0,
        PlayerNames = new List<string>()
    };

    public async IAsyncEnumerable<GameStatusModel> GetPlayerCount(CancellationToken cancellationToken, Player player)
    {
        var gameStatus = new GameStatus(new PlayerCount());
        while (true)
        {
            if (!PlayersList.Exists(player))
            {
                PlayersList.AddPlayer(player);
            }

            yield return gameStatus.ExecuteStrategy(_gameStatusModel);
            await Task.Delay(1000, cancellationToken);
        }
    }

    public async IAsyncEnumerable<GameStatusModel> GetMovesCount(CancellationToken cancellationToken, bool playerShoot)
    {
        var gameStatus = new GameStatus(new MovesCount());
        if (!playerShoot)
        {
            yield return _gameStatusModel;
        }
        else
        {
            yield return gameStatus.ExecuteStrategy(_gameStatusModel);
        }
        await Task.Delay(1000, cancellationToken);
    }

    public async IAsyncEnumerable<GameStatusModel> GetPlayerNames(CancellationToken cancellationToken)
    {
        var gameStatus = new GameStatus(new PlayerNames());
        while (true)
        {
            yield return gameStatus.ExecuteStrategy(_gameStatusModel);
            await Task.Delay(1000, cancellationToken);
        }
    }

    public void SavePlayerCars(Player player, string carsJson)
    {
        var cars = JsonConvert.DeserializeObject<List<Car>>(carsJson);

        PlayersList.AddPlayerCars(player, cars);
    }
}