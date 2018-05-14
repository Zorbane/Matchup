using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;

namespace MatchupLib.WebParser.Standings.LeagueStandings
{
    class MHLStandingsParser : StandingsParser
    {
        private const string MHLStandingsLink = "http://engmhl.khl.ru/standings/472232/regular/423/league/";

        public override List<Team> GetStandings()
        {
            var teams = new List<Team>();
            var doc = GetHtmlDocument(MHLStandingsLink);
            var rootNode = doc.DocumentNode;
            var standingWrapperNode = GetNodeFromClasses(rootNode, "standing_wrapper");
            var sitetableNode = GetNodeFromClasses(standingWrapperNode, "site_table");
            var rowNodes = sitetableNode.SelectNodes("tr");
            
            foreach(var rowNode in rowNodes)
            {
                //if it contains "th" ignore, that is the header
                if (rowNode.SelectSingleNode("th") == null)
                {
                    var dataNodes = rowNode.SelectNodes("td");
                    var goals = dataNodes[10].InnerText;
                    var goalsFor = int.Parse(goals.Substring(0, goals.IndexOf('-')));
                    var goalsAgainst = int.Parse(goals.Substring(goals.IndexOf('-') + 1));


                    var team = new Team()
                    {
                        Rank = int.Parse(dataNodes[0].InnerText),
                        Name = dataNodes[2].InnerText.Trim(),
                        Wins = int.Parse(dataNodes[4].InnerText) + int.Parse(dataNodes[5].InnerText) + int.Parse(dataNodes[6].InnerText),
                        Losses = int.Parse(dataNodes[9].InnerText),
                        OvertimeLosses = int.Parse(dataNodes[8].InnerText),
                        ShootoutLosses = int.Parse(dataNodes[7].InnerText),
                        GoalsFor = goalsFor,
                        GoalsAgainst = goalsAgainst,
                        Points = int.Parse(dataNodes[11].InnerText),
                    };

                    teams.Add(team);
                }
            }

            return teams;

        }
    }
}
