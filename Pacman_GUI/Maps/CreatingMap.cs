using System.ComponentModel;

namespace Course
{
    public partial class CreatingMap : Form
    {
        private int sizeOfSides;
        private MapCreator creator;
        private Label helpInfo;
        private Label width;
        private Label height;
        private PictureBox selectedCell;
        private PictureBox pointer;
        private PictureBox[] tools;

        public CreatingMap()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            UpdateStyles();
            InitializeComponent();
            sizeOfSides = PlayPacmanForm.sizeOfSides;

            SetPointer();
            SetSelectedCell();
        }

        private void SetPointer()
        {
            pointer = new PictureBox();
            pointer.Size = new Size(20, 20);
            pointer.SizeMode = PictureBoxSizeMode.Zoom;
            pointer.Image = Images.Pointer;
            pointer.Visible = false;
            Controls.Add(pointer);
        }

        private void SetSelectedCell()
        {
            selectedCell = new PictureBox();
            selectedCell.Size = new Size(sizeOfSides, sizeOfSides);
            selectedCell.SizeMode = PictureBoxSizeMode.Zoom;
            selectedCell.Image = Images.SelectedCell;
            selectedCell.BackColor = Color.Transparent;
            selectedCell.Visible = false;
            Controls.Add(selectedCell);
        }

        private void inputMapName_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidMapName(inputMapName.Text, out errorMsg))
            {
                e.Cancel = true;
                inputMapName.Select(0, inputMapName.Text.Length);

                errorProvider.SetError(sender as TextBox, errorMsg);
            }
        }

        private bool ValidMapName(string name, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "Enter the map name!";
                return false;
            }
            return true;
        }

        private void inputSize_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage;
            TextBox textBox = (TextBox)sender;
            if (!ValidSize(textBox.Text, out errorMessage))
            {
                e.Cancel = true;
                inputWidth.Select(0, inputWidth.Text.Length);

                errorProvider.SetError(sender as TextBox, errorMessage);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private bool ValidSize(string size, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (int.TryParse(size, out int result))
            {
                if (result < 1 || result > 100)
                {
                    errorMessage = "Size must be bigger then 1 and smaller then 100!";
                    return false;
                }
                return true;
            }
            else
            {
                if (string.IsNullOrEmpty(size))
                {
                    errorMessage = "Enter the size!";
                }
                else if (size.Contains(',') || size.Contains('.'))
                {
                    errorMessage = "Size must be integer value!";
                }
                else
                {
                    errorMessage = "Size cannot contain letters!";
                }
                return false;
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            string path = inputMapName.Text;
            int width = Convert.ToInt32(inputWidth.Text);
            int height = Convert.ToInt32(inputHeight.Text);
            bool random = isRandom.Checked;

            creator = new MapCreator(path, width, height, random);
            tools = new PictureBox[creator.Elements.Count];
            for (int i = 0; i < creator.Elements.Count; i++)
            {
                tools[i] = new PictureBox();
                tools[i].Size = new Size(sizeOfSides, sizeOfSides);
                tools[i].SizeMode = PictureBoxSizeMode.Zoom;
                tools[i].Image = PlayPacmanForm.Textures[creator.Elements.ElementAt(i).Value.Symbol];
                Controls.Add(tools[i]);
            }

            mapInfo.Visible = false;
            selectedCell.Visible = true;
            SetHelpInfo();
            SetSizes();

            pointer.Location = new Point(0, this.height.Bottom + sizeOfSides);
            pointer.Visible = true;
            Paint += CreatingMap_Paint;
            DrawTools();
            Refresh();
            if (random)
            {
                timer.Enabled = true;
                Task.Run(() =>
                {
                    creator.CreateRandomMap();
                    KeyDown += CreatingMap_KeyDown;
                }); 
            }
            else
            {
                KeyDown += CreatingMap_KeyDown;
            }
        }

        private void SetHelpInfo()
        {
            helpInfo = new Label();
            helpInfo.Text = "H -- help info";
            helpInfo.AutoSize = true;
            helpInfo.Location = new Point(0, creator.Height * sizeOfSides + 1);
            Controls.Add(helpInfo);
        }

        private void SetSizes()
        {
            width = new Label();
            width.Text = $"Width {creator.Width}";
            width.AutoSize = true;
            width.Location = new Point(0, helpInfo.Bottom);
            Controls.Add(width);

            height = new Label();
            height.Text = $"Height {creator.Height}";
            height.AutoSize = true;
            height.Location = new Point(0, width.Bottom);
            Controls.Add(height);
        }

        private void CreatingMap_KeyDown(object sender, KeyEventArgs e)
        {
            creator.PressKey((ConsoleKey)e.KeyData);
            switch (e.KeyData)
            {
                case Keys.E:
                    Refresh();
                    break;
                case Keys.H:
                    MessageBox.Show("Create a map!" + "\n  E -- put the element" + "\n  spacebar -- space" + "\n  V -- pacman (only one)" + "\n  1 -- wall" + "\n  2 -- coin " + "\n  3 -- ghost" + "\n  4 -- energizer" + "\n  5 -- web" + "\n  6 -- freeze" + "\n  7 -- picklock" + "\n  8 -- door" + "\n  Enter -- cancel editing");
                    break;
                case Keys.M:
                    changesizes.Location = new Point(Width / 2, Height / 2);
                    changesizes.Visible = true;
                    changesizes.Enabled = true;
                    break;
                case Keys.Y:
                    timer.Enabled = true;
                    Task.Run(creator.CreateRandomMap);
                    break;
            }

            if (creator.Elements.ContainsKey((ConsoleKey)e.KeyData))
            {
                ChangeSelectedElement(creator.Elements[(ConsoleKey)e.KeyData]);
            }
            else if (e.KeyData == Keys.Escape || e.KeyData == Keys.Enter)
            {
                creator.CheckMap();
                if (!creator.IsPass)
                {

                    if (MessageBox.Show("Your Level is cannot be completed. Continue?", "Saving map", buttons: MessageBoxButtons.YesNo)
                        == DialogResult.No)
                    {
                        Refresh();
                        DrawTools();
                        return;
                    }

                }
                if (MessageBox.Show("Save map?", "Saving map", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    creator.SaveMap();
                }
                Dispose();
            }
            else
            {
                selectedCell.Location = new Point(creator.X * sizeOfSides, creator.Y * sizeOfSides);
            }
        }

        private void DrawTools()
        {
            for (int i = 0; i < creator.Elements.Count; i++)
            {
                tools[i].Location = new Point(i * sizeOfSides, height.Bottom);
            }
        }

        private void ChangeSelectedElement(Element newElement)
        {
            pointer.Location = new Point(creator.Elements.Values.ToList().IndexOf(newElement) * sizeOfSides, height.Bottom + sizeOfSides);
        }

        private void changeSizeBtn_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(inputChangeWidth.Text);
            int height = Convert.ToInt32(inputChangeHeight.Text);
            creator.ChangeSize(width, height);

            this.width.Text = $"Width {creator.Width}";
            this.width.Location = new Point(0, creator.Height * sizeOfSides);
            this.height.Text = $"Height {creator.Height}";
            this.height.Location = new Point(0, this.width.Bottom);

            changesizes.Visible = false;
            changesizes.Enabled = false;
            Refresh();
            DrawTools();
        }

        private void CreatingMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int y = 0; y < creator.Height; y++)
            {
                for (int x = 0; x < creator.Width; x++)
                {
                    g.DrawImage(PlayPacmanForm.Textures[creator.Map[x, y].Symbol], new Rectangle(x * sizeOfSides, y * sizeOfSides, sizeOfSides, sizeOfSides));
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!creator.CreatingInProcess)
            {
                timer.Stop();
                Refresh();
            }
            selectedCell.Location = new Point(creator.X * sizeOfSides, creator.Y * sizeOfSides);
        }
    }
}
