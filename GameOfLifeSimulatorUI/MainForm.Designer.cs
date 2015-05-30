namespace GameOfLifeSimulatorUI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.txt_Height = new System.Windows.Forms.TextBox();
            this.txt_Width = new System.Windows.Forms.TextBox();
            this.btn_Simulate = new System.Windows.Forms.Button();
            this.txt_Cycles = new System.Windows.Forms.TextBox();
            this.txt_Rarity = new System.Windows.Forms.TextBox();
            this.lbl_Rarity = new System.Windows.Forms.Label();
            this.lbl_CyclesInfo = new System.Windows.Forms.Label();
            this.lbl_Cycles = new System.Windows.Forms.Label();
            this.timer_Autoplay = new System.Windows.Forms.Timer(this.components);
            this.btn_PlayControl = new System.Windows.Forms.Button();
            this.txt_Fps = new System.Windows.Forms.TextBox();
            this.lbl_AutoPlay = new System.Windows.Forms.Label();
            this.lbl_Fps = new System.Windows.Forms.Label();
            this.panel_AutoPlay = new System.Windows.Forms.Panel();
            this.btn_Filter = new System.Windows.Forms.Button();
            this.btn_Import = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.saveFileDialog_Export = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog_Import = new System.Windows.Forms.OpenFileDialog();
            this.picturebox_Preview = new GameOfLifeSimulatorUI.MyPictureBox();
            this.btn_SetRules = new System.Windows.Forms.Button();
            this.panel_AutoPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(12, 76);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(85, 23);
            this.btn_Generate.TabIndex = 4;
            this.btn_Generate.Text = "Generate";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // lbl_Height
            // 
            this.lbl_Height.AutoSize = true;
            this.lbl_Height.Location = new System.Drawing.Point(9, 9);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(38, 13);
            this.lbl_Height.TabIndex = 5;
            this.lbl_Height.Text = "Height";
            // 
            // lbl_Width
            // 
            this.lbl_Width.AutoSize = true;
            this.lbl_Width.Location = new System.Drawing.Point(62, 9);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(35, 13);
            this.lbl_Width.TabIndex = 6;
            this.lbl_Width.Text = "Width";
            // 
            // txt_Height
            // 
            this.txt_Height.Location = new System.Drawing.Point(12, 25);
            this.txt_Height.Name = "txt_Height";
            this.txt_Height.Size = new System.Drawing.Size(35, 20);
            this.txt_Height.TabIndex = 1;
            this.txt_Height.Text = "30";
            // 
            // txt_Width
            // 
            this.txt_Width.Location = new System.Drawing.Point(62, 25);
            this.txt_Width.Name = "txt_Width";
            this.txt_Width.Size = new System.Drawing.Size(35, 20);
            this.txt_Width.TabIndex = 2;
            this.txt_Width.Text = "30";
            // 
            // btn_Simulate
            // 
            this.btn_Simulate.Location = new System.Drawing.Point(12, 141);
            this.btn_Simulate.Name = "btn_Simulate";
            this.btn_Simulate.Size = new System.Drawing.Size(58, 39);
            this.btn_Simulate.TabIndex = 6;
            this.btn_Simulate.Text = "Simulate cycles";
            this.btn_Simulate.UseVisualStyleBackColor = true;
            this.btn_Simulate.Click += new System.EventHandler(this.btn_Simulate_Click);
            // 
            // txt_Cycles
            // 
            this.txt_Cycles.Location = new System.Drawing.Point(76, 151);
            this.txt_Cycles.Name = "txt_Cycles";
            this.txt_Cycles.Size = new System.Drawing.Size(27, 20);
            this.txt_Cycles.TabIndex = 5;
            this.txt_Cycles.Text = "1";
            // 
            // txt_Rarity
            // 
            this.txt_Rarity.Location = new System.Drawing.Point(62, 50);
            this.txt_Rarity.Name = "txt_Rarity";
            this.txt_Rarity.Size = new System.Drawing.Size(35, 20);
            this.txt_Rarity.TabIndex = 3;
            this.txt_Rarity.Text = "2";
            // 
            // lbl_Rarity
            // 
            this.lbl_Rarity.AutoSize = true;
            this.lbl_Rarity.Location = new System.Drawing.Point(12, 53);
            this.lbl_Rarity.Name = "lbl_Rarity";
            this.lbl_Rarity.Size = new System.Drawing.Size(34, 13);
            this.lbl_Rarity.TabIndex = 12;
            this.lbl_Rarity.Text = "Rarity";
            // 
            // lbl_CyclesInfo
            // 
            this.lbl_CyclesInfo.AutoSize = true;
            this.lbl_CyclesInfo.Location = new System.Drawing.Point(14, 183);
            this.lbl_CyclesInfo.Name = "lbl_CyclesInfo";
            this.lbl_CyclesInfo.Size = new System.Drawing.Size(60, 13);
            this.lbl_CyclesInfo.TabIndex = 13;
            this.lbl_CyclesInfo.Text = "Life cycles:";
            // 
            // lbl_Cycles
            // 
            this.lbl_Cycles.AutoSize = true;
            this.lbl_Cycles.Location = new System.Drawing.Point(14, 199);
            this.lbl_Cycles.Name = "lbl_Cycles";
            this.lbl_Cycles.Size = new System.Drawing.Size(13, 13);
            this.lbl_Cycles.TabIndex = 14;
            this.lbl_Cycles.Text = "0";
            // 
            // timer_Autoplay
            // 
            this.timer_Autoplay.Tick += new System.EventHandler(this.timer_Autoplay_Tick);
            // 
            // btn_PlayControl
            // 
            this.btn_PlayControl.Location = new System.Drawing.Point(7, 23);
            this.btn_PlayControl.Name = "btn_PlayControl";
            this.btn_PlayControl.Size = new System.Drawing.Size(58, 20);
            this.btn_PlayControl.TabIndex = 8;
            this.btn_PlayControl.Text = "Play";
            this.btn_PlayControl.UseVisualStyleBackColor = true;
            this.btn_PlayControl.Click += new System.EventHandler(this.btn_PlayControl_Click);
            // 
            // txt_Fps
            // 
            this.txt_Fps.Location = new System.Drawing.Point(71, 23);
            this.txt_Fps.Name = "txt_Fps";
            this.txt_Fps.Size = new System.Drawing.Size(27, 20);
            this.txt_Fps.TabIndex = 7;
            this.txt_Fps.Text = "2";
            // 
            // lbl_AutoPlay
            // 
            this.lbl_AutoPlay.AutoSize = true;
            this.lbl_AutoPlay.Location = new System.Drawing.Point(11, 7);
            this.lbl_AutoPlay.Name = "lbl_AutoPlay";
            this.lbl_AutoPlay.Size = new System.Drawing.Size(52, 13);
            this.lbl_AutoPlay.TabIndex = 17;
            this.lbl_AutoPlay.Text = "Auto Play";
            // 
            // lbl_Fps
            // 
            this.lbl_Fps.AutoSize = true;
            this.lbl_Fps.Location = new System.Drawing.Point(69, 7);
            this.lbl_Fps.Name = "lbl_Fps";
            this.lbl_Fps.Size = new System.Drawing.Size(27, 13);
            this.lbl_Fps.TabIndex = 18;
            this.lbl_Fps.Text = "FPS";
            // 
            // panel_AutoPlay
            // 
            this.panel_AutoPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_AutoPlay.Controls.Add(this.btn_PlayControl);
            this.panel_AutoPlay.Controls.Add(this.lbl_Fps);
            this.panel_AutoPlay.Controls.Add(this.txt_Fps);
            this.panel_AutoPlay.Controls.Add(this.lbl_AutoPlay);
            this.panel_AutoPlay.Location = new System.Drawing.Point(2, 227);
            this.panel_AutoPlay.Name = "panel_AutoPlay";
            this.panel_AutoPlay.Size = new System.Drawing.Size(104, 58);
            this.panel_AutoPlay.TabIndex = 19;
            // 
            // btn_Filter
            // 
            this.btn_Filter.Location = new System.Drawing.Point(15, 291);
            this.btn_Filter.Name = "btn_Filter";
            this.btn_Filter.Size = new System.Drawing.Size(75, 23);
            this.btn_Filter.TabIndex = 20;
            this.btn_Filter.Text = "Filter static";
            this.btn_Filter.UseVisualStyleBackColor = true;
            this.btn_Filter.Click += new System.EventHandler(this.btn_Filter_Click);
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(2, 334);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(52, 23);
            this.btn_Import.TabIndex = 21;
            this.btn_Import.Text = "Import";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(54, 334);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(52, 23);
            this.btn_Export.TabIndex = 22;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // saveFileDialog_Export
            // 
            this.saveFileDialog_Export.FileName = "GameOfLife.txt";
            this.saveFileDialog_Export.Filter = "Txt files|*.txt";
            // 
            // openFileDialog_Import
            // 
            this.openFileDialog_Import.FileName = "GameOfLife.txt";
            this.openFileDialog_Import.Filter = "Txt files|*.txt";
            // 
            // picturebox_Preview
            // 
            this.picturebox_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturebox_Preview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picturebox_Preview.Location = new System.Drawing.Point(112, 12);
            this.picturebox_Preview.Name = "picturebox_Preview";
            this.picturebox_Preview.Size = new System.Drawing.Size(355, 345);
            this.picturebox_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox_Preview.TabIndex = 0;
            this.picturebox_Preview.TabStop = false;
            // 
            // btn_SetRules
            // 
            this.btn_SetRules.Location = new System.Drawing.Point(26, 103);
            this.btn_SetRules.Name = "btn_SetRules";
            this.btn_SetRules.Size = new System.Drawing.Size(57, 23);
            this.btn_SetRules.TabIndex = 23;
            this.btn_SetRules.Text = "Set Rule";
            this.btn_SetRules.UseVisualStyleBackColor = true;
            this.btn_SetRules.Click += new System.EventHandler(this.btn_SetRules_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 369);
            this.Controls.Add(this.btn_SetRules);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.btn_Filter);
            this.Controls.Add(this.panel_AutoPlay);
            this.Controls.Add(this.lbl_Cycles);
            this.Controls.Add(this.lbl_CyclesInfo);
            this.Controls.Add(this.lbl_Rarity);
            this.Controls.Add(this.txt_Rarity);
            this.Controls.Add(this.txt_Cycles);
            this.Controls.Add(this.btn_Simulate);
            this.Controls.Add(this.txt_Width);
            this.Controls.Add(this.txt_Height);
            this.Controls.Add(this.lbl_Width);
            this.Controls.Add(this.lbl_Height);
            this.Controls.Add(this.btn_Generate);
            this.Controls.Add(this.picturebox_Preview);
            this.MinimumSize = new System.Drawing.Size(160, 408);
            this.Name = "MainForm";
            this.Text = "Game of Life";
            this.panel_AutoPlay.ResumeLayout(false);
            this.panel_AutoPlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_Preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.TextBox txt_Height;
        private System.Windows.Forms.TextBox txt_Width;
        private System.Windows.Forms.Button btn_Simulate;
        private System.Windows.Forms.TextBox txt_Cycles;
        private System.Windows.Forms.TextBox txt_Rarity;
        private System.Windows.Forms.Label lbl_Rarity;
        private System.Windows.Forms.Label lbl_CyclesInfo;
        private System.Windows.Forms.Label lbl_Cycles;
        private System.Windows.Forms.Timer timer_Autoplay;
        private System.Windows.Forms.Button btn_PlayControl;
        private System.Windows.Forms.TextBox txt_Fps;
        private System.Windows.Forms.Label lbl_AutoPlay;
        private System.Windows.Forms.Label lbl_Fps;
        private System.Windows.Forms.Panel panel_AutoPlay;
        private MyPictureBox picturebox_Preview;
        private System.Windows.Forms.Button btn_Filter;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Export;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Import;
        private System.Windows.Forms.Button btn_SetRules;
    }
}

