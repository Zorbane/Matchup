using MatchupLib.Models;
using MatchupLib.WebParser.Schedule;
using MatchupLib.WebParser.Schedule.LeagueSchedule;
using MatchupLib.WebParser.Standings;
using MatchupLib.WebParser.Standings.LeagueStandings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchupLib.WebParser
{
    public static class WebParserFactory
    {
        public static ScheduleParser GetScheduleParser(LeagueType league)
        {
            switch (league)
            {
                case LeagueType.AHL:
                    return new AHLScheduleParser();
                case LeagueType.VHL:
                    return new VHLScheduleParser();
                case LeagueType.MHL:
                    return new MHLScheduleParser();
                case LeagueType.WHL:
                    return new WHLScheduleParser();
                case LeagueType.OHL:
                    return new OHLScheduleParser();
                case LeagueType.QMJHL:
                    return new QMJHLScheduleParser();
                case LeagueType.SHL:
                    return new SHLScheduleParser();
                case LeagueType.Allsvenskan:
                    return new AllsvenskanScheduleParser();
                default:
                    throw new Exception("No Schedule Parser for " + league.ToString());
            }
        }

        public static StandingsParser GetStandingsParser(LeagueType league)
        {
            switch (league)
            {
                case LeagueType.AHL:
                    return new AHLStandingsParser();
                case LeagueType.VHL:
                    return new VHLStandingsParser();
                case LeagueType.MHL:
                    return new MHLStandingsParser();
                case LeagueType.WHL:
                    return new WHLStandingsParser();
                case LeagueType.OHL:
                    return new OHLStandingsParser();
                case LeagueType.QMJHL:
                    return new QMJHLStandingsParser();
                case LeagueType.SHL:
                    return new SHLStandingsParser();
                case LeagueType.Allsvenskan:
                    return new AllsvenskanStandingsParser();
                default:
                    throw new Exception("No Standing Parser for " + league.ToString());
            }        
        }
    }
}
