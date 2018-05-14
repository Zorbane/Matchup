using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;

namespace MatchupLib.WebParser.Standings.LeagueStandings
{
    class EHLStandingsParser : StandingsParser
    {
        private const string StandingsLink = "http://www.erstebankliga.at/ebel-en/standings";

        public override List<Team> GetStandings()
        {
            throw new NotImplementedException();
        }
    }
}
