using System.ComponentModel;

namespace Course
{

    public partial class PlayPacmanForm : Form
    {
        public static Bitmap PacmanTexture = Images.Pacman,
            EnemyTexture = Images.Enemy,
            AfraidEnemyTexture = Images.AfraidEnemy,
            CoinTexture = Images.Coin,
            WallTexture = Images.Wall,
            SpaceTexture = Images.Space,
            DoorTexture = Images.Door,
            DollarTexture = Images.Dollar,
            EnergizerTexture = Images.Energizer,
            FreezeTexture = Images.Freeze,
            PicklockTexture = Images.Picklock,
            WebTexture = Images.Web,
            HealthTexture = Images.Health,
            BagTexture = Images.Bag,
            WinScreen = Images.Win,
            LoseScreen = Images.Lose,
            SettingsLogoImage = Images.SettingsLogo,
            ShopLogoImage = Images.ShopLogo,
            ControlsLogoImage = Images.ContolsLogo,
            BackgroundTexture = Images.Background;
        static public int sizeOfSides = 15;
        static public Dictionary<Symbols, Bitmap> Textures;
        private Graphics graphics;
        private Map map;
        private PictureBox pacman;
        private PictureBox[] enemies;
        private Panel Win;
        private Panel Lose;
        private Engine engine;
        private Shop shop = new Shop();
        private Panel settings = new Panel();
        private Panel controlsPanel = new Panel();
        private Panel shopPanel = new Panel();
        private ComboBox musicIsOn = new ComboBox();
        private ComboBox difficulty = new ComboBox();
        private TextBox input = new TextBox();
        private Button escape = new Button();
        private Label settingsText = new Label();
        private Label healthCost = new Label();
        private Label bagSizeCost = new Label();
        private Label pause = new Label();
        private Label score = new Label();
        private Label healthPoints = new Label();
        private Label inventory = new Label();
        private Label controlsInfo = new Label();
        private (int x, int y) bonusPosition;

        public PlayPacmanForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.UserPaint, true);
            UpdateStyles();
            graphics = CreateGraphics();
            Textures = new Dictionary<Symbols, Bitmap>
            {
                {Symbols.Pacman, PacmanTexture },
                {Symbols.Wall, WallTexture },
                {Symbols.Ghost, EnemyTexture },
                {Symbols.AfraidGhost, AfraidEnemyTexture },
                {Symbols.Coin, CoinTexture },
                {Symbols.Space, SpaceTexture },
                {Symbols.Door, DoorTexture },
                {Symbols.Dollar, DollarTexture},
                {Symbols.Energizer, EnergizerTexture },
                {Symbols.Freeze, FreezeTexture},
                {Symbols.Web, WebTexture },
                {Symbols.Picklock, PicklockTexture}
            };
            new Pacman();
        }

        private void PlayPacmanForm_Load(object sender, EventArgs e)
        {
            MainMenu.Controls.Add(mapList);
            mapList.BringToFront();
            CountOfMoney.Text = Pacman.Money.ToString();

            CreatePacman();
            CreateEndGamePanels();
            CreateSettingsPanel();
            CreateEscapeButton();
            CreateShopPanel();
            CreateControlsPanel();
            SetGameInfo();

            map = new Map(MapNameLabel.Text);

        }

        private void CreatePacman()
        {
            pacman = new PictureBox();
            pacman.SizeMode = PictureBoxSizeMode.Zoom;
            pacman.Size = new Size(sizeOfSides, sizeOfSides);
            pacman.Image = PacmanTexture;
            pacman.Visible = false;
            Controls.Add(pacman);
        }

        private void CreateEndGamePanels()
        {
            Win = new Panel();
            Win.Dock = DockStyle.Fill;
            Win.BackgroundImage = WinScreen;
            Win.BackgroundImageLayout = ImageLayout.Zoom;
            Win.Visible = false;
            Win.Enabled = false;
            Win.Click += HidePanel;
            Controls.Add(Win);

            Lose = new Panel();
            Lose.Dock = DockStyle.Fill;
            Lose.BackgroundImage = LoseScreen;
            Lose.BackgroundImageLayout = ImageLayout.Zoom;
            Lose.Visible = false;
            Lose.Enabled = false;
            Lose.Click += HidePanel;
            Controls.Add(Lose);
        }

        private void SetGameInfo()
        {
            pause.Visible = false;
            pause.ForeColor = Color.White;
            Controls.Add(pause);

            score.ForeColor = Color.White;
            score.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Controls.Add(score);

            healthPoints.ForeColor = Color.White;
            healthPoints.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Controls.Add(healthPoints);

            inventory.ForeColor = Color.White;
            inventory.Text = "Inventory";
            inventory.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Controls.Add(inventory);
        }

        private void CreateSettingsPanel()
        {
            settings.Dock = DockStyle.Fill;
            settings.Visible = false;
            settings.BackgroundImage = BackgroundTexture;
            settings.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(settings);

            PictureBox settingsLogo = new PictureBox();
            settingsLogo.Image = SettingsLogoImage;
            settingsLogo.Location = new Point(0, 0);
            settingsLogo.Size = new Size(600, 100);
            settingsLogo.SizeMode = PictureBoxSizeMode.Zoom;
            settings.Controls.Add(settingsLogo);

            settingsText.Text = $"Music\n\nGame speed\n\nDifficulty";
            settingsText.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            settingsText.BackColor = Color.Transparent;
            settingsText.Location = new Point(100, 100);
            settingsText.AutoSize = true;
            settings.Controls.Add(settingsText);

            musicIsOn.Items.Add("On");
            musicIsOn.Items.Add("Off");
            if (Settings.MusicIsOn)
            {
                musicIsOn.Text = "On";
            }
            else
            {
                musicIsOn.Text = "Off";
            }
            musicIsOn.Location = new Point(settingsText.Right + 2, 100);
            musicIsOn.SelectedIndexChanged += SetMusic;
            settings.Controls.Add(musicIsOn);

            input.Text = Settings.GameSpeed.ToString();
            input.Location = new Point(settingsText.Right + 2, musicIsOn.Location.Y + 30);
            input.Validating += SetGameSpeed;
            settings.Controls.Add(input);

            difficulty.Items.Add("easy");
            difficulty.Items.Add("medium");
            difficulty.Items.Add("hard");
            switch (Settings.Difficulty)
            {
                case 1:
                    difficulty.Text = "easy";
                    break;
                case 2:
                    difficulty.Text = "medium";
                    break;
                case 3:
                    difficulty.Text = "hard";
                    break;
            }
            difficulty.Location = new Point(settingsText.Right + 2, input.Location.Y + 30);
            difficulty.SelectedIndexChanged += SetDifficulty;
            settings.Controls.Add(difficulty);
        }

        private void CreateEscapeButton()
        {
            escape.Text = "back";
            escape.Dock = DockStyle.Bottom;
            escape.Click += ReturnToMenu;
        }

        private void CreateShopPanel()
        {
            shopPanel = new Panel();
            shopPanel.Dock = DockStyle.Fill;
            shopPanel.BackgroundImage = BackgroundTexture;
            shopPanel.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(shopPanel);

            PictureBox shopLogo = new PictureBox();
            shopLogo.Image = ShopLogoImage;
            shopLogo.Location = new Point(0, 0);
            shopLogo.Size = new Size(600, 100);
            shopLogo.SizeMode = PictureBoxSizeMode.Zoom;
            shopPanel.Controls.Add(shopLogo);
            shopPanel.Visible = false;

            PictureBox health = new PictureBox();
            health.Location = new Point(100, 100);
            health.Size = new Size(100, 100);
            health.Image = HealthTexture;
            health.Click += BuyHealth;
            shopPanel.Controls.Add(health);

            healthCost.Text = $"{new Health().Price}$";
            healthCost.Location = new Point(health.Left, health.Bottom);
            shopPanel.Controls.Add(healthCost);

            PictureBox bag = new PictureBox();
            bag.Location = new Point(250, 100);
            bag.Size = new Size(100, 100);
            bag.Image = BagTexture;
            bag.Click += BuyBag;
            shopPanel.Controls.Add(bag);

            bagSizeCost.Text = $"{new BagSize().Price}$";
            bagSizeCost.Location = new Point(bag.Left, bag.Bottom);
            shopPanel.Controls.Add(bagSizeCost);
        }

        private void CreateControlsPanel()
        {
            controlsPanel.Dock = DockStyle.Fill;
            controlsPanel.BackgroundImage = BackgroundTexture;
            Controls.Add(controlsPanel);

            PictureBox controlsLogo = new PictureBox();
            controlsLogo.Image = ControlsLogoImage;
            controlsLogo.Location = new Point(0, 0);
            controlsLogo.Size = new Size(600, 100);
            controlsLogo.SizeMode = PictureBoxSizeMode.Zoom;
            controlsPanel.Controls.Add(controlsLogo);

            string info = File.ReadAllText("Settings/Controls.txt");
            controlsInfo.Text = info;
            controlsInfo.Font = new Font("MV Boli", 15F, FontStyle.Regular, GraphicsUnit.Point); ;
            controlsInfo.AutoSize = true;
            controlsPanel.Controls.Add(controlsInfo);
            controlsPanel.Visible = false;
            controlsPanel.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void Play()
        {
            MainMenu.Visible = false;
            MainMenu.Enabled = false;

            map = new Map(MapNameLabel.Text);

            engine = new Engine(map);
            BackColor = Color.Black;
            engine.Start();
            KeyDown += PlayPacmanForm_KeyDown;

            pacman.Visible = true;
            enemies = new PictureBox[engine.Enemies.Length];
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].Size = new Size(sizeOfSides, sizeOfSides);
                enemies[i].Image = EnemyTexture;
                Controls.Add(enemies[i]);
            }

            timerForReplace.Enabled = true;
            score.Location = new Point(map.Width * sizeOfSides, 10);
            healthPoints.Text = "Health";
            healthPoints.Location = new Point(0, map.Height * sizeOfSides);


            MoneyLabel.Location = new Point(0, healthPoints.Bottom);
            MoneyLabel.ForeColor = Color.White;
            Controls.Add(MoneyLabel);
            CountOfMoney.Location = new Point(MoneyLabel.Right, healthPoints.Bottom);
            CountOfMoney.ForeColor = Color.White;
            Controls.Add(CountOfMoney);
        }

        private void Replace(object sender, EventArgs e)
        {
            score.Text = $"Score {Pacman.Score}";
            CountOfMoney.Text = Pacman.Money.ToString();

            if (engine.BonusPosition != bonusPosition)
            {
                ReDrawCell(bonusPosition.x, bonusPosition.y);
                bonusPosition = engine.BonusPosition;
            }

            pacman.Location = new Point(engine.Pacman.X * sizeOfSides, engine.Pacman.Y * sizeOfSides);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Image = Textures[engine.Enemies[i].Symbol];
                enemies[i].Location = new Point(engine.Enemies[i].X * sizeOfSides, engine.Enemies[i].Y * sizeOfSides);
            }
            if (!engine.IsPlaying)
            {
                if (engine.GameResult == GameResult.Win)
                {
                    DrawWin();
                }
                else if (engine.GameResult == GameResult.Lose)
                {
                    DrawLose();
                }
                Save("money", Pacman.Money);
            }
        }

        private void EndGame()
        {
            timerForReplace.Enabled = false;
            pacman.Visible = false;
            foreach (var enemy in enemies)
            {
                enemy.Visible = false;
            }
            MainMenu.Visible = true;
            MainMenu.Enabled = true;
            BackColor = Color.White;
            KeyDown -= PlayPacmanForm_KeyDown;
            MoneyLabel.Location = new Point(44, 403);
            MoneyLabel.ForeColor = Color.Black;
            MainMenu.Controls.Add(MoneyLabel);
            CountOfMoney.Location = new Point(102, 403);
            CountOfMoney.ForeColor = Color.Black;
            MainMenu.Controls.Add(CountOfMoney);
        }

        private void DrawMap(Map map, Graphics graphics)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    graphics.DrawImage(Textures[map.Level[x, y].Symbol], new Rectangle(x * sizeOfSides, y * sizeOfSides, sizeOfSides, sizeOfSides));
                }
            }
        }

        private void PlayPacmanForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawMap(map, g);
            DrawHealth(engine.Pacman.HealthPoints);
            DrawInventoryItems(engine.Pacman.Inventory.Contents);
        }

        private void PlayPacmanForm_KeyDown(object sender, KeyEventArgs e)
        {
            engine.PressKey((ConsoleKey)e.KeyData);

            if (engine.IsPause)
            {
                pause.Text = "PAUSE";
                pause.Location = new Point(Width / 2, Height / 2);
                pause.Visible = true;
            }
            else if (!engine.IsPause)
            {
                pause.Visible = false;
            }
            if (e.KeyCode == Keys.M)
            {
                EndGame();
            }
        }

        private void ReDrawCell(int x, int y)
        {
            graphics.DrawImage(Textures[map.Level[x, y].Symbol], x * sizeOfSides, y * sizeOfSides, sizeOfSides, sizeOfSides);
        }

        private void DrawHealth(int count)
        {
            for (int i = 0; i < count; i++)
            {
                graphics.DrawImage(PacmanTexture, healthPoints.Right + i * sizeOfSides, map.Height * sizeOfSides, sizeOfSides, sizeOfSides);
            }
        }

        private void DrawInventoryItems(List<Item> items)
        {
            inventory.Location = new Point(0, CountOfMoney.Bottom);
            graphics.DrawImage(SpaceTexture, new Rectangle(0, inventory.Bottom, sizeOfSides * 2, Width));
            for (int i = 0; i < items.Count; i++)
            {
                graphics.DrawImage(Textures[items[i].Symbol], i * sizeOfSides, inventory.Bottom, sizeOfSides * 2, sizeOfSides * 2);
            }
        }

        private void DrawWin()
        {
            Win.Visible = true;
            Win.Enabled = true;
        }

        private void DrawLose()
        {
            Lose.Visible = true;
            Lose.Enabled = true;
        }

        private void ChangemapButton_Click(object sender, EventArgs e)
        {
            string[] maps = File.ReadAllLines("Settings/Maps.txt");
            foreach (string map in maps)
            {
                mapList.Items.Add(map);
            }
            mapList.Height = maps.Length * 16;
            mapList.Enabled = true;
            mapList.Visible = true;
        }

        private string ChangeMap(int pressedKey)
        {
            string[] maps = File.ReadAllLines("Settings/Maps.txt");
            return maps[pressedKey];
        }

        private void Save(string changevalue, int value)
        {
            string[] Stats = File.ReadAllLines("Settings/Accountstats.txt");
            string stat = null;

            for (int i = 0; i < Stats.Length; i++)
            {
                if (Stats[i].Split(' ')[0].ToLower() == changevalue.ToLower())
                {
                    stat += Stats[i].Split(' ')[0] + $" {value}\n";
                }
                else
                {
                    stat += $"{Stats[i].Split(' ')[0]} {Stats[i].Split(' ')[1]}\n";
                }
            }
            File.WriteAllText("Settings/Accountstats.txt", stat);
        }

        private void MapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MapNameLabel.Text = ChangeMap(mapList.SelectedIndex);
            mapList.Items.Clear();
            mapList.Visible = false;
        }

        private void CreatemapButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Application.Run(new CreatingMap());
            });
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            shopPanel.Controls.Add(escape);
            MainMenu.Visible = false;
            MainMenu.Enabled = false;
            shopPanel.Visible = true;
            shopPanel.Enabled = true;
        }

        private void BuyBag(object sender, EventArgs e)
        {
            Buy(shop.ChoseProduct(ConsoleKey.D2));
        }

        private void BuyHealth(object sender, EventArgs e)
        {
            Buy(shop.ChoseProduct(ConsoleKey.D1));
        }

        private void Buy(bool CanBuy)
        {
            if (CanBuy)
            {
                MessageBox.Show("Successful!");
            }
            else
            {
                MessageBox.Show("Not enough money");
            }
        }

        private void ControlsButton_Click(object sender, EventArgs e)
        {
            controlsPanel.Controls.Add(escape);
            string info = File.ReadAllText("Settings/Controls.txt");
            controlsInfo.Text = info;
            controlsInfo.Location = new Point(Width / 2 - controlsInfo.Width / 2, Height / 2 - controlsInfo.Height / 2);
            MainMenu.Visible = false;
            MainMenu.Enabled = false;
            controlsPanel.Visible = true;
            controlsPanel.Enabled = true;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            settings.Controls.Add(escape);
            MainMenu.Visible = false;
            MainMenu.Enabled = false;
            settings.Visible = true;
            settings.Enabled = true;
        }

        private void SetDifficulty(object sender, EventArgs e)
        {
            Settings.ChangeSettings(ConsoleKey.D3, difficulty.SelectedIndex + 1);
        }

        private void SetGameSpeed(object sender, CancelEventArgs e)
        {
            var input = sender as TextBox;
            string errorMessage;
            if (!ValidSpeed(input.Text, out errorMessage))
            {
                e.Cancel = true;
                input.Select(0, input.Text.Length);

                errorProvider.SetError(input, errorMessage);
            }
            else
            {
                errorProvider.Clear();
                Settings.ChangeSettings(ConsoleKey.D2, Convert.ToDouble(input.Text));
            }
        }

        private bool ValidSpeed(string speed, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (double.TryParse(speed, out double result))
            {
                return true;
            }
            else
            {
                if (string.IsNullOrEmpty(speed))
                {
                    errorMessage = "Enter the value!";
                }
                else if (speed.Contains('.'))
                {
                    errorMessage = "Use ',' for double value";
                }
                else
                {
                    errorMessage = "Speed cannot contain letters!";
                }
                return false;
            }
        }

        private void SetMusic(object sender, EventArgs e)
        {
            Settings.ChangeSettings(ConsoleKey.D1, musicIsOn.SelectedIndex + 1);
        }

        private void HidePanel(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Visible = false;
            panel.Enabled = false;
            EndGame();
        }

        private void ReturnToMenu(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Parent.Visible = false;
            button.Parent.Enabled = false;
            MainMenu.Visible = true;
            MainMenu.Enabled = true;
        }
    }
}