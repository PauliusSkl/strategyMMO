using Microsoft.AspNetCore.SignalR.Client;

namespace WarGame.Forms;

public class BattleHub
{
    private readonly object lockObject = new();
    private HubConnection _connection = null;
    private const string URI = "https://localhost:7237/battle";

    public BattleHub()
    {
    }

    public HubConnection GetInstance()
    {
        lock (lockObject)
        {
            if (_connection == null)
            {
                _connection = new HubConnectionBuilder().WithUrl(URI).Build();

                _ = _connection.StartAsync();
            }
        }

        return _connection;
    }
}
