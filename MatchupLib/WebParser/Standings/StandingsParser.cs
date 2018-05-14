using MatchupLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchupLib.WebParser.Standings
{
    public abstract class StandingsParser : WebParser
    {
        public abstract List<Team> GetStandings();
    }
}
