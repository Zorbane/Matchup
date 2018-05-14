using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;
using MatchupLib.WebParser.Standings;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{
    class LiigaScheduleParser : ScheduleParser
    {
        private const string LiigaScheduleLink = "http://liiga.fi/ottelut/2016-2017/runkosarja/";

        public override string LeagueCode
        {
            get
            {
                return "Liiga";
            }
        }

        protected override List<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        protected override StandingsParser GetStandingsParser()
        {
            throw new NotImplementedException();
        }
    }
}
