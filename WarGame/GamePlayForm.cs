using Microsoft.AspNetCore.SignalR.Client;
using Shared.Models;
using Shared.Models.AbstractUnitFactory;
using Shared.Models.Factory;
using Shared.Models.Strategy;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using WarGame.Forms;


namespace WarGame;

public partial class GamePlayForm : Form
{
    private readonly HubConnection _conn;
    private readonly Player _player;
    private readonly UnitFactory _basicUnitFactory;
    private readonly UnitFactory _upgradedUnitFactory;
    //WARRIORS STUFF -------
    private List<PictureBox> pictureBoxes = new List<PictureBox>();
    private List<Unit> warriors = new List<Unit>();
    //--------------------
    bool gameStart = false;
    private List<Nest> nestList = new List<Nest>();
    private bool DragonDead = false;
    private Dragon dragonClone = null;

    private List<PictureBox> dragonBoxes = new List<PictureBox>();

    //Obstacle stuff
    private List<Obstacle> obstaclesPlaces = new List<Obstacle>();
    private List<PictureBox> pictureBoxesObstacles = new List<PictureBox>();
    bool initialClient = false;

    private bool AddingObstacles = false;
    private bool AddingWater = false;
    private bool AddingMountain = false;
    private bool AddingLava = false;

    private int ObstacleCount = 1;

    int MovementCount = 0;


    private readonly HubConnection _battleHub = new BattleHub().GetInstance();

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();

    public GamePlayForm(HubConnection conn, Player player)
    {
        _conn = conn;
        _player = player;
        _basicUnitFactory = new BasicUnitFactory();
        _upgradedUnitFactory = new UpgradedUnitFactory();

        InitializeComponent();


        InitializeWarriors();

        AddPictureBoxesToList();
        DisplayWarriorsImages();

        SetPLayerMoves();
        SetPLayerInfo(player);
        UpdateObstacleCountLabel();

        OnReceivePictureCoordinates();
        OnReceiveWarriorList();

        OnReceiveObstacles();
        OnReceiveStrategies();
        OnAllTurnsEnded();
        OnDragonMove();

        OnReciveGameStart();
        OnReceiveDragonDead();
        //OnReceiveObstacless(); //Palikau kad buga parodyt

    }

  
    private void SetPLayerInfo(Player player)
    {
        label4.Text = "Team: " + player.Color;
        label4.ForeColor = Color.FromName(player.Color);
    }

    private async void SetPLayerMoves()
    {
        MovementCount = 0;
        foreach (var warrior in warriors)
        {
            if (warrior.Color == _player.Color)
            {
                MovementCount += warrior.Speed;
            }
        }
        if(MovementCount == 0)
        {
            await _conn.SendAsync("NewTurn");
        }

        label13.Text = "Moves left: " + MovementCount;
    }
    private void UpdateObstacleCountLabel()
    {
        label14.Text = "Game not started";
        obstacleCountLabel.Text = "Obstacles to place: " + ObstacleCount;


        if (ObstacleCount == 0)
        {
            _conn.SendAsync("InitiateGameStart");
        }

    }

    private void OnReciveGameStart()
    {
        _ = _conn.On("ReceiveGameStart", () =>
        {
            gameStart = true;

            label14.Text = "Game started";
            obstacleCountLabel.Visible = false;
            AddLava.Visible = false;
            AddWater.Visible = false;
            AddMountain.Visible = false;
        });
    }

    private async void UpdateLabelInfo()
    {
        MovementCount--;
        label13.Text = "Moves left: " + MovementCount;

        if (MovementCount == 0)
        {
            upButton.Visible = false;
            downButton.Visible = false;
            leftButton.Visible = false;
            rightButton.Visible = false;

            await _conn.SendAsync("NewTurn");
        }

    }

    private async void CheckForMyUnits(string color)
    {
        if(color == "enemy")
        {
            return;
        }
        int count = 0;
        foreach (var warrior in warriors)
        {
            if (warrior.Color == color)
            {
                count++;
            }
        }
        if (count == 1) {
            await _conn.SendAsync("NewTurn");
        }
        
    }
    private void AddPictureBoxesToList()
    {
        //uff
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
        pictureBoxes.Add(pictureBox18);
        dragonBoxes.Add(pictureBox18);
        foreach (var pictureBox in pictureBoxes)
        {
            pictureBox.Click += clickablePictureBox;
        }
    }
    private void InitializeWarriors()
    {
        string[] pngs = { "green", "blue", "yellow", "pink" };

        string imagesFolder = Path.Combine(Application.StartupPath, "Resources");
        //Basic Warriors
        for (int i = 0; i < pngs.Length; i++)
        {
            string color = pngs[i];
            int x = 0;
            int y = 0;
            Unit warrior = _basicUnitFactory.CreateWarrior(color, x, y);
            warrior.Image = Path.Combine(imagesFolder, $"warrior_{color}.png");

            warriors.Add(warrior);
        }
        //Basic Archers
        for (int i = 0; i < pngs.Length; i++)
        {
            string color = pngs[i];
            int x = 0;
            int y = 0;
            Unit archer = _basicUnitFactory.CreateArcher(color, x, y);
            archer.Image = Path.Combine(imagesFolder, $"archer_{color}.png");

            warriors.Add(archer);
        }
        //Basic Mages
        for (int i = 0; i < pngs.Length; i++)
        {
            string color = pngs[i];
            int x = 0;
            int y = 0;
            Unit mage = _basicUnitFactory.CreateMage(color, x, y);
            mage.Image = Path.Combine(imagesFolder, $"mage_{color}.png");

            warriors.Add(mage);
        }
        //Basic Tanks
        for (int i = 0; i < pngs.Length; i++)
        {
            string color = pngs[i];
            int x = 0;
            int y = 0;
            Unit tank = _basicUnitFactory.CreateTank(color, x, y);
            tank.Image = Path.Combine(imagesFolder, $"tank_{color}.png");

            warriors.Add(tank);
        }

        Nest nest = new Nest(0, 0, Path.Combine(imagesFolder, "nest_npc.png"));
        pictureBox19.Image = Image.FromFile(nest.Image);
        nest.X = pictureBox19.Location.X;
        nest.Y = pictureBox19.Location.Y;

        nestList.Add(nest);

        Dragon drag = new Dragon(0, 0, Path.Combine(imagesFolder, "dragon_npc.png"), nestList);
        //dragon = drag;
        warriors.Add(drag);

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


    private void OnAllTurnsEnded()
    {
        _ = _conn.On("ReceiveNewTurn", () =>
        {
            SetPLayerMoves();
            ChangeAllStrats();
        });
    }

    private void OnReceiveDragonDead()
    {
        _ = _battleHub.On("ReceiveDragonDead", () =>
        {
            Dragon newDragon = dragonClone;
            newDragon.X = pictureBox19.Location.X;
            newDragon.Y = pictureBox19.Location.Y;
            pictureBox19.Image = Image.FromFile(newDragon.Image);
            warriors.Add(newDragon);
            pictureBoxes.Add(pictureBox19);
            dragonBoxes.Add(pictureBox19);
            pictureBox19.Click += clickablePictureBox;

            nestList[0].X = 0;
            nestList[0].Y = 0;
            DragonDead = false;
        });
    }
    private void OnDragonMove()
    {

        _ = _conn.On<string>("DragonMove", (command) =>
        {
            if (!DragonDead)
            {
                MoveDragon(command);
            }
            else if (nestList.Count != 0)
            {
                _battleHub.SendAsync("DragonDead");

            }


        });

    }
    private void OnReceiveStrategies()
    {
        _ = _battleHub.On("InitiateChange", () =>
        {
            ChangeAllStrats();
        });
    }


    //PLANAS TAIP IMPLEMENTUOT BUVO
    //private void OnReceiveObstacless()
    //{
    //    _ = _battleHub.On<List<Obstacle>>("ReceiveObstaclesOnGrids", (newObstacles) =>
    //    {
    //        MessageBox.Show("Received obstacles");
    //    });
    //}

    private void OnReceiveObstacles()
    {
        _ = _battleHub.On<int, int, string>("ReceiveObstaclesOnGrid", (x, y, type) =>
        {

            Obstacle obstacle = CreateObstacleFromType(x, y, type);

            obstaclesPlaces.Add(obstacle);


            PictureBox newObstaclePictureBox = new PictureBox();

            newObstaclePictureBox.Size = new Size(50, 50);

            newObstaclePictureBox.Location = new Point(x, y);

            newObstaclePictureBox.Image = Image.FromFile(obstacle.Image);

            newObstaclePictureBox.Click += Obstacle_Click;

            Controls.Add(newObstaclePictureBox);

            newObstaclePictureBox.BringToFront();

            newObstaclePictureBox.Visible = true;

            pictureBoxesObstacles.Add(newObstaclePictureBox);
        });
    }


    private Obstacle CreateObstacleFromType(int x, int y, string type)
    {
        ObstacleCreator obstacleCreator;

        switch (type)
        {
            case "Shared.Models.Lava":
                obstacleCreator = new LavaCreator();
                break;
            case "Shared.Models.Water":
                obstacleCreator = new WaterCreator();
                break;
            case "Shared.Models.Mountain":
                obstacleCreator = new MountainCreator();
                break;
            default:
                obstacleCreator = new LavaCreator();
                break;
        }

        return obstacleCreator.CreateObstacle(x, y);
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
        string imagesFolder = Path.Combine(Application.StartupPath, "Resources");
        _ = _battleHub.On<List<Unit>, int>("ReceiveWarriorsStats", (updatedWarriors, nestHp) =>
        {
            if(nestHp != -999)
            { 
            foreach (var nest in nestList)
            {
                    nest.Health = nestHp;
                if (nestHp <= 0)
                {
                    nestList.Remove(nest);
                    this.Controls.Remove(pictureBox19);
                }
            }
            }
            for (int i = this.warriors.Count - 1; i >= 0; i--)
            {
                this.warriors[i].Health = updatedWarriors[i].Health;
                this.warriors[i].Attack = updatedWarriors[i].Attack;
                this.warriors[i].Range = updatedWarriors[i].Range;
                this.warriors[i].Speed = updatedWarriors[i].Speed;
                this.warriors[i].Kills = updatedWarriors[i].Kills;

                if (this.warriors[i].Kills == 2 && this.warriors[i].Upgraded == false)
                {
                    if (warriors[i].Type == "Warrior")
                    {
                        string color = warriors[i].Color;
                        int x = warriors[i].X;
                        int y = warriors[i].Y;
                        int kills = warriors[i].Kills;
                        Unit warrior = _upgradedUnitFactory.CreateWarrior(color, x, y);
                        warrior.Image = Path.Combine(imagesFolder, $"warrior_{color}.png");

                        warriors[i] = warrior;
                    }
                    if (warriors[i].Type == "Archer")
                    {
                        string color = warriors[i].Color;
                        int x = warriors[i].X;
                        int y = warriors[i].Y;
                        int kills = warriors[i].Kills;
                        Unit archer = _upgradedUnitFactory.CreateArcher(color, x, y);
                        archer.Image = Path.Combine(imagesFolder, $"archer_{color}.png");

                        warriors[i] = archer;
                    }
                    if (warriors[i].Type == "Mage")
                    {
                        string color = warriors[i].Color;
                        int x = warriors[i].X;
                        int y = warriors[i].Y;
                        int kills = warriors[i].Kills;
                        Unit mage = _upgradedUnitFactory.CreateMage(color, x, y);
                        mage.Image = Path.Combine(imagesFolder, $"mage_{color}.png");

                        warriors[i] = mage;
                    }
                    if (warriors[i].Type == "Tank")
                    {
                        string color = warriors[i].Color;
                        int x = warriors[i].X;
                        int y = warriors[i].Y;
                        int kills = warriors[i].Kills;
                        Unit tank = _upgradedUnitFactory.CreateTank(color, x, y);
                        tank.Image = Path.Combine(imagesFolder, $"tank_{color}.png");

                        warriors[i] = tank;
                    }
                }
                if (this.warriors[i].Health <= 0)
                {
                    PictureBox deadPictureBox = pictureBoxes[i];

                    //Neziurekit kas cia vyksta :((
                    if (this.warriors[i] is Dragon dragon && this.warriors[i].Color == "enemy")
                    {
                        DragonDead = true;
                        this.dragonClone = dragon.ShallowClone();

                        //atsiskaitymui
                        //this.dragonClone = dragon.DeepClone();
                        //if(dragonClone.Nest == dragon.Nest)
                        //{
                        //    MessageBox.Show("Shallow clone");
                        //}

                        
                        dragonBoxes.Remove(deadPictureBox);
                        if(deadPictureBox == pictureBox19)
                        {
                            dragonBoxes.Remove(pictureBox19);
                            this.Controls.Remove(pictureBox19);
                            nestList.Remove(nestList[0]);
                        }

                    }
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

    private Obstacle CheckForObstacle(Unit attacker, int newX, int newY)
    {
        foreach (var obstacle in obstaclesPlaces)
        {

            Rectangle attackerBounds = new Rectangle(newX, newY, 40, 40);

            Rectangle obstacleBounds = new Rectangle(obstacle.X, obstacle.Y, 40, 40);

            if (attackerBounds.IntersectsWith(obstacleBounds))
            {
                return obstacle;
            }
        }

        return null;
    }

    private Nest CheckForNest(Unit attacker, int newX, int newY)
    {
        foreach (var nest in nestList)
        {
            int range = attacker.Range;
            int attackRange = (range - 1) * 50;

            int distanceX = Math.Abs((newX + 25) - (nest.X + 25));
            int distanceY = Math.Abs((newY + 25) - (nest.Y + 25));


            if ((distanceX <= attackRange + 25 && distanceY <= 25) || (distanceX <= 25 && distanceY <= attackRange + 25))
            {
                return nest;
            }
        }

        return null;
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
        bool hasMoved = false;
        Unit attackingWarrior = GetWarriorFromPictureBox(currentWarrior);
        if (attackingWarrior != null)
        {
            int nestHealth = -999;
            Unit defendingWarrior = CheckForCollision(attackingWarrior, X, Y);

            bool team8 = CheckForTeammate(attackingWarrior, X, Y);

            Obstacle obstacle = CheckForObstacle(attackingWarrior, X, Y);

            List<Obstacle> applyEffect = CheckAroundForObstacles(attackingWarrior);

            if (applyEffect != null)
            {
                foreach (var item in applyEffect)
                {
                    item.ApplyEffect(attackingWarrior);
                }
                hasMoved = true;
            }

            Nest nest = CheckForNest(attackingWarrior, X, Y);

            if (defendingWarrior != null)
            {
                defendingWarrior.Health -= attackingWarrior.Attack;
                if (defendingWarrior.Health <= 0)
                {
                    CheckForMyUnits(defendingWarrior.Color);
                    attackingWarrior.Kills = attackingWarrior.Kills + 1;
                }
                hasMoved = true;
            }
            else if (!team8 && (obstacle == null) && (nest == null))
            {
                currentWarrior.Location = new Point(X, Y);
                hasMoved = true;
            }
            else if (nest != null)
            {
                nest.Health -= attackingWarrior.Attack;
                hasMoved = true;
                nestHealth = nest.Health;
            }
            
            await _battleHub.SendAsync("UpdateWarriorsStats", warriors, nestHealth);
        }

        if (hasMoved)
        {
            UpdateLabelInfo();
        }
    }

    private List<Obstacle> CheckAroundForObstacles(Unit warrior)
    {
        int gridSize = 50;
        Obstacle obstacle;
        List<Obstacle> obstaclesAround = new List<Obstacle>();

        obstacle = CheckForObstacle(warrior, warrior.X, warrior.Y - gridSize);
        if (obstacle != null)
        {
            obstaclesAround.Add(obstacle);
        }


        obstacle = CheckForObstacle(warrior, warrior.X, warrior.Y + gridSize);
        if (obstacle != null)
        {
            obstaclesAround.Add(obstacle);
        }

        obstacle = CheckForObstacle(warrior, warrior.X - gridSize, warrior.Y);
        if (obstacle != null)
        {
            obstaclesAround.Add(obstacle);
        }

        obstacle = CheckForObstacle(warrior, warrior.X + gridSize, warrior.Y);
        if (obstacle != null)
        {
            obstaclesAround.Add(obstacle);
        }

        return obstaclesAround;

    }

    private void DisplayStats(int index)
    {

        if (index >= 0 && index < warriors.Count)
        {
            Unit selectedWarrior = warriors[index];

            int health = selectedWarrior.Health;
            int attack = selectedWarrior.Attack;
            int range = selectedWarrior.Range;
            int kills = selectedWarrior.Kills;
            bool upgraded = selectedWarrior.Upgraded;
            int speed = selectedWarrior.Speed;
            int X = selectedWarrior.X;
            int Y = selectedWarrior.Y;

            healthLabel.Text = $"Health: {health}";
            attackLabel.Text = $"Attack: {attack} Speed: {speed}";
            rangeLabel.Text = $"Range: {range}, X: {X}, Y: {Y}";
            killsLabel.Text = $"Kills: {kills}";
            if (upgraded == true)
            {
                upgradedLabel.Text = "Upgraded";
            }
            else
            {
                upgradedLabel.Text = "";
            }

            healthLabel.Visible = true;
            attackLabel.Visible = true;
            rangeLabel.Visible = true;
            killsLabel.Visible = true;
            upgradedLabel.Visible = true;
        }
    }

    private void HandleClickedPicture()
    {
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

    private void clickablePictureBox(object sender, EventArgs e)
    {
        upButton.Visible = false;
        downButton.Visible = false;
        leftButton.Visible = false;
        rightButton.Visible = false;

        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxes.IndexOf(selectedPictureBox);

        DisplayStats(selectedIndex);

        Unit warrior = GetWarriorFromPictureBox(selectedPictureBox);

        if (warrior.Color == _player.Color && MovementCount > 0 && gameStart)
        {
            upButton.Visible = true;
            downButton.Visible = true;
            leftButton.Visible = true;
            rightButton.Visible = true;
        }

        HandleClickedPicture();
    }


    private void Add_Lava(object sender, EventArgs e)
    {
        if (ObstacleCount > 0)
        {
            AddingObstacles = true;

            AddingLava = true;

            selectedGridPictureBox = pictureBox1;
        }
    }

    private void Add_Water(object sender, EventArgs e)
    {
        if (ObstacleCount > 0)
        {
            AddingObstacles = true;
            AddingWater = true;
            selectedGridPictureBox = pictureBox1;
        }
    }

    private void Add_Mountain(object sender, EventArgs e)
    {
        if (ObstacleCount > 0)
        {
            AddingObstacles = true;
            AddingMountain = true;
            selectedGridPictureBox = pictureBox1;
        }

    }
    private PictureBox selectedGridPictureBox;
    private async void pictureBox1_Click(object sender, EventArgs e)
    {
        if (AddingObstacles)
        {
            int gridSize = 50;
            Point clickPosition = PointToClient(Cursor.Position);
            int nearestX = (clickPosition.X - selectedGridPictureBox.Location.X) / gridSize * gridSize + selectedGridPictureBox.Location.X;
            int nearestY = (clickPosition.Y - selectedGridPictureBox.Location.Y) / gridSize * gridSize + selectedGridPictureBox.Location.Y;

            PictureBox newObstaclePictureBox = new PictureBox();
            newObstaclePictureBox.Size = new Size(50, 50);
            newObstaclePictureBox.Location = new Point(nearestX + 1, nearestY + 3);

            ObstacleCreator obstacleCreator;

            if (AddingLava)
            {
                obstacleCreator = new LavaCreator();
                AddingLava = false;
            }
            else if (AddingWater)
            {
                obstacleCreator = new WaterCreator();
                AddingWater = false;
            }
            else
            {
                obstacleCreator = new MountainCreator();
                AddingMountain = false;
            }

            newObstaclePictureBox.Click += Obstacle_Click;

            Obstacle obstacle = obstacleCreator.CreateObstacle(newObstaclePictureBox.Location.X, newObstaclePictureBox.Location.Y);

            obstaclesPlaces.Add(obstacle);
            //await _battleHub.SendAsync("UpdateObstaclesOnGrids", obstaclesPlaces); // Neveike taip :( labai idomus bugas nes veikia pries idedant i masyva

            await _battleHub.SendAsync("UpdateObstaclesOnGrid", obstacle.X, obstacle.Y, obstacle.GetType().ToString());


            newObstaclePictureBox.Image = Image.FromFile(obstacle.Image);



            Controls.Add(newObstaclePictureBox);
            newObstaclePictureBox.BringToFront();

            pictureBoxesObstacles.Add(newObstaclePictureBox);

            AddingObstacles = false;
            ObstacleCount--;
            UpdateObstacleCountLabel();
        }

    }

    private void DisplayObstacleInfo(int index)
    {
        if (index >= 0 && index < obstaclesPlaces.Count)
        {
            Obstacle selectedObstacle = obstaclesPlaces[index];

            List<string> info = selectedObstacle.DisplayInfo();

            healthLabel.Text = info[0];
            attackLabel.Text = info[1];
            rangeLabel.Text = info[2];

            healthLabel.Visible = true;
            attackLabel.Visible = true;
            rangeLabel.Visible = true;
        }
    }

    private void Obstacle_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        int selectedIndex = pictureBoxesObstacles.IndexOf(selectedPictureBox);

        DisplayObstacleInfo(selectedIndex);
    }

    private void ChangeStrategy_Click(object sender, EventArgs e)
    {
        initialClient = true;
        ChangeAllStrats();
    }

    private async void ChangeAllStrats()
    {
        foreach (var obstacle in obstaclesPlaces)
        {
            if (obstacle._effectStrategy is SpeedStrategy)
            {
                obstacle.SetEffectStrategy(new AttackStrategy());
            }
            else if (obstacle._effectStrategy is AttackStrategy)
            {
                obstacle.SetEffectStrategy(new SpeedStrategy());
            }
            else if (obstacle._effectStrategy is DamageStrategy)
            {
                obstacle.SetEffectStrategy(new HealingStrategy());
            }
            else
            {
                obstacle.SetEffectStrategy(new DamageStrategy());
            }
        }

        if (initialClient)
        {
            await _battleHub.SendAsync("ChangeStrategies");
            initialClient = false;
        }
    }

    private void MoveDragon(string direction)
    {

        foreach (var pictureBox in dragonBoxes)
        {
            clickablePictureBox(pictureBox, EventArgs.Empty);
            switch (direction)
            {
                case "up":
                    upButton_Click(upButton, EventArgs.Empty);
                    break;
                case "down":
                    downButton_Click(downButton, EventArgs.Empty);
                    break;
                case "left":
                    leftButton_Click(leftButton, EventArgs.Empty);
                    break;
                case "right":
                    rightButton_Click(rightButton, EventArgs.Empty);
                    break;
            }
        }

    }

    private void pictureBox19_Click(object sender, EventArgs e)
    {
        selectedPictureBox = (PictureBox)sender;

        healthLabel.Text = $"Health: {nestList[0].Health}";


        healthLabel.Visible = true;

        HandleClickedPicture();
    }
}

