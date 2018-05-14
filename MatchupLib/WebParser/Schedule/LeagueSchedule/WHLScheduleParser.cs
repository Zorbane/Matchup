using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;
using MatchupLib.WebParser.Standings;
using MatchupLib.WebParser.Standings.LeagueStandings;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{
    class WHLScheduleParser : CHLScheduleParser
    {
        public override string LeagueCode
        {
            get
            {
                return "WHL";
            }
        }

        protected override string LeagueStatLink
        {
            get
            {
                return "http://cluster.leaguestat.com/feed/?feed=modulekit&view=schedule&key=c680916776709578&fmt=json&client_code=whl&lang=en&season_id=257&team_id=undefined&league_code=&fmt=json";
            }
        }

        protected override StandingsParser GetStandingsParser()
        {
            return new WHLStandingsParser();
        }
    }
}
