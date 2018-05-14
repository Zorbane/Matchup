using MatchupLib.Models;
using MatchupLib.WebParser;
using MatchupLib.WebParser.Schedule;
using MatchupWindows.Controls;
using MatchupWindows.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MatchupWindows
{
    public partial class MainForm : Form
    {
        Dictionary<string, LeagueDisplay> Leagues = new Dictionary<string, LeagueDisplay>();
        Dictionary<string, List<Team>> Teams = new Dictionary<string, List<Team>>();
        ProgressForm progressForm;

        Dictionary<string, List<Game>> Games = new Dictionary<string, List<Game>>(); //this is for loading the data asynchronously

        public MainForm()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        #region Data Methods

        private void LoadData(DateTime gameday)
        {
            Cursor = Cursors.WaitCursor;

            LoadLeaguesBackgroundWorker.RunWorkerAsync(gameday);
            progressForm = new ProgressForm();
            progressForm.ShowDialog(this);

            Cursor = Cursors.Default;
        }

        private void FilterData()
        {
            var field = "";
            decimal spread = 10M;
            if (WinPercentageRadio.Checked)
            {
                field = "WinPercentageDifference";
                spread = WinPercentageTrackBar.Value;
            }
            else
            {
                field = "StandingDifference";
                spread = StandingTrackBar.Value;
            }

            foreach (var display in Leagues.Values)
            {
                foreach (DataGridViewRow row in display.MatchupsGrid.Rows)
                {
                    decimal difference = decimal.Parse(row.Cells[field].Value.ToString());

                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[display.MatchupsGrid.DataSource];
                    currencyManager.SuspendBinding();
                    row.Visible = difference >= spread;                    
                    currencyManager.ResumeBinding();
                }
            }
        }

        #endregion

        #region UI Events

        private void WinPercentageRadio_CheckedChanged(object sender, EventArgs e)
        {
            WinPercentageTextBox.Enabled = WinPercentageRadio.Checked;
            WinPercentageTrackBar.Enabled = WinPercentageRadio.Checked;

            StandingsTextBox.Enabled = StandingRadio.Checked;
            StandingTrackBar.Enabled = StandingRadio.Checked;

            FilterData();
        }

        private void StandingRadio_CheckedChanged(object sender, EventArgs e)
        {
            WinPercentageTextBox.Enabled = WinPercentageRadio.Checked;
            WinPercentageTrackBar.Enabled = WinPercentageRadio.Checked;

            StandingsTextBox.Enabled = StandingRadio.Checked;
            StandingTrackBar.Enabled = StandingRadio.Checked;

            FilterData();
        }

        private void GameDayPicker_ValueChanged(object sender, EventArgs e)
        {
            LoadData(GameDayPicker.Value);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("NOTE: This has not been updated for the 2017-2018 season and now only work for the WHL and OHL.  Please choose dates for the 2016-2017 season (Oct 2016 to around April or May 2017)");
            //create the tabs
            foreach (LeagueType leagueType in Enum.GetValues(typeof(LeagueType)))
            {
                //most don't work anymore, the structure of the data must have changed
                if (leagueType != LeagueType.OHL && leagueType != LeagueType.WHL)
                {
                    continue;
                }
                var display = new LeagueDisplay();
                TabPage tab;


                Leagues.Add(leagueType.ToString(), display);

                display.MatchupsGrid.Sorted += LeagueInfoGrid_Sorted;

                //if its one use the first tab
                if (Leagues.Count == 1)
                {
                    tab = MainTab.TabPages[0];
                    tab.Text = leagueType.ToString();
                }
                else
                {
                    MainTab.TabPages.Add(leagueType.ToString(), leagueType.ToString());
                    tab = MainTab.TabPages[leagueType.ToString()];
                }

                tab.Controls.Add(display);
                display.Dock = DockStyle.Fill;
            }
        }

        private void LeagueInfoGrid_Sorted(object sender, EventArgs e)
        {
            FilterData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData(GameDayPicker.Value);
        }

        private void WinPercentageTrackBar_Scroll(object sender, EventArgs e)
        {
            WinPercentageTextBox.Text = WinPercentageTrackBar.Value.ToString();
            FilterData();
        }

        private void StandingTrackBar_Scroll(object sender, EventArgs e)
        {
            StandingsTextBox.Text = StandingTrackBar.Value.ToString();
            FilterData();
        }

        private void WinPercentageTextBox_Leave(object sender, EventArgs e)
        {
            int text;

            if (!int.TryParse(WinPercentageTextBox.Text, out text))
            {
                MessageBox.Show("Invalid number.");
            }

            if (text == WinPercentageTrackBar.Value)
            {
                return;
            }

            if (text >= WinPercentageTrackBar.Minimum && text <= WinPercentageTrackBar.Maximum)
            {
                WinPercentageTrackBar.Value = text;
                FilterData();
            }
            else
            {
                MessageBox.Show("Invalid number.");
            }
        }

        private void StandingsTextBox_Leave(object sender, EventArgs e)
        {
            int text;

            if (!int.TryParse(StandingsTextBox.Text, out text))
            {
                MessageBox.Show("Invalid number.");
            }

            if (text == StandingTrackBar.Value)
            {
                return;
            }

            if (text >= StandingTrackBar.Minimum && text <= StandingTrackBar.Maximum)
            {
                StandingTrackBar.Value = text;
                FilterData();
            }
            else
            {
                MessageBox.Show("Invalid number.");
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            var display = Leagues[MainTab.SelectedTab.Text];
            var text = new StringBuilder();
            text.AppendLine(MainTab.SelectedTab.Text);

            var field = "";
            decimal spread = 10M;
            if (WinPercentageRadio.Checked)
            {
                field = "WinPercentageDifference";
                spread = WinPercentageTrackBar.Value;
            }
            else
            {
                field = "StandingDifference";
                spread = StandingTrackBar.Value;
            }


            foreach (DataGridViewRow row in display.MatchupsGrid.Rows)
            {
                decimal difference = decimal.Parse(row.Cells[field].Value.ToString());

                if (difference >= spread)
                {
                    var matchup = (Matchup)row.DataBoundItem;

                    text.Append(matchup.AwayTeam.Name);
                    text.Append("("); text.Append(matchup.AwayTeamStanding); text.Append("/"); text.Append(matchup.AwayTeamWinPercentage.ToString("N2")); text.Append("%)");
                    text.Append(" ");
                    text.Append("vs ");
                    text.Append(matchup.HomeTeam.Name);
                    text.Append("("); text.Append(matchup.HomeTeamStanding); text.Append("/"); text.Append(matchup.HomeTeamWinPercentage.ToString("N2")); text.Append("%)");
                    text.Append(" - ");
                    text.Append(matchup.StandingDifference); text.Append(" ");
                    text.Append(matchup.WinPercentageDifference.ToString("N2"));
                    text.AppendLine("%");
                }
            }

            Clipboard.SetText(text.ToString());

        }

        private void MainTab_Selected(object sender, TabControlEventArgs e)
        {
            FilterData();
        }

        #endregion

        #region Background Worker

        private void LoadLeaguesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var gameday = (DateTime)e.Argument;
            int leagues = Enum.GetValues(typeof(LeagueType)).Length;
            int leagueCounter = 1;

            foreach (LeagueType leagueType in Enum.GetValues(typeof(LeagueType)))
            {
                try
                {
                    //most don't work anymore, the structure of the data must have changed
                    if (leagueType != LeagueType.OHL && leagueType != LeagueType.WHL)
                    {
                        continue;
                    }

                    worker.ReportProgress((int)((decimal)leagueCounter / (decimal)leagues * 100), leagueType.ToString());
                    leagueCounter++;
                    var parser = WebParserFactory.GetScheduleParser(leagueType);
                    if (!Games.ContainsKey(leagueType.ToString()))
                    {
                        Games.Add(leagueType.ToString(), parser.GetGames(gameday));
                    }
                    else
                    {
                        Games[leagueType.ToString()] = parser.GetGames(gameday);
                    }
                    List<Team> teams;

                    if (!Teams.ContainsKey(parser.LeagueCode))
                    {
                        teams = WebParserFactory.GetStandingsParser(leagueType).GetStandings();
                        Teams.Add(parser.LeagueCode, teams);
                    }
                    worker.ReportProgress((int)((decimal)leagueCounter / (decimal)leagues * 100), leagueType.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to load " + leagueType.ToString() + "." + Environment.NewLine + "Error Text(Show this to Aaron:" + Environment.NewLine + ex.ToString());
                }
            }

        }

        private void LoadLeaguesBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var league = e.UserState.ToString();

            progressForm.ProgressValue = e.ProgressPercentage;
            progressForm.CurrentLeague = league;

            //load the data into the displays
            if (Games.ContainsKey(league))
            {
                Leagues[league].LoadData(Games[league], Teams[league]);
            }
        }

        private void LoadLeaguesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressForm.Close();
            FilterData();
        }

        #endregion
    }
}
