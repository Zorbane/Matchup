using MatchupLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchupWindows.ViewModels
{
    class Matchup
    {
        public Team AwayTeam { get; private set; }
        public Team HomeTeam { get; private set; }
        

        public int AwayTeamStanding
        {
            get
            {
                return AwayTeam.Rank;
            }
        }
        public int HomeTeamStanding
        {
            get
            {
                return HomeTeam.Rank;
            }
        }
        public decimal AwayTeamWinPercentage
        {
            get
            {
                return AwayTeam.WinPercentage;
            }
        }
        public decimal HomeTeamWinPercentage
        {
            get
            {
                return HomeTeam.WinPercentage;
            }
        }
        public int StandingDifference
        {
            get
            {
                return Math.Max(HomeTeamStanding, AwayTeamStanding) - Math.Min(HomeTeamStanding, AwayTeamStanding);
            }
        }
        public decimal WinPercentageDifference
        {
            get
            {
                return Math.Max(HomeTeamWinPercentage, AwayTeamWinPercentage) - Math.Min(HomeTeamWinPercentage, AwayTeamWinPercentage);
            }
        }

        public Matchup(Game game)
        {
            AwayTeam = game.AwayTeam;
            HomeTeam = game.HomeTeam;
        }
    }
}
