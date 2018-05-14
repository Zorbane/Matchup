using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;

namespace MatchupLib.WebParser.Standings.LeagueStandings
{
    class LiigaStandingsParser : StandingsParser
    {
        private const string StandingsLink = "http://liiga.fi/sarjataulukko";

        public override List<Team> GetStandings()
        {
            throw new NotImplementedException();
        }
    }
}
