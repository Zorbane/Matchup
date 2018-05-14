using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchupLib.Models
{
    public class Game
    {
        public DateTime Date { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public override string ToString()
        {
            return AwayTeam.Name + "(" + AwayTeam.Rank + ")" + " @ " + HomeTeam + "(" + HomeTeam.Rank + ")" + " " + Date.ToShortDateString();
        }
    }
}
