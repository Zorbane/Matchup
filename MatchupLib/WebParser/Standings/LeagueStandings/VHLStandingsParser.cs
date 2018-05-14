using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;

namespace MatchupLib.WebParser.Standings.LeagueStandings
{
    class VHLStandingsParser : StandingsParser
    {
        private const string VhlStandingsLink =  "http://www.vhlru.ru/en/standings/regular/";

        public override List<Team> GetStandings()
        {
            var teams = new List<Team>();
            var doc = GetHtmlDocument(VhlStandingsLink);
            var rootNode = doc.DocumentNode;
            var conference_table = GetNodeFromClasses(rootNode, "conference_table");
            var row = conference_table.SelectSingleNode("table").SelectNodes("tr");

            foreach (var rowNode in row)
            {
                var dataNodes = rowNode.SelectNodes("td");

                var goalsInfo = dataNodes[9].InnerText.Split('-');

                var team = new Team()
                {
                    Rank = int.Parse(dataNodes[0].InnerText),
                    Name = dataNodes[1].InnerText.Trim(),
                    Wins = int.Parse(dataNodes[3].InnerText) + int.Parse(dataNodes[4].InnerText) + int.Parse(dataNodes[5].InnerText),
                    Losses = int.Parse(dataNodes[8].InnerText),
                    OvertimeLosses = int.Parse(dataNodes[7].InnerText),
                    ShootoutLosses = int.Parse(dataNodes[6].InnerText),
                    GoalsFor = int.Parse(goalsInfo[0]),
                    GoalsAgainst = int.Parse(goalsInfo[1]),
                    Points = int.Parse(dataNodes[10].InnerText),
                };

                teams.Add(team);
            }

            return teams;
            
        }
    }
}
