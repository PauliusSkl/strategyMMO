using Microsoft.AspNetCore.SignalR.Client;

namespace Carmageddon.Forms
{
    public class BattleHub
    {
        private object lockObject = new object();
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

                    _connection.StartAsync();
                }
            }

            return _connection;
        }
    }
}
