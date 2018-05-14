using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.WebParser.Standings;
using MatchupLib.WebParser.Standings.LeagueStandings;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{
    class SHLScheduleParser : SwedenScheduleParser
    {
        public override string LeagueCode
        {
            get
            {
                return "SHL";
            }
        }

        public SHLScheduleParser() : base("http://stats.swehockey.se/ScheduleAndResults/Schedule/7132")
        {
        }

        protected override StandingsParser GetStandingsParser()
        {
            return new SHLStandingsParser();
        }
    }
}
