using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;
using MatchupLib.WebParser.Standings;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{
    class EHLScheduleParser : ScheduleParser
    {
        private const string ScheduleLink = "http://www.erstebankliga.at/ebel-en/schedule-results";

        public override string LeagueCode
        {
            get
            {
                throw new NotImplementedException();
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
