namespace Cursovoi
{
    partial class CreatingMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mapInfo = new GroupBox();
            ApplyBtn = new Button();
            inputHeight = new TextBox();
            inputWidth = new TextBox();
            isRandom = new CheckBox();
            heightLbl = new Label();
            widthLbl = new Label();
            inputMapName = new TextBox();
            mapName = new Label();
            changesizes = new GroupBox();
            changeSizeBtn = new Button();
            inputChangeHeight = new TextBox();
            inputChangeWidth = new TextBox();
            changeHeight = new Label();
            changeWidth = new Label();
            timer = new System.Windows.Forms.Timer(components);
            saveFileDialog = new SaveFileDialog();
            errorProvider = new ErrorProvider(components);
            mapInfo.SuspendLayout();
            changesizes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // mapInfo
            // 
            mapInfo.Controls.Add(ApplyBtn);
            mapInfo.Controls.Add(inputHeight);
            mapInfo.Controls.Add(inputWidth);
            mapInfo.Controls.Add(isRandom);
            mapInfo.Controls.Add(heightLbl);
            mapInfo.Controls.Add(widthLbl);
            mapInfo.Controls.Add(inputMapName);
            mapInfo.Controls.Add(mapName);
            mapInfo.Location = new Point(239, 27);
            mapInfo.Name = "mapInfo";
            mapInfo.Size = new Size(286, 386);
            mapInfo.TabIndex = 0;
            mapInfo.TabStop = false;
            mapInfo.Text = "Create!";
            // 
            // ApplyBtn
            // 
            ApplyBtn.Location = new Point(55, 296);
            ApplyBtn.Name = "ApplyBtn";
            ApplyBtn.Size = new Size(167, 56);
            ApplyBtn.TabIndex = 8;
            ApplyBtn.Text = "Apply";
            ApplyBtn.UseVisualStyleBackColor = true;
            ApplyBtn.Click += ApplyBtn_Click;
            // 
            // inputHeight
            // 
            inputHeight.Location = new Point(104, 119);
            inputHeight.Name = "inputHeight";
            inputHeight.Size = new Size(100, 23);
            inputHeight.TabIndex = 7;
            inputHeight.Validating += inputSize_Validating;
            // 
            // inputWidth
            // 
            inputWidth.Location = new Point(104, 71);
            inputWidth.Name = "inputWidth";
            inputWidth.Size = new Size(100, 23);
            inputWidth.TabIndex = 6;
            inputWidth.Validating += inputSize_Validating;
            // 
            // isRandom
            // 
            isRandom.AutoSize = true;
            isRandom.Location = new Point(23, 179);
            isRandom.Name = "isRandom";
            isRandom.Size = new Size(71, 19);
            isRandom.TabIndex = 5;
            isRandom.Text = "Random";
            isRandom.UseVisualStyleBackColor = true;
            // 
            // heightLbl
            // 
            heightLbl.AutoSize = true;
            heightLbl.Location = new Point(23, 127);
            heightLbl.Name = "heightLbl";
            heightLbl.Size = new Size(43, 15);
            heightLbl.TabIndex = 4;
            heightLbl.Text = "Height";
            // 
            // widthLbl
            // 
            widthLbl.AutoSize = true;
            widthLbl.Location = new Point(23, 79);
            widthLbl.Name = "widthLbl";
            widthLbl.Size = new Size(39, 15);
            widthLbl.TabIndex = 2;
            widthLbl.Text = "Width";
            // 
            // inputMapName
            // 
            inputMapName.Location = new Point(104, 27);
            inputMapName.Name = "inputMapName";
            inputMapName.Size = new Size(100, 23);
            inputMapName.TabIndex = 1;
            inputMapName.Validating += inputMapName_Validating;
            // 
            // mapName
            // 
            mapName.AutoSize = true;
            mapName.Location = new Point(23, 35);
            mapName.Name = "mapName";
            mapName.Size = new Size(64, 15);
            mapName.TabIndex = 0;
            mapName.Text = "Map name";
            // 
            // changesizes
            // 
            changesizes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            changesizes.Controls.Add(changeSizeBtn);
            changesizes.Controls.Add(inputChangeHeight);
            changesizes.Controls.Add(inputChangeWidth);
            changesizes.Controls.Add(changeHeight);
            changesizes.Controls.Add(changeWidth);
            changesizes.Enabled = false;
            changesizes.Location = new Point(555, 233);
            changesizes.Name = "changesizes";
            changesizes.Size = new Size(233, 205);
            changesizes.TabIndex = 1;
            changesizes.TabStop = false;
            changesizes.Text = "Change Size";
            changesizes.Visible = false;
            // 
            // changeSizeBtn
            // 
            changeSizeBtn.Location = new Point(70, 149);
            changeSizeBtn.Name = "changeSizeBtn";
            changeSizeBtn.Size = new Size(86, 31);
            changeSizeBtn.TabIndex = 12;
            changeSizeBtn.Text = "Change";
            changeSizeBtn.UseVisualStyleBackColor = true;
            changeSizeBtn.Click += changeSizeBtn_Click;
            // 
            // inputChangeHeight
            // 
            inputChangeHeight.Location = new Point(110, 84);
            inputChangeHeight.Name = "inputChangeHeight";
            inputChangeHeight.Size = new Size(100, 23);
            inputChangeHeight.TabIndex = 11;
            inputChangeHeight.Validating += inputSize_Validating;
            // 
            // inputChangeWidth
            // 
            inputChangeWidth.Location = new Point(110, 36);
            inputChangeWidth.Name = "inputChangeWidth";
            inputChangeWidth.Size = new Size(100, 23);
            inputChangeWidth.TabIndex = 10;
            inputChangeWidth.Validating += inputSize_Validating;
            // 
            // changeHeight
            // 
            changeHeight.AutoSize = true;
            changeHeight.Location = new Point(29, 92);
            changeHeight.Name = "changeHeight";
            changeHeight.Size = new Size(43, 15);
            changeHeight.TabIndex = 9;
            changeHeight.Text = "Height";
            // 
            // changeWidth
            // 
            changeWidth.AutoSize = true;
            changeWidth.Location = new Point(29, 44);
            changeWidth.Name = "changeWidth";
            changeWidth.Size = new Size(39, 15);
            changeWidth.TabIndex = 8;
            changeWidth.Text = "Width";
            // 
            // timer
            // 
            timer.Interval = 15;
            timer.Tick += timer_Tick;
            // 
            // errorProvider
            // 
            errorProvider.BlinkRate = 500;
            errorProvider.ContainerControl = this;
            // 
            // CreatingMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(changesizes);
            Controls.Add(mapInfo);
            KeyPreview = true;
            Name = "CreatingMap";
            Text = "CreatingMap";
            mapInfo.ResumeLayout(false);
            mapInfo.PerformLayout();
            changesizes.ResumeLayout(false);
            changesizes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox mapInfo;
        private TextBox inputHeight;
        private TextBox inputWidth;
        private CheckBox isRandom;
        private Label widthLbl;
        private TextBox inputMapName;
        private Label mapName;
        private Label heightLbl;
        private Button ApplyBtn;
        private GroupBox changesizes;
        private TextBox inputChangeHeight;
        private TextBox inputChangeWidth;
        private Label changeHeight;
        private Label changeWidth;
        private Button changeSizeBtn;
        private System.Windows.Forms.Timer timer;
        private SaveFileDialog saveFileDialog;
        private ErrorProvider errorProvider;
    }
}