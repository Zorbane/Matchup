using MatchupLib.WebParser.Standings;
using MatchupLib.WebParser.Standings.LeagueStandings;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{
    class AllsvenskanScheduleParser : SwedenScheduleParser
    {
        public override string LeagueCode
        {
            get
            {
                return "Allsvenskan";
            }
        }

        public AllsvenskanScheduleParser() : base("http://stats.swehockey.se/ScheduleAndResults/Schedule/7157")
        {
        }

        protected override StandingsParser GetStandingsParser()
        {
            return new AllsvenskanStandingsParser();
        }
    }
}
