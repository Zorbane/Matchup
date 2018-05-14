namespace MatchupWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GameDayPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StandingRadio = new System.Windows.Forms.RadioButton();
            this.WinPercentageRadio = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StandingTrackBar = new System.Windows.Forms.TrackBar();
            this.StandingsTextBox = new System.Windows.Forms.TextBox();
            this.WinPercentageTextBox = new System.Windows.Forms.TextBox();
            this.Standing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WinPercentageTrackBar = new System.Windows.Forms.TrackBar();
            this.CopyButton = new System.Windows.Forms.Button();
            this.LoadLeaguesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.MainTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StandingTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinPercentageTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Controls.Add(this.tabPage1);
            this.MainTab.Location = new System.Drawing.Point(12, 112);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(864, 395);
            this.MainTab.TabIndex = 0;
            this.MainTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.MainTab_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(856, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(801, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(12, 513);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Load Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GameDayPicker
            // 
            this.GameDayPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.GameDayPicker.Location = new System.Drawing.Point(48, 12);
            this.GameDayPicker.Name = "GameDayPicker";
            this.GameDayPicker.Size = new System.Drawing.Size(96, 20);
            this.GameDayPicker.TabIndex = 3;
            this.GameDayPicker.ValueChanged += new System.EventHandler(this.GameDayPicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StandingRadio);
            this.groupBox1.Controls.Add(this.WinPercentageRadio);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 68);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Type";
            // 
            // StandingRadio
            // 
            this.StandingRadio.AutoSize = true;
            this.StandingRadio.Location = new System.Drawing.Point(6, 42);
            this.StandingRadio.Name = "StandingRadio";
            this.StandingRadio.Size = new System.Drawing.Size(67, 17);
            this.StandingRadio.TabIndex = 1;
            this.StandingRadio.Text = "Standing";
            this.StandingRadio.UseVisualStyleBackColor = true;
            this.StandingRadio.CheckedChanged += new System.EventHandler(this.StandingRadio_CheckedChanged);
            // 
            // WinPercentageRadio
            // 
            this.WinPercentageRadio.AutoSize = true;
            this.WinPercentageRadio.Checked = true;
            this.WinPercentageRadio.Location = new System.Drawing.Point(6, 19);
            this.WinPercentageRadio.Name = "WinPercentageRadio";
            this.WinPercentageRadio.Size = new System.Drawing.Size(55, 17);
            this.WinPercentageRadio.TabIndex = 0;
            this.WinPercentageRadio.TabStop = true;
            this.WinPercentageRadio.Text = "Win %";
            this.WinPercentageRadio.UseVisualStyleBackColor = true;
            this.WinPercentageRadio.CheckedChanged += new System.EventHandler(this.WinPercentageRadio_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StandingTrackBar);
            this.panel1.Controls.Add(this.StandingsTextBox);
            this.panel1.Controls.Add(this.WinPercentageTextBox);
            this.panel1.Controls.Add(this.Standing);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.WinPercentageTrackBar);
            this.panel1.Location = new System.Drawing.Point(159, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 94);
            this.panel1.TabIndex = 6;
            // 
            // StandingTrackBar
            // 
            this.StandingTrackBar.Enabled = false;
            this.StandingTrackBar.Location = new System.Drawing.Point(138, 45);
            this.StandingTrackBar.Maximum = 20;
            this.StandingTrackBar.Name = "StandingTrackBar";
            this.StandingTrackBar.Size = new System.Drawing.Size(129, 45);
            this.StandingTrackBar.TabIndex = 5;
            this.StandingTrackBar.Value = 10;
            this.StandingTrackBar.Scroll += new System.EventHandler(this.StandingTrackBar_Scroll);
            // 
            // StandingsTextBox
            // 
            this.StandingsTextBox.Enabled = false;
            this.StandingsTextBox.Location = new System.Drawing.Point(204, 13);
            this.StandingsTextBox.Name = "StandingsTextBox";
            this.StandingsTextBox.Size = new System.Drawing.Size(52, 20);
            this.StandingsTextBox.TabIndex = 4;
            this.StandingsTextBox.Text = "10";
            this.StandingsTextBox.Leave += new System.EventHandler(this.StandingsTextBox_Leave);
            // 
            // WinPercentageTextBox
            // 
            this.WinPercentageTextBox.Location = new System.Drawing.Point(70, 13);
            this.WinPercentageTextBox.Name = "WinPercentageTextBox";
            this.WinPercentageTextBox.Size = new System.Drawing.Size(43, 20);
            this.WinPercentageTextBox.TabIndex = 3;
            this.WinPercentageTextBox.Text = "20";
            this.WinPercentageTextBox.Leave += new System.EventHandler(this.WinPercentageTextBox_Leave);
            // 
            // Standing
            // 
            this.Standing.AutoSize = true;
            this.Standing.Location = new System.Drawing.Point(149, 16);
            this.Standing.Name = "Standing";
            this.Standing.Size = new System.Drawing.Size(49, 13);
            this.Standing.TabIndex = 2;
            this.Standing.Text = "Standing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Win %";
            // 
            // WinPercentageTrackBar
            // 
            this.WinPercentageTrackBar.Location = new System.Drawing.Point(3, 45);
            this.WinPercentageTrackBar.Maximum = 30;
            this.WinPercentageTrackBar.Minimum = 10;
            this.WinPercentageTrackBar.Name = "WinPercentageTrackBar";
            this.WinPercentageTrackBar.Size = new System.Drawing.Size(129, 45);
            this.WinPercentageTrackBar.TabIndex = 0;
            this.WinPercentageTrackBar.Value = 20;
            this.WinPercentageTrackBar.Scroll += new System.EventHandler(this.WinPercentageTrackBar_Scroll);
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(733, 12);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(139, 105);
            this.CopyButton.TabIndex = 7;
            this.CopyButton.Text = "Copy to Clipboard";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // LoadLeaguesBackgroundWorker
            // 
            this.LoadLeaguesBackgroundWorker.WorkerReportsProgress = true;
            this.LoadLeaguesBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadLeaguesBackgroundWorker_DoWork);
            this.LoadLeaguesBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadLeaguesBackgroundWorker_ProgressChanged);
            this.LoadLeaguesBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadLeaguesBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 548);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GameDayPicker);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(904, 587);
            this.Name = "MainForm";
            this.Text = "Matchup Maker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StandingTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinPercentageTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker GameDayPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton StandingRadio;
        private System.Windows.Forms.RadioButton WinPercentageRadio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar StandingTrackBar;
        private System.Windows.Forms.TextBox StandingsTextBox;
        private System.Windows.Forms.TextBox WinPercentageTextBox;
        private System.Windows.Forms.Label Standing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar WinPercentageTrackBar;
        private System.Windows.Forms.Button CopyButton;
        private System.ComponentModel.BackgroundWorker LoadLeaguesBackgroundWorker;
    }
}

