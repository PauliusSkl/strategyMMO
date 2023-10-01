using Microsoft.AspNetCore.SignalR.Client;
using Shared.Models;
using WarGame.Forms;

namespace WarGame;

public partial class LobbyForm : Form
{
    public LobbyForm()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var player = new Player() { Username = textBox1.Text };
        var test = new HubConnectionSingleton();
        var conn = test.GetInstance();

        conn.SendAsync("GetLastColor");

        conn.On<string>("ReceiveColor", (color) =>
        {
            player.Color = color;
        });

        await foreach (var model in conn.StreamAsync<GameStatusModel>("GetPlayerCount", player))
        {
            if (model.PlayerCount == 4)
            {
                var form = new GamePlayForm(conn, player);
                form.FormClosed += (s, args) => Close();
                if (File.Exists(Directory.GetCurrentDirectory() + "\\Resources\\background.png"))
                {
                    using var bmpTemp = new Bitmap(Directory.GetCurrentDirectory() + "\\Resources\\background.png");
                    form.BackgroundImage = new Bitmap(bmpTemp);
                }
                Hide();
                form.Show();
                break;
            }
            else
            {
                MainLabel.Text = $"{model.PlayerCount}/4 players connected";
            }
        }
    }
}