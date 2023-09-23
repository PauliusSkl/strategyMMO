using Microsoft.AspNetCore.SignalR.Client;
using WarGame.Forms;
using WarGame.Forms.Models;

namespace WarGame;

public partial class LobbyForm : Form
{
    public LobbyForm()
    {
        InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var player = new Player() { Username = textBox1.Text };
        var test = new HubConnectionSingleton();
        var conn = test.GetInstance();

        await foreach (var model in conn.StreamAsync<GameStatusModel>("GetPlayerCount", player))
        {
            if (model.PlayerCount == 2)
            {
                this.Hide();
                var form = new GamePlayForm(conn, player);
                form.FormClosed += (s, args) => this.Close();
                if (File.Exists(Directory.GetCurrentDirectory() + "\\Resources\\background.png"))
                {
                    using var bmpTemp = new Bitmap(Directory.GetCurrentDirectory() + "\\Resources\\background.png");
                    form.BackgroundImage = new Bitmap(bmpTemp);
                }
                form.Show();
            }
            else
            {
                _ = MessageBox.Show("Waiting for 4 players to connect.");
            }
            break;
        }
    }
}