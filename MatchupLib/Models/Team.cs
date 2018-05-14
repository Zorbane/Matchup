using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchupLib.Models
{
    public class Team : IComparable
    {
        public const string Last10Format = "W-L-OTL-SOL";

        public string Name { get; set; }
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int OvertimeLosses { get; set; }
        public int ShootoutLosses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }
        public int Last10Wins { get; set; }
        public int Last10Losses { get; set; }
        public int Last10OTLosses { get; set; }
        public int Last10SOLosses { get; set; }

        private string streak;
        public string Streak
        {
            get
            {
                if (string.IsNullOrWhiteSpace(streak))
                {
                    return "NA";
                }
                return streak;
            }
            set
            {
                streak = value;
            }
        }

        public int GamesPlayed
        {
            get
            {
                return Wins + Losses + OvertimeLosses + ShootoutLosses;
            }
        }

        public decimal WinPercentage
        {
            get
            {
                return (Wins / (decimal)(GamesPlayed)) * 100;
            }
        }

        public string Last10Games
        {
            get
            {
                if ((Last10Wins == 0) && (Last10Wins == 0) && (Last10Wins == 0) && (Last10Wins == 0))
                {
                    return "NA";
                }                        
                return Last10Wins + "-" + Last10Losses + "-" + Last10OTLosses + "-" + Last10SOLosses;
            }
        }    

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            return Name.CompareTo(((Team)obj).Name);
        }
    }
}
