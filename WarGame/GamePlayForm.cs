using Microsoft.AspNetCore.SignalR.Client;
using Shared.Models;
using Shared.Models.Factory;
using System.Runtime.InteropServices;
using WarGame.Forms;


namespace WarGame;

public partial class GamePlayForm : Form
{
    private readonly HubConnection _conn;
    private readonly Player _player;

    //WARRIORS STUFF -------
    private List<PictureBox> pictureBoxes = new List<PictureBox>();
    private List<Unit> warriors = new List<Unit>();
    //--------------------

    private List<Obstacle> obstacles = new List<Obstacle>();
    private List<PictureBox> pictureBoxesObstacles = new List<PictureBox>();
    private bool AddingObstacles = false;
    private bool AddingWater = false;
    private bool AddingMountain = false;
    private bool AddingLava = false;


    private readonly HubConnection _battleHub = new BattleHub().GetInstance();

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();

    public GamePlayForm(HubConnection conn, Player player)
    {
        _conn = conn;
        _player = player;
        InitializeComponent();


        InitializeWarriors();
        AddPictureBoxesToList();
        DisplayWarriorsImages();


        OnReceivePictureCoordinates();
        OnReceiveWarriorList();

    }


    private void AddPictureBoxesToList()
    {
        pictureBoxes.Add(pictureBox2);
        pictureBoxes.Add(pictureBox3);
        pictureBoxes.Add(pictureBox4);
        pictureBoxes.Add(pictureBox5);
        pictureBoxes.Add(pictureBox6);
        pictureBoxes.Add(pictureBox7);
        pictureBoxes.Add(pictureBox8);
        pictureBoxes.Add(pictureBox9);
        pictureBoxes.Add(pictureBox10);
        pictureBoxes.Add(pictureBox11);
        pictureBoxes.Add(pictureBox12);
        pictureBoxes.Add(pictureBox13);
        pictureBoxes.Add(pictureBox14);
        pictureBoxes.Add(pictureBox15);
        pictureBoxes.Add(pictureBox16);
        pictureBoxes.Add(pictureBox17);
    }
    private void InitializeWarriors()
    {
        string[] pngs = { "green", "blue", "yellow", "pink" };

        string imagesFolder = Path.Combine(Application.StartupPath, "Resources");

        for (int i = 0; i < 4; i++)
        {
            warriors.Add(new Warrior
            {
                Health = 200,
                Attack = 50,
                Range = 1,
                X = 0,
                Y = 0,
                Color = pngs[i],
                Image = Path.Combine(imagesFolder, $"warrior_{pngs[i]}.png")
                //Image = "./Resources/warrior_" + pngs[i] + ".png"
            });
        }

        for (int i = 0; i < 4; i++)
        {
            warriors.Add(new Archer
            {
                Health = 50,
                Attack = 50,
                Range = 2,
                X = 0,
                Y = 0,
                Color = pngs[i],
                Image = Path.Combine(imagesFolder, $"archer_{pngs[i]}.png")
                //Image = "./Resources/warrior_" + pngs[i] + ".png"
            });
        }
        for (int i = 0; i < 4; i++)
        {
            warriors.Add(new Mage
            {
                Health = 50,
                Attack = 100,
                Range = 2,
                X = 0,
                Y = 0,
                Color = pngs[i],
                Image = Path.Combine(imagesFolder, $"mage_{pngs[i]}.png")
                //Image = "./Resources/warrior_" + pngs[i] + ".png"
            });
        }

        for (int i = 0; i < 4; i++)
        {
            warriors.Add(new Tank
            {
                Health = 300,
                Attack = 10,
                Range = 1,
                X = 0,
                Y = 0,
                Color = pngs[i],
                Image = Path.Combine(imagesFolder, $"tank_{pngs[i]}.png")
                //Image = "./Resources/warrior_" + pngs[i] + ".png"
            });
        }
    }
    private void DisplayWarriorsImages()
    {
        for (int i = 0; i < pictureBoxes.Count; i++)
        {
            pictureBoxes[i].Image = Image.FromFile(warriors[i].Image);
            warriors[i].X = pictureBoxes[i].Location.X;
            warriors[i].Y = pictureBoxes[i].Location.Y;
        }
    }

    private void OnReceivePictureCoordinates()
    {
        _ = _battleHub.On<string, int, int>("ReceivePictureCoordinates", (pictureName, x, y) =>
        {
            var pictureToUpdate = Controls.OfType<PictureBox>().FirstOrDefault(p => p.Name == pictureName);
            if (pictureToUpdate != null)
            {
                Unit warriorToUpdate = GetWarriorFromPictureBox(pictureToUpdate);

                if (warriorToUpdate != null)
                {
                    warriorToUpdate.X = x;
                    warriorToUpdate.Y = y;
                }
                pictureToUpdate.Location = new Point(x, y);
            }
        });
    }

    private void OnReceiveWarriorList()
    {
        _ = _battleHub.On<List<Unit>>("ReceiveWarriorsStats", (updatedWarriors) =>
        {
            for (int i = this.warriors.Count - 1; i >= 0; i--)
            {
                this.warriors[i].Health = updatedWarriors[i].Health;
                this.warriors[i].Attack = updatedWarriors[i].Attack;
                this.warriors[i].Range = updatedWarriors[i].Range;

                if (this.warriors[i].Health <= 0)
                {

                    PictureBox deadPictureBox = pictureBoxes[i];
                    this.Controls.Remove(deadPictureBox);


                    this.warriors.RemoveAt(i);

                    this.pictureBoxes.RemoveAt(i);
                }
            }
        });
    }


    private void Form2_Load(object sender, EventArgs e)
    {
        using var bmpTemp = new Bitmap(Directory.GetCurrentDirectory() + "\\Resources\\500x500.png");
        pictureBox1.Image = new Bitmap(bmpTemp);
    }

    private async Task<bool> ConfirmUser()
    {
        var confimed = false;
        await foreach (bool result in _battleHub.StreamAsync<bool>("ConfirmPlayer", _player.Username))
        {
            confimed = result;
            break;
        }
        return confimed;
    }
    private Unit CheckForCollision(Unit attacker, int newX, int newY)
    {
        foreach (var enemy in warriors)
        {
            if (attacker == enemy || enemy.Color == attacker.Color)
            {
                continue;
            }

            int range = attacker.Range;
            int attackRange = (range - 1) * 50;

            int distanceX = Math.Abs((newX + 25) - (enemy.X + 25));
            int distanceY = Math.Abs((newY + 25) - (enemy.Y + 25));


            if ((distanceX <= attackRange + 25 && distanceY <= 25) || (distanceX <= 25 && distanceY <= attackRange + 25))
            {
                return enemy;
            }
        }

        return null;
    }


    private bool CheckForTeammate(Unit attacker, int newX, int newY)
    {
        foreach (var obstacle in warriors)
        {
            if (obstacle.Color != attacker.Color)
            {
                continue;
            }

            Rectangle attackerBounds = new Rectangle(newX, newY, 40, 40);

            Rectangle defenderBounds = new Rectangle(obstacle.X, obstacle.Y, 40, 40);

            if (attackerBounds.IntersectsWith(defenderBounds))
            {
                return true;
            }
        }

        return false;
    }

    private Unit GetWarriorFromPictureBox(PictureBox pictureBox)
    {
        int selectedIndex = pictureBoxes.IndexOf(pictureBox);
        if (selectedIndex >= 0 && selectedIndex < warriors.Count)
        {
            return warriors[selectedIndex];
        }
        return null;
    }
    private PictureBox selectedPictureBox;

    private async void upButton_Click(object sender, EventArgs e)
    {
        if (selectedPictureBox != null)
        {
            int currentY = selectedPictureBox.Location.Y;
            int currentX = selectedPictureBox.Location.X;
            if (currentY - 50 >= 10)
            {
                int newY = currentY - 50;
                handleBattle(selectedPictureBox, currentX, newY);
            }
            await _battleHub.SendAsync("UpdatePictureCoordinates", selectedPictureBox.Name, selectedPictureBox.Location.X, selectedPictureBox.Location.Y);
        }

    }
    private async void downButton_Click(object sender, EventArgs e)
    {
        if (selectedPictureBox != null)
        {
            int currentY = selectedPictureBox.Location.Y;
            int currentX = selectedPictureBox.Location.X;
            if (currentY + 50 <= 470)
            {
                int newY = currentY + 50;
                handleBattle(selectedPictureBox, currentX, newY);
            }
            await _battleHub.SendAsync("UpdatePictureCoordinates", selectedPictureBox.Name, selectedPictureBox.Location.X, selectedPictureBox.Location.Y);
        }

    }

    private async void leftButton_Click(object sender, EventArgs e)
    {
        if (selectedPictureBox != null)
        {
            int currentX = selectedPictureBox.Location.X;
            int currentY = selectedPictureBox.Location.Y;
            if (currentX - 50 >= 420)
            {
                int newX = currentX - 50;

                handleBattle(selectedPictureBox, newX, currentY);
            }
            await _battleHub.SendAsync("UpdatePictureCoordinates", selectedPictureBox.Name, selectedPictureBox.Location.X, selectedPictureBox.Location.Y);
        }

    }

    private async void rightButton_Click(object sender, EventArgs e)
    {
        if (selectedPictureBox != null)
        {
            int currentX = selectedPictureBox.Location.X;
            int currentY = selectedPictureBox.Location.Y;
            if (currentX + 50 <= 920)
            {
                int newX = currentX + 50;
                handleBattle(selectedPictureBox, newX, currentY);
            }
            await _battleHub.SendAsync("UpdatePictureCoordinates", selectedPictureBox.Name, selectedPictureBox.Location.X, selectedPictureBox.Location.Y);
        }
    }

    private async void handleBattle(PictureBox currentWarrior, int X, int Y)
    {
        Unit attackingWarrior = GetWarriorFromPictureBox(currentWarrior);
        Unit defendingWarrior = CheckForCollision(attackingWarrior, X, Y);

        bool team8 = CheckForTeammate(attackingWarrior, X, Y);

        if (defendingWarrior != null)
        {
            defendingWarrior.Health -= attackingWarrior.Attack;

            await _battleHub.SendAsync("UpdateWarriorsStats", warriors);
        }
        else if (!team8)
        {
            currentWarrior.Location = new Point(X, Y);
        }
    }

    private void pictureBox2_Click_1(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void DisplayStats(int index)
    {

        if (index >= 0 && index < warriors.Count)
        {
            Unit selectedWarrior = warriors[index];

            int health = selectedWarrior.Health;
            int attack = selectedWarrior.Attack;
            int range = selectedWarrior.Range;
            int X = selectedWarrior.X;
            int Y = selectedWarrior.Y;



            healthLabel.Text = $"Health: {health}";
            attackLabel.Text = $"Attack: {attack}";
            rangeLabel.Text = $"Range: {range}, X: {X}, Y: {Y}";

            healthLabel.Visible = true;
            attackLabel.Visible = true;
            rangeLabel.Visible = true;
        }
    }

    private void HandleClickedPicture()
    {
        upButton.Visible = true;
        downButton.Visible = true;
        leftButton.Visible = true;
        rightButton.Visible = true;

        selectedPictureBox.BorderStyle = BorderStyle.FixedSingle;
        selectedPictureBox.BackColor = Color.Red;

        foreach (PictureBox pb in Controls.OfType<PictureBox>())
        {
            if (pb != selectedPictureBox)
            {
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.BackColor = Color.Transparent;
            }
        }
    }

    private void healthLabel_Click(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private void pictureBox6_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox7_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox8_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox9_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox10_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox11_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox13_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox12_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox14_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox15_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox16_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void pictureBox17_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        HandleClickedPicture();
    }

    private void Add_Lava(object sender, EventArgs e)
    {
        AddingObstacles = true;

        AddingLava = true;

        selectedGridPictureBox = pictureBox1;
    }

    private void Add_Water(object sender, EventArgs e)
    {

        AddingObstacles = true;
        AddingWater = true;
        selectedGridPictureBox = pictureBox1;
    }

    private void Add_Mountain(object sender, EventArgs e)
    {
        AddingObstacles = true;
        AddingMountain = true;
        selectedGridPictureBox = pictureBox1;

    }
    private PictureBox selectedGridPictureBox;
    private void pictureBox1_Click(object sender, EventArgs e)
    {
        if (AddingObstacles)
        {
            int gridSize = 50;
            Point clickPosition = PointToClient(Cursor.Position);
            int nearestX = (clickPosition.X - selectedGridPictureBox.Location.X) / gridSize * gridSize + selectedGridPictureBox.Location.X;
            int nearestY = (clickPosition.Y - selectedGridPictureBox.Location.Y) / gridSize * gridSize + selectedGridPictureBox.Location.Y;

            PictureBox newObstaclePictureBox = new PictureBox();
            newObstaclePictureBox.Size = new Size(50, 50);
            newObstaclePictureBox.Location = new Point(nearestX + 2, nearestY + 3);

            ObstacleCreator obstacleCreator;

            if (AddingLava)
            {
                newObstaclePictureBox.Click += LavaBox_Click;
                obstacleCreator = new LavaCreator();
                AddingLava = false;
            }
            else if (AddingWater)
            {
                newObstaclePictureBox.Click += WaterBox_Click;
                obstacleCreator = new WaterCreator();
                AddingWater = false;
            }
            else
            {
                newObstaclePictureBox.Click += MountainBox_Click;
                obstacleCreator = new MountainCreator();
                AddingMountain = false;
            }

            Obstacle obstacle = obstacleCreator.CreateObstacle(newObstaclePictureBox.Location.X, newObstaclePictureBox.Location.Y);
            obstacles.Add(obstacle);
            newObstaclePictureBox.Image = Image.FromFile(obstacle.Image);
            


            Controls.Add(newObstaclePictureBox);
            newObstaclePictureBox.BringToFront();

            pictureBoxesObstacles.Add(newObstaclePictureBox);

            AddingObstacles = false;
        }
    }

    private void DisplayObstacleInfo(int index)
    {
        if (index >= 0 && index < obstacles.Count)
        {
            Obstacle selectedObstacle = obstacles[index];

            List<string> info = selectedObstacle.DisplayInfo();

            healthLabel.Text = info[0];
            attackLabel.Text = info[1];
            rangeLabel.Text = info[2];

            healthLabel.Visible = true;
            attackLabel.Visible = true;
            rangeLabel.Visible = true;
        }
    }

    private void LavaBox_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxesObstacles.IndexOf(selectedPictureBox);

        DisplayObstacleInfo(selectedIndex);
    }

    private void WaterBox_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxesObstacles.IndexOf(selectedPictureBox);

        DisplayObstacleInfo(selectedIndex);
    }

    private void MountainBox_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxesObstacles.IndexOf(selectedPictureBox);

        DisplayObstacleInfo(selectedIndex);
    }
}

