using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatchupLib.Models;
using MatchupWindows.ViewModels;

namespace MatchupWindows.Controls
{
    public partial class LeagueDisplay : UserControl
    {
        public LeagueDisplay()
        {
            InitializeComponent();

            LeagueStandingsGrid.AutoGenerateColumns = false;
            MatchupsGrid.AutoGenerateColumns = false;
            MatchupGrid.AutoGenerateColumns = false;
        }

        private void InitGrid()
        {
            #region Matchups Grid

            MatchupsGrid.Columns.Add(GetColumn("Rank", "AwayTeamStanding"));
            MatchupsGrid.Columns.Add(GetColumn("Win %", "AwayTeamWinPercentage"));
            MatchupsGrid.Columns.Add(GetColumn("Away Team", "AwayTeam"));

            MatchupsGrid.Columns.Add(GetColumn("Rank", "HomeTeamStanding"));
            MatchupsGrid.Columns.Add(GetColumn("Win %", "HomeTeamWinPercentage"));
            MatchupsGrid.Columns.Add(GetColumn("Home Team", "HomeTeam"));

            MatchupsGrid.Columns.Add(GetColumn("Rank Difference", "StandingDifference", 125));
            MatchupsGrid.Columns.Add(GetColumn("Win % Difference", "WinPercentageDifference", 125));

            #endregion

            #region Matchup Grid

            MatchupGrid.Columns.Add(GetColumn("Rank", "Rank"));
            MatchupGrid.Columns.Add(GetColumn("Name", "Name"));
            MatchupGrid.Columns.Add(GetColumn("GP", "GamesPlayed"));
            MatchupGrid.Columns.Add(GetColumn("Wins", "Wins"));
            MatchupGrid.Columns.Add(GetColumn("Losses", "Losses"));
            MatchupGrid.Columns.Add(GetColumn("OvertimeLosses", "OvertimeLosses", 110));
            MatchupGrid.Columns.Add(GetColumn("ShootoutLosses", "ShootoutLosses", 110));
            MatchupGrid.Columns.Add(GetColumn("Points", "Points"));
            MatchupGrid.Columns.Add(GetColumn("Win Percentage", "WinPercentage", 110));
            MatchupGrid.Columns.Add(GetColumn("Goals For", "GoalsFor"));
            MatchupGrid.Columns.Add(GetColumn("Goals Against", "GoalsAgainst"));
            MatchupGrid.Columns.Add(GetColumn("Last 10", "Last10Games"));
            MatchupGrid.Columns.Add(GetColumn("Streak", "Streak"));

            #endregion

            #region Team Grid

            LeagueStandingsGrid.Columns.Add(GetColumn("Rank", "Rank"));
            LeagueStandingsGrid.Columns.Add(GetColumn("Name", "Name"));
            LeagueStandingsGrid.Columns.Add(GetColumn("GP", "GamesPlayed"));
            LeagueStandingsGrid.Columns.Add(GetColumn("Wins", "Wins"));
            LeagueStandingsGrid.Columns.Add(GetColumn("Losses", "Losses"));
            LeagueStandingsGrid.Columns.Add(GetColumn("Overtime Losses", "OvertimeLosses", 110));
            LeagueStandingsGrid.Columns.Add(GetColumn("Shootout Losses", "ShootoutLosses", 110));
            LeagueStandingsGrid.Columns.Add(GetColumn("Points", "Points"));
            LeagueStandingsGrid.Columns.Add(GetColumn("Win Percentage", "WinPercentage", 110));
            LeagueStandingsGrid.Columns.Add(GetColumn("Goals For", "GoalsFor"));
            LeagueStandingsGrid.Columns.Add(GetColumn("Goals Against", "GoalsAgainst"));
            LeagueStandingsGrid.Columns.Add(GetColumn("Last 10", "Last10Games"));
            LeagueStandingsGrid.Columns.Add(GetColumn("Streak", "Streak"));

            #endregion

        }

        private DataGridViewTextBoxColumn GetColumn(string header, string name, int width = 100)
        {
            var col = new DataGridViewTextBoxColumn();
            col.HeaderText = header;
            col.DataPropertyName = name;
            col.Name = name;
            col.Width = width;

            return col;
        }


        public void LoadData(List<Game> games, List<Team> teams)
        {
            var matchups = new List<Matchup>();

            foreach (var game in games)
            {
                matchups.Add(new Matchup(game));
            }

            var standingsBS = new SortableBindingList<Team>(teams);
            var gamesBS = new SortableBindingList<Matchup>(matchups);

            LeagueStandingsGrid.DataSource = standingsBS;
            MatchupsGrid.DataSource = gamesBS;
        }

        private void LeagueDisplay_Load(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void MatchupsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var percentFields = new string[] { "AwayTeamWinPercentage", "HomeTeamWinPercentage", "WinPercentageDifference" };

            var colName = MatchupsGrid.Columns[e.ColumnIndex].Name;

            if (percentFields.Contains(colName))
            {
                e.Value = ((decimal)e.Value).ToString("N2");
                e.FormattingApplied = true;
            }
        }

        private void LeagueStandingsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var percentFields = new string[] { "WinPercentage" };
            var grid = (DataGridView)sender;
            var colName = grid.Columns[e.ColumnIndex].Name;

            if (percentFields.Contains(colName))
            {
                e.Value = ((decimal)e.Value).ToString("N2");
                e.FormattingApplied = true;
            }
        }

        private void MatchupsGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var matchup = (Matchup)MatchupsGrid.Rows[e.RowIndex].DataBoundItem;
                var matchupTeams = new List<Team>()
                {
                    matchup.AwayTeam,
                    matchup.HomeTeam,
                };

                MatchupGrid.DataSource = matchupTeams;
            }
        }
    }
}
