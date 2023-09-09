using Carmageddon.Forms;
using Carmageddon.Forms.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace Carmageddon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var player = new Player() { Username = textBox1.Text };
            this.Hide();
            var test = new HubConnectionSingleton();
            var conn = test.GetInstance();
            var form = new Form2(conn, player);
            form.FormClosed += (s, args) => this.Close();
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Resources\\background.png"))
            {
                using (var bmpTemp = new Bitmap(Directory.GetCurrentDirectory() + "\\Resources\\background.png"))
                {
                    form.BackgroundImage = new Bitmap(bmpTemp);
                }
            }
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Form3();
            form.Show();
        }
    }
}