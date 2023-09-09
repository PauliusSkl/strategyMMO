using Carmageddon.Forms.AbstractFactory;
using Carmageddon.Forms.Adapter;
using Carmageddon.Forms.Facade;
using Carmageddon.Forms.Command;
using Carmageddon.Forms.Factory;
using Carmageddon.Forms.Models;
using Carmageddon.Forms.Observer;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Diagnostics;
using static Carmageddon.Forms.Models.Car;
using Carmageddon.Forms.Bridge__Shooting_;
using Carmageddon.Forms.TemplateMethod;
using System.Runtime.InteropServices;
using Carmageddon.Forms.Interpreter;
using Carmageddon.Forms.ChainOfResp;
using Carmageddon.Forms.Memento;
using Carmageddon.Forms.ChainOfResp.Mediator;
using Carmageddon.Forms.Visitor;
using Carmageddon.Forms;

namespace Carmageddon
{
    public partial class Form2 : Form, IConsoleLogger
    {
        private HubConnection _conn;
        private Player _player;
        private WeaponFactory _weaponFactory;
        private Car selectedCar;
        private Car previousCar;
        private IGrid _enemyGrid;
        private Grid _playerGrid;
        //private Stack<Image> previousImages = new Stack<Image>(); // jei kazkas neveiktu palieku dar
        //private Stack<Car> _cars = new Stack<Car>();
        private Invoker invoker = new Invoker(new ConcreteCommand(new Receiver()));
        private bool rotate = false;
        private bool stop = false;
        private bool display = false;
        private bool displayShots = false;
        private bool carsSent = false;
        private Stopwatch stopWatch = new();
        private MachineGun? machinegun = null ;
        private Cannon? cannon = null;
        private AbstractShootingHandler shootingHandler;
        private readonly ShotEventHandler _topLeftHandler = new TopLeftEventHandler();
        private readonly ShotEventHandler _topRightHandler = new TopRightEventHandler();
        private readonly ShotEventHandler _bottomLeftHandler = new BottomLeftEventHandler();
        private readonly ShotEventHandler _bottomRightHandler = new BottomRightEventHandler();
        private readonly AbstractGridMediator _gridMediator = new GridMediator();
        private Originator originator = new Originator();
        private Caretaker caretaker = new Caretaker();
        private HubConnection _battleHub = new BattleHub().GetInstance();
        private string turnMessage = "";
        private bool turnMade = false;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form2(HubConnection conn, Player player)
        {
            AllocConsole();
            IConsoleLogger logger = new ConsoleLoggerAdapter();
            logger.LogMessage("Player " + player.Username + " has logged in", false);
            _enemyGrid = new Grid(this);
            _playerGrid = new Grid(this);
            _conn = conn;
            _player = player;
            InitializeComponent();
            shootingHandler = new RefinedShootingHandler();
            SetupBonuses();
            comboBox1.Text = "--Select stats--";
            comboBox1.Items.Add("Player count");
            comboBox1.Items.Add("Battle duration");
            comboBox1.Items.Add("Player names");
            comboBox1.Items.Add("Total shots");

            ThreadPool.QueueUserWorkItem(HandleConsole, SynchronizationContext.Current);
            GetPlayerCount(_conn, _player);
            button8.Visible = false;
        }

        void SetupBonuses()
        {
            var rnd = new Random();
            var bonuses = new List<(int, int)> { (-1, -1), (0, -1), (1, -1), (1, 1), (0, 1), (1, 0), (0, 0)};

            var index = rnd.Next(6);
            TopLeftEventHandler.ShotBonus = bonuses[index];
            bonuses.RemoveAt(index);
            index = rnd.Next(5);
            TopRightEventHandler.ShotBonus = bonuses[index];
            bonuses.RemoveAt(index);
            index = rnd.Next(4);
            BottomLeftEventHandler.ShotBonus = bonuses[index];
            bonuses.RemoveAt(index);
            index = rnd.Next(3);
            BottomRightEventHandler.ShotBonus = bonuses[index];
            bonuses.RemoveAt(index);

            _topLeftHandler.SetSuccessor(_topRightHandler)
                .SetSuccessor(_bottomLeftHandler)
                .SetSuccessor(_bottomRightHandler);

            _gridMediator.Register(_topLeftHandler);
            _gridMediator.Register(_topRightHandler);
            _gridMediator.Register(_bottomLeftHandler);
            _gridMediator.Register(_bottomRightHandler);
        }

        void HandleConsole(object state)
        {
            var context = (SynchronizationContext)state;
            Console.WriteLine("Console starting...\n\n");

            while (true)
            {
                Console.WriteLine("Type in your desired command [shoot | car count]:\n");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "car count":
                        var interpreterContext1 = new InterpreterContext { Parameter3 = _playerGrid.Cars.Count };
                        new CarCountExpression().Interpret(interpreterContext1, context, this);
                        break;
                    case "shoot":
                        Console.WriteLine("\nEnter X coordinates:");
                        char coordsX = char.ToUpper(Console.ReadKey().KeyChar);
                        if(coordsX < 'A' || coordsX > 'Z')
                        {
                            break;
                        }
                        Console.WriteLine("\nEnter Y coordinates:");
                        char coordsY = Console.ReadKey().KeyChar;
                        if (coordsY < '1' || coordsY > '9')
                        {
                            break;
                        }
                        var interpreterContext2 = new InterpreterContext { Parameter1 = coordsX, Parameter2 = coordsY };
                        new ShootExpression().Interpret(interpreterContext2, context, this);
                        break;
                    default:
                        break;
                }
            }
        }

        public void ConsoleShoot(object state)
        {
            pictureBox2_Click(new object(), state as MouseEventArgs);
        }

        private async Task GetPlayerCount(HubConnection conn, Player player)
        {
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetPlayerCount", player))
            {
                label8.Text = "Connected players: " + model.PlayerCount.ToString();
                if (stop)
                {
                    break;
                }
            }
        }

        private async Task GetBattleDuration(HubConnection conn)
        {
            stop = false;
            display = true;
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetBattleDuration"))
            {
                if (display)
                {
                    label8.Text = "Battle duration: " + model.BattleDuration.ToLongTimeString();
                }
                if (stop)
                {
                    break;
                }
            }
        }

        private async Task GetTotalShots(HubConnection conn, bool playerShot)
        {
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetMovesCount", playerShot))
            {
                if (displayShots)
                {
                    label8.Text = "Total shots: " + model.MovesCount.ToString();
                }
                break;
            }
        }

        private async Task GetPlayerNames(HubConnection conn)
        {
            await foreach (var model in conn.StreamAsync<GameStatusModel>("GetPlayerNames"))
            {
                label8.Text = "Player names:\r\n"; 
                foreach (var name in model.PlayerNames)
                {
                    label8.Text += name + "\r\n";
                }
                if (stop)
                {
                    break;
                }
            }
        }

        private async Task SendCarsToApi(List<Car> cars)
        {
            string json = JsonConvert.SerializeObject(cars);
            await _conn.SendAsync("SavePlayerCars", _player, json);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button201_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("test");
        }


        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            var coordX = mouseEventArgs.X;
            var coordY = mouseEventArgs.Y;
            var cellPressed = "";

            //Debug.WriteLine(string.Format("X: {0} Y: {1}", coordX, coordY));

            switch (coordX)
            {
                case < 50:
                    cellPressed += "A";
                    coordX = 0;
                    break;
                case < 100:
                    cellPressed += "B";
                    coordX = 50;
                    break;
                case < 150:
                    cellPressed += "C";
                    coordX = 100;
                    break;
                case < 200:
                    cellPressed += "D";
                    coordX = 150;
                    break;
                case < 250:
                    cellPressed += "E";
                    coordX = 200;
                    break;
                case < 300:
                    cellPressed += "F";
                    coordX = 250;
                    break;
                case < 350:
                    cellPressed += "G";
                    coordX = 300;
                    break;
                case < 400:
                    cellPressed += "H";
                    coordX = 350;
                    break;
                case < 450:
                    cellPressed += "I";
                    coordX = 400;
                    break;
                case < 501:
                    cellPressed += "J";
                    coordX = 450;
                    break;
                default:
                    cellPressed += "A";
                    coordX = 0;
                    break;
            }

            switch (coordY)
            {
                case < 50:
                    cellPressed += "1";
                    coordY = 0;
                    break;
                case < 100:
                    cellPressed += "2";
                    coordY = 50;
                    break;
                case < 150:
                    cellPressed += "3";
                    coordY = 100;
                    break;
                case < 200:
                    cellPressed += "4";
                    coordY = 150;
                    break;
                case < 250:
                    cellPressed += "5";
                    coordY = 200;
                    break;
                case < 300:
                    cellPressed += "6";
                    coordY = 250;
                    break;
                case < 350:
                    cellPressed += "7";
                    coordY = 300;
                    break;
                case < 400:
                    cellPressed += "8";
                    coordY = 350;
                    break;
                case < 450:
                    cellPressed += "9";
                    coordY = 400;
                    break;
                case < 501:
                    cellPressed += "10";
                    coordY = 450;
                    break;
                default:
                    cellPressed += "1";
                    coordY = 0;
                    break;
            }
            if (selectedCar != null)
            {
                //_cars.Push(selectedCar);
                (_, _, string image) = selectedCar.GetInfo();
                Image background;
                using (var bmpTemp = new Bitmap(pictureBox1.Image))
                {
                    background = new Bitmap(bmpTemp);
                }
                //previousImages.Push(pictureBox1.Image);
                string carpath = Directory.GetCurrentDirectory() + "\\Resources\\" + image;
                Image car;
                using (var bmpTemp = new Bitmap(carpath))
                {
                    car = new Bitmap(bmpTemp);
                }
                if (rotate)
                    car.RotateFlip(RotateFlipType.Rotate90FlipX);
                getCarCoordinates(coordX, coordY);
                var successful = _playerGrid.AddCar(selectedCar);
                if (successful)
                {
                    invoker.AddCar(selectedCar, pictureBox1.Image);
                    Graphics carImage = Graphics.FromImage(background);
                    carImage.DrawImage(car, coordX, coordY);
                    pictureBox1.Image = background;
                    selectedCar = null;
                    label5.Text = "";
                    CheckButtonVisibility();
                }
            }
            else if (carsSent)
            {
                var state = await CheckCarState(coordX, coordY);
                if(state != string.Empty)
                {
                    label3.Text = "Car state is: " + state;
                }
                else
                {
                    label3.Text = state;
                }
            }
            
            //label3.Text = "Your grid cell pressed: " + cellPressed;
            //Debug.WriteLine("Your grid cell pressed: " + cellPressed);
        }
        private void CheckButtonVisibility()
        {
            var carList = invoker.CarStack().ToList();
            var smallCount = carList.Where(car => car.Health == 1).Count();
            var mediumCount = carList.Where(car => car.Health == 2).Count();
            var bigCount = carList.Where(car => car.Health == 3).Count();
            if(smallCount == 3 && mediumCount == 2 && bigCount == 1)
                button8.Visible = true;
            else
                button8.Visible = false;

            _ = (smallCount == 3) ? button1.Visible = false : button1.Visible = true;
            _ = (mediumCount == 2) ? button2.Visible = false : button2.Visible = true;
            _ = (bigCount == 1) ? button3.Visible = false : button3.Visible = true;
        }


        private async Task<string> CheckCarState(int coordX, int coordY)
        {
            var currState = "";
            await foreach (var state in _battleHub.StreamAsync<string>("CheckCarState", coordX, coordY, _player.Username))
            {
                currState = state;
                break;
            }
            return currState;
        }

        private void getCarCoordinates(int coordX, int coordY)
        {
            for (int i = 0; i < selectedCar.Length; i++)
            {
                if (rotate)
                {
                    selectedCar.Coordinates[i] = new CarPart(coordX + (50 * i), coordY);
                }
                else
                {
                    selectedCar.Coordinates[i] = new CarPart(coordX, coordY + (50 * i));
                }
            }
        }

        private async Task<string> CheckForEndGame()
        {
            var endMessage = "";
            await foreach (string message in _battleHub.StreamAsync<string>("CheckIfAllCarsDestroyed", _player.Username))
            {
                endMessage = message;
                break;
            }
            return endMessage;
        }

        private void EndGame()
        {
            var thread = new Thread(async () =>
            {
                while (true)
                {
                    var message = await CheckForEndGame();
                    if (message != "")
                    {
                        this.Invoke(new MethodInvoker(this.Hide));
                        var form = new Form4(message);
                        this.Invoke((MethodInvoker)delegate () {
                            form.Show();
                        });
                        break;
                    }
                }
            });
            thread.Start();
        }

        private void CheckTurn()
        {
            var thread = new Thread(async () =>
            {
                while (true)
                {
                    var turn = await CheckWhichTurn();
                    if(turn != "")
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            this.label12.Text = turn;
                        });
                        turnMessage = turn;
                        turnMade = false;
                    }
                }
            });
            thread.Start();
        }

        private async Task<string> CheckWhichTurn()
        {
            var message = "";
            await foreach (string result in _battleHub.StreamAsync<string>("GetTurn", _player.Username, turnMade))
            {
                message = result;
                break;
            }
            return message;
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            if(turnMessage == "Your turn")
            {
                var mouseEventArgs = e as MouseEventArgs;
                var coordX = mouseEventArgs.X;
                var coordY = mouseEventArgs.Y;
                var cellPressed = "";

                //Debug.WriteLine(string.Format("X: {0} Y: {1}", coordX, coordY));

                switch (coordX)
                {
                    case < 50:
                        cellPressed += "A";
                        break;
                    case < 100:
                        cellPressed += "B";
                        break;
                    case < 150:
                        cellPressed += "C";
                        break;
                    case < 200:
                        cellPressed += "D";
                        break;
                    case < 250:
                        cellPressed += "E";
                        break;
                    case < 300:
                        cellPressed += "F";
                        break;
                    case < 350:
                        cellPressed += "G";
                        break;
                    case < 400:
                        cellPressed += "H";
                        break;
                    case < 450:
                        cellPressed += "I";
                        break;
                    case < 501:
                        cellPressed += "J";
                        break;
                    default:
                        cellPressed += "A";
                        break;
                }

                switch (coordY)
                {
                    case < 50:
                        cellPressed += "1";
                        break;
                    case < 100:
                        cellPressed += "2";
                        break;
                    case < 150:
                        cellPressed += "3";
                        break;
                    case < 200:
                        cellPressed += "4";
                        break;
                    case < 250:
                        cellPressed += "5";
                        break;
                    case < 300:
                        cellPressed += "6";
                        break;
                    case < 350:
                        cellPressed += "7";
                        break;
                    case < 400:
                        cellPressed += "8";
                        break;
                    case < 450:
                        cellPressed += "9";
                        break;
                    case < 501:
                        cellPressed += "10";
                        break;
                    default:
                        cellPressed += "1";
                        break;
                }

                label4.Text = "Enemy grid cell pressed: " + cellPressed;
                Debug.WriteLine("Enemy grid cell pressed: " + cellPressed);

                if (shootingHandler.Weapon != null &&
                   shootingHandler.Weapon.ShotsLeft > 0)
                {
                    _enemyGrid.CheckCell(cellPressed);

                    Decision decision = new();

                    ClickInput input = new(cellPressed);

                    bool shouldReset = decision.ShouldReset(input, label10.Visible).Item1;
                    bool visibilityFlag = decision.ShouldReset(input, label10.Visible).Item2;

                    if (shouldReset)
                    {
                        stopWatch.Reset();
                        label10.Visible = visibilityFlag;
                        stopWatch.Start();
                    }

                    GetTotalShots(_conn, true);
                    await foreach (string result in _battleHub.StreamAsync<string>("GetTurn", _player.Username, true))
                    {
                        turnMessage = result;
                        break;
                    }
                }
            } 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = "Time since last shot: " + stopWatch.Elapsed.ToString("mm\\:ss");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (var bmpTemp = new Bitmap(Directory.GetCurrentDirectory() + "\\Resources\\500x500.png"))
            {
                pictureBox1.Image = new Bitmap(bmpTemp);
                pictureBox2.Image = new Bitmap(bmpTemp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var carCreator = new CarCreator();
            Car car;
            if(previousCar != null && previousCar.Health == 1)
            {
                car = previousCar.MakeDeepCopy(CarSize.Small);
            }
            else
            {
                _playerGrid.CarPlacer = new SmallCarPlacer();
                car = carCreator.CreateCar(CarSize.Small);
                previousCar = car;
            }
            car.AcceptVisitor(new DebugVisitor());
            car.AcceptVisitor(new ConsoleVisitor());
            car.AcceptVisitor(new FileVisitor());
            var message = "Car selected: " + car.Health + " " + car.Length;
            LogMessage(message, true);
            selectedCar = car;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var carCreator = new CarCreator();
            Car car;
            if (previousCar != null && previousCar.Health == 2)
            {
                car = previousCar.MakeDeepCopy(CarSize.Medium);
            }
            else
            {
                _playerGrid.CarPlacer = new OtherCarPlacer();
                car = carCreator.CreateCar(CarSize.Medium);
                previousCar = car;
            }
            car.AcceptVisitor(new DebugVisitor());
            car.AcceptVisitor(new ConsoleVisitor());
            car.AcceptVisitor(new FileVisitor());
            var message = "Car selected: " + car.Health + " " + car.Length;
            LogMessage(message, true);
            selectedCar = car;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var carCreator = new CarCreator();
            Car car;
            if (previousCar != null && previousCar.Health == 3)
            {
                car = previousCar.MakeDeepCopy(CarSize.Big);
            }
            else
            {
                _playerGrid.CarPlacer = new OtherCarPlacer();
                car = carCreator.CreateCar(CarSize.Big);
                previousCar = car;
            }
            car.AcceptVisitor(new DebugVisitor());
            car.AcceptVisitor(new ConsoleVisitor());
            car.AcceptVisitor(new FileVisitor());
            var message = "Car selected: " + car.Health + " " + car.Length;
            LogMessage(message, false);
            selectedCar = car;
        }

        //cnn
        private void button4_Click(object sender, EventArgs e)
        {
            if (cannon == null)
            {
                initializeCannon();
            }
            shootingHandler.Weapon = cannon;
            updateShotCount();
            //label9.Text = "Cannon selected:\r\nShots left - " + shootingHandler.Weapon.ShotsLeft;
        }

        //mg
        private void button5_Click(object sender, EventArgs e)
        {
            if(machinegun == null)
            {
                initializeMachinegun();
            }

            shootingHandler.Weapon = machinegun;
            updateShotCount();
            //label9.Text = "MG selected:\r\nShots left - " + shootingHandler.Weapon.ShotsLeft;
        }

        private void updateShotCount()
        {
            if(shootingHandler.Weapon is MachineGun)
            {
                label9.Text = "MG selected:\r\nShots left - " + (shootingHandler.Weapon.ShotsLeft < 0 ? 0 : shootingHandler.Weapon.ShotsLeft);
            }
            else if(shootingHandler.Weapon is Cannon)
            {
                label9.Text = "Cannon selected:\r\nShots left - " + (shootingHandler.Weapon.ShotsLeft < 0 ? 0 : shootingHandler.Weapon.ShotsLeft);
            }
        }

        private void initializeMachinegun()
        {
            var random = new Random();
            var option = random.Next(1, 4);
            switch (option)
            {
                case 1:
                    _weaponFactory = new LowAmmoFactory();
                    machinegun = _weaponFactory.CreateMachineGun();
                    label9.Text = "MG selected:\r\nShots left - " + machinegun.ShotsLeft;
                    break;
                case 2:
                    _weaponFactory = new MediumAmmoFactory();
                    machinegun = _weaponFactory.CreateMachineGun();
                    label9.Text = "MG selected:\r\nShots left - " + machinegun.ShotsLeft;
                    break;
                case 3:
                    _weaponFactory = new HighAmmoFactory();
                    machinegun = _weaponFactory.CreateMachineGun();
                    label9.Text = "MG selected:\r\nShots left - " + machinegun.ShotsLeft;
                    break;
            }
        }


        private void initializeCannon()
        {
            var random = new Random();
            var option = random.Next(1, 4);
            switch (option)
            {
                case 1:
                    _weaponFactory = new LowAmmoFactory();
                    cannon = _weaponFactory.CreateCannon();
                    label9.Text = "Cannon selected:\r\nShots left - " + cannon.ShotsLeft;
                    break;
                case 2:
                    _weaponFactory = new MediumAmmoFactory();
                    cannon = _weaponFactory.CreateCannon();
                    label9.Text = "Cannon selected:\r\nShots left - " + cannon.ShotsLeft;
                    break;
                case 3:
                    _weaponFactory = new HighAmmoFactory();
                    cannon = _weaponFactory.CreateCannon();
                    label9.Text = "Cannon selected:\r\nShots left - " + cannon.ShotsLeft;
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Image previous = invoker.Undo();
            if(_playerGrid.Cars.Count != 0)
            {
                _playerGrid.Cars.RemoveAt(_playerGrid.Cars.Count - 1);
            }
            if (previous != null)
            {
                pictureBox1.Image = previous;
            }
            CheckButtonVisibility();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (rotate == false)
                rotate = true;
            else
                rotate = false;
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            //var cars = _cars.ToList();
            var cars = invoker.CarStack().ToList();
            await SendCarsToApi(cars);
            carsSent = true;
            EndGame();
            var conf = await ConfirmUser();
            if (conf)
            {
                CheckTurn();
            }
            // send cars to backend
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

        public async Task AddShot(string coords, int coordX, int coordY)
        {
            var shotInfo = await shootingHandler.HandleShot(_topLeftHandler, coordX, coordY, _player.Username); 
            updateShotCount();
            DisplayBonus(shotInfo.Item2);

            Debug.WriteLine("New shot made: " + coords);
            Image background;
            using (var bmpTemp = new Bitmap(pictureBox2.Image))
            {
                background = new Bitmap(bmpTemp);
            }
            string imgPath = Directory.GetCurrentDirectory() + $"\\Resources\\{shotInfo.Item1}.png";
            Image hitmark;
            using (var bmpTemp = new Bitmap(imgPath))
            {
                hitmark = new Bitmap(bmpTemp);
            }
            Graphics carImage = Graphics.FromImage(background);
            carImage.DrawImage(hitmark, coordX, coordY);
            pictureBox2.Image = background;


        }

        private void DisplayBonus(int bonus)
        {
            switch (bonus)
            {
                case 0:
                    label11.Text = "No bonus applied! Maybe next shot?";
                    label11.ForeColor = Color.Black;
                    break;
                case < 0:
                    label11.Text = "Unlucky shot! Better luck next time!";
                    label11.ForeColor = Color.Red;
                    break;
                case > 0:
                    label11.Text = "Lucky shot! Nice!";
                    label11.ForeColor = Color.Green;
                    break;
                default:
                    label11.Text = "";
                    label11.ForeColor = Color.Transparent;
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            display = false;
            displayShots = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    stop = true;
                    GetPlayerCount(_conn, _player);
                    break;
                case 1:
                    stop = true;
                    GetBattleDuration(_conn);
                    break;
                case 2:
                    stop = true;
                    GetPlayerNames(_conn);
                    break;
                case 3:
                    stop = true;
                    displayShots = true;
                    GetTotalShots(_conn, false);
                    break;
            }
        }

        public void LogMessage(string message, bool inline)
        {
            if(inline)
                label5.Text = message;
            else
            {
                label5.Text = message.Substring(0, message.Length / 2) + "\n" + message.Substring(message.Length / 2, message.Length / 2);
            }
        }

        // TODO: išsaugot ne tik invokeri bet ir kordinates, kad jas atstatyt butu galima, dabar broken atm

        private void button9_Click(object sender, EventArgs e)
        {
            originator.Invoker = (Invoker) invoker.Clone();
            originator.Image = new Bitmap(pictureBox1.Image);
            originator.CarGrid = (Grid)_playerGrid.Clone();

            caretaker.Memento = originator.SaveMemento();
            button10.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            originator.RestoreMemento(caretaker.Memento);
            invoker = originator.Invoker;
            pictureBox1.Image = originator.Image;
            _playerGrid = originator.CarGrid;
            button10.Visible = false;
            CheckButtonVisibility();
        }
    }
}
