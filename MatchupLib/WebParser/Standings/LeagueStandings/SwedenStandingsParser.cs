using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;

namespace MatchupLib.WebParser.Standings.LeagueStandings
{
    class SwedenStandingsParser : StandingsParser
    {
        private string link;

        public SwedenStandingsParser(string standingsLink)
        {
            link = standingsLink;
        }

        public override List<Team> GetStandings()
        {
            var teams = new List<Team>();
            var doc = GetHtmlDocument(link);
            var rootNode = doc.DocumentNode;
            var tables = GetNodesFromClasses(rootNode, "tblBorderNoPad");

            //there are 3 but we only want the first one
            var tableBorder = tables[0];
            var table = GetNodeFromClasses(tableBorder,"tblContent");
            //now get the data
            var trs = table.SelectNodes("tr");

            //skip the first two because it is the two headers
            for (int i = 2; i < trs.Count; i++)
            {
                var data = trs[i].SelectNodes("td");
                if (!data[0].InnerHtml.Contains("hr"))
                {
                    var otWins = int.Parse(data[8].InnerText);
                    var soWins = int.Parse(data[10].InnerText);
                    var otLosses = int.Parse(data[9].InnerText);
                    var soLosses = int.Parse(data[11].InnerText);
                    var goalData = data[6].InnerText.Trim();
                    var goalsFor = int.Parse(goalData.Split(':')[0]);
                    var goalsAgainst = int.Parse(goalData.Split(':')[1].Substring(0, 2).Trim());

                    var team = new Team()
                    {
                        Rank = int.Parse(data[0].InnerText),
                        Name = data[1].InnerText.Trim(),
                        Wins = int.Parse(data[3].InnerText) + otWins + soWins,
                        Losses = int.Parse(data[5].InnerText),
                        ShootoutLosses = soLosses,
                        OvertimeLosses = otLosses,
                        Points = int.Parse(data[7].InnerText),
                        GoalsAgainst = goalsAgainst,
                        GoalsFor = goalsFor,
                    };

                    teams.Add(team);
                }
            }           


            return teams;
        }
    }
}
