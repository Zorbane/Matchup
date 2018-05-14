using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchupLib.WebParser.Standings.LeagueStandings
{
    class AllsvenskanStandingsParser : SwedenStandingsParser
    {
        public AllsvenskanStandingsParser() : base("http://stats.swehockey.se/ScheduleAndResults/Standings/7157")
        {
        }
    }
}
