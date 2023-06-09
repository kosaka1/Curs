namespace Course
{
    partial class PlayPacmanForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayPacmanForm));
            StartButton = new Button();
            SettingsButton = new Button();
            ControlsButton = new Button();
            ShopButton = new Button();
            CreatemapButton = new Button();
            ChangemapButton = new Button();
            CurrentmapLabel = new Label();
            MapNameLabel = new Label();
            MoneyLabel = new Label();
            CountOfMoney = new Label();
            mapList = new ListBox();
            MainMenu = new Panel();
            pictureBox1 = new PictureBox();
            timerForReplace = new System.Windows.Forms.Timer(components);
            errorProvider = new ErrorProvider(components);
            MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            StartButton.Location = new Point(348, 109);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(180, 27);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.BackColor = Color.Transparent;
            SettingsButton.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            SettingsButton.Location = new Point(348, 241);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(180, 27);
            SettingsButton.TabIndex = 1;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = false;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // ControlsButton
            // 
            ControlsButton.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ControlsButton.Location = new Point(348, 274);
            ControlsButton.Name = "ControlsButton";
            ControlsButton.Size = new Size(180, 27);
            ControlsButton.TabIndex = 2;
            ControlsButton.Text = "Controls";
            ControlsButton.UseVisualStyleBackColor = true;
            ControlsButton.Click += ControlsButton_Click;
            // 
            // ShopButton
            // 
            ShopButton.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ShopButton.Location = new Point(348, 208);
            ShopButton.Name = "ShopButton";
            ShopButton.Size = new Size(180, 27);
            ShopButton.TabIndex = 3;
            ShopButton.Text = "Shop";
            ShopButton.UseVisualStyleBackColor = true;
            ShopButton.Click += ShopButton_Click;
            // 
            // CreatemapButton
            // 
            CreatemapButton.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CreatemapButton.Location = new Point(348, 175);
            CreatemapButton.Name = "CreatemapButton";
            CreatemapButton.Size = new Size(180, 27);
            CreatemapButton.TabIndex = 5;
            CreatemapButton.Text = "Create your own map";
            CreatemapButton.UseVisualStyleBackColor = true;
            CreatemapButton.Click += CreatemapButton_Click;
            // 
            // ChangemapButton
            // 
            ChangemapButton.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ChangemapButton.Location = new Point(348, 142);
            ChangemapButton.Name = "ChangemapButton";
            ChangemapButton.Size = new Size(180, 27);
            ChangemapButton.TabIndex = 6;
            ChangemapButton.Text = "Change map";
            ChangemapButton.UseVisualStyleBackColor = true;
            ChangemapButton.Click += ChangemapButton_Click;
            // 
            // CurrentmapLabel
            // 
            CurrentmapLabel.AutoSize = true;
            CurrentmapLabel.BackColor = Color.Transparent;
            CurrentmapLabel.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CurrentmapLabel.Location = new Point(44, 386);
            CurrentmapLabel.Name = "CurrentmapLabel";
            CurrentmapLabel.Size = new Size(90, 17);
            CurrentmapLabel.TabIndex = 7;
            CurrentmapLabel.Text = "Current map:";
            // 
            // MapNameLabel
            // 
            MapNameLabel.AutoSize = true;
            MapNameLabel.BackColor = Color.Transparent;
            MapNameLabel.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            MapNameLabel.Location = new Point(140, 386);
            MapNameLabel.Name = "MapNameLabel";
            MapNameLabel.Size = new Size(68, 17);
            MapNameLabel.TabIndex = 8;
            MapNameLabel.Text = "googleMap";
            // 
            // MoneyLabel
            // 
            MoneyLabel.AutoSize = true;
            MoneyLabel.BackColor = Color.Transparent;
            MoneyLabel.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            MoneyLabel.Location = new Point(44, 403);
            MoneyLabel.Name = "MoneyLabel";
            MoneyLabel.Size = new Size(52, 17);
            MoneyLabel.TabIndex = 9;
            MoneyLabel.Text = "Money:";
            // 
            // CountOfMoney
            // 
            CountOfMoney.AutoSize = true;
            CountOfMoney.BackColor = Color.Transparent;
            CountOfMoney.Font = new Font("MV Boli", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CountOfMoney.Location = new Point(102, 403);
            CountOfMoney.Name = "CountOfMoney";
            CountOfMoney.Size = new Size(14, 17);
            CountOfMoney.TabIndex = 10;
            CountOfMoney.Text = "-";
            // 
            // mapList
            // 
            mapList.FormattingEnabled = true;
            mapList.ItemHeight = 15;
            mapList.Location = new Point(325, 109);
            mapList.Name = "mapList";
            mapList.Size = new Size(223, 199);
            mapList.TabIndex = 12;
            mapList.Visible = false;
            mapList.SelectedIndexChanged += MapList_SelectedIndexChanged;
            // 
            // MainMenu
            // 
            MainMenu.AutoSize = true;
            MainMenu.BackgroundImage = (Image)resources.GetObject("MainMenu.BackgroundImage");
            MainMenu.BackgroundImageLayout = ImageLayout.Stretch;
            MainMenu.Controls.Add(pictureBox1);
            MainMenu.Controls.Add(CreatemapButton);
            MainMenu.Controls.Add(ChangemapButton);
            MainMenu.Controls.Add(StartButton);
            MainMenu.Controls.Add(CountOfMoney);
            MainMenu.Controls.Add(MoneyLabel);
            MainMenu.Controls.Add(MapNameLabel);
            MainMenu.Controls.Add(CurrentmapLabel);
            MainMenu.Controls.Add(ShopButton);
            MainMenu.Controls.Add(ControlsButton);
            MainMenu.Controls.Add(SettingsButton);
            MainMenu.Dock = DockStyle.Fill;
            MainMenu.ImeMode = ImeMode.Off;
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(832, 480);
            MainMenu.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(237, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(401, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // timerForReplace
            // 
            timerForReplace.Interval = 30;
            timerForReplace.Tick += Replace;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // PlayPacmanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(832, 480);
            Controls.Add(MainMenu);
            KeyPreview = true;
            Name = "PlayPacmanForm";
            Text = "Pacman";
            Load += PlayPacmanForm_Load;
            Paint += PlayPacmanForm_Paint;
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartButton;
        private Button SettingsButton;
        private Button ControlsButton;
        private Button ShopButton;
        private Button CreatemapButton;
        private Button ChangemapButton;
        private Label CurrentmapLabel;
        private Label MapNameLabel;
        private Label MoneyLabel;
        private Label CountOfMoney;
        private ListBox mapList;
        private Panel MainMenu;
        private System.Windows.Forms.Timer timerForReplace;
        private PictureBox pictureBox1;
        private ErrorProvider errorProvider;
    }
}