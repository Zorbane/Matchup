using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;

namespace MatchupLib.WebParser.Standings.LeagueStandings
{
    class QMJHLStandingsParser : CHLStandingsParser
    {
        protected override string LeagueStatLink
        {
            get
            {
                return "http://cluster.leaguestat.com/feed/?feed=modulekit&view=statviewtype&type=standings&key=c680916776709578&fmt=json&client_code=lhjmq&lang=en&season_id=184&stat=overall&fmt=json";
            }
        }
    }
}
