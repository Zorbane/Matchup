namespace MatchupWindows.Controls
{
    partial class LeagueDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MatchupsGrid = new System.Windows.Forms.DataGridView();
            this.LeagueStandingsGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MatchupGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MatchupsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeagueStandingsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchupGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MatchupsGrid
            // 
            this.MatchupsGrid.AllowUserToAddRows = false;
            this.MatchupsGrid.AllowUserToDeleteRows = false;
            this.MatchupsGrid.AllowUserToResizeRows = false;
            this.MatchupsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MatchupsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatchupsGrid.Location = new System.Drawing.Point(0, 0);
            this.MatchupsGrid.Name = "MatchupsGrid";
            this.MatchupsGrid.ReadOnly = true;
            this.MatchupsGrid.RowHeadersVisible = false;
            this.MatchupsGrid.Size = new System.Drawing.Size(599, 112);
            this.MatchupsGrid.TabIndex = 0;
            this.MatchupsGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.MatchupsGrid_CellFormatting);
            this.MatchupsGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MatchupsGrid_RowEnter);
            // 
            // LeagueStandingsGrid
            // 
            this.LeagueStandingsGrid.AllowUserToAddRows = false;
            this.LeagueStandingsGrid.AllowUserToDeleteRows = false;
            this.LeagueStandingsGrid.AllowUserToResizeRows = false;
            this.LeagueStandingsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LeagueStandingsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeagueStandingsGrid.Location = new System.Drawing.Point(0, 0);
            this.LeagueStandingsGrid.Name = "LeagueStandingsGrid";
            this.LeagueStandingsGrid.ReadOnly = true;
            this.LeagueStandingsGrid.RowHeadersVisible = false;
            this.LeagueStandingsGrid.Size = new System.Drawing.Size(599, 152);
            this.LeagueStandingsGrid.TabIndex = 1;
            this.LeagueStandingsGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.LeagueStandingsGrid_CellFormatting);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MatchupGrid);
            this.splitContainer1.Panel1.Controls.Add(this.MatchupsGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LeagueStandingsGrid);
            this.splitContainer1.Size = new System.Drawing.Size(599, 356);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 2;
            // 
            // MatchupGrid
            // 
            this.MatchupGrid.AllowUserToAddRows = false;
            this.MatchupGrid.AllowUserToDeleteRows = false;
            this.MatchupGrid.AllowUserToOrderColumns = true;
            this.MatchupGrid.AllowUserToResizeRows = false;
            this.MatchupGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MatchupGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatchupGrid.Location = new System.Drawing.Point(0, 118);
            this.MatchupGrid.Name = "MatchupGrid";
            this.MatchupGrid.ReadOnly = true;
            this.MatchupGrid.RowHeadersVisible = false;
            this.MatchupGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.MatchupGrid.Size = new System.Drawing.Size(599, 82);
            this.MatchupGrid.TabIndex = 1;
            this.MatchupGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.LeagueStandingsGrid_CellFormatting);
            // 
            // LeagueDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LeagueDisplay";
            this.Size = new System.Drawing.Size(599, 356);
            this.Load += new System.EventHandler(this.LeagueDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MatchupsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeagueStandingsGrid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MatchupGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.DataGridView MatchupsGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.DataGridView LeagueStandingsGrid;
        private System.Windows.Forms.DataGridView MatchupGrid;
    }
}
