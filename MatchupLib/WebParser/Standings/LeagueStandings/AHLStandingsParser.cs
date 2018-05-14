using HtmlAgilityPack;
using MatchupLib.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatchupLib.WebParser.Standings.LeagueStandings
{
    class AHLStandingsParser : StandingsParser
    {
        private const string RankNodeClass = "rank";
        private const string NameNodeClass = "name";
        private const string WinsNodeClass = "wins";
        private const string LossesNodeClass = "losses";
        private const string OTLNodeClass = "ot_losses";
        private const string SOLossNodeClass = "shooutout_losses";
        private const string GFNodeClass = "goals_for";
        private const string GANodeClass = "goals_against";


        public override List<Team> GetStandings()
        {
            var teams = new List<Team>();
            var jsonString = GetHtml(GetStandingsLink());

            // league stat json
            //clean up, this json has a ([ and ]) in the beginning and end respectively
            jsonString = jsonString.Substring(2);
            jsonString = jsonString.Substring(0, jsonString.Length - 2);

            JObject json = JObject.Parse(jsonString);
            var data = json["sections"][0]["data"];

            foreach (var d in data)
            {
                var past10string = d.SelectTokens("row").ToList()[0]["past_10"].Value<string>();
                var past10stats = past10string.Split('-');

                var t = new Team()
                {
                    Rank = d.SelectTokens("row").ToList()[0]["rank"].Value<int>(),
                    Name = d.SelectTokens("row").ToList()[0]["name"].Value<string>(),
                    Wins = d.SelectTokens("row").ToList()[0]["wins"].Value<int>(),
                    Losses = d.SelectTokens("row").ToList()[0]["losses"].Value<int>(),
                    OvertimeLosses = d.SelectTokens("row").ToList()[0]["ot_losses"].Value<int>(),
                    ShootoutLosses = d.SelectTokens("row").ToList()[0]["shootout_losses"].Value<int>(),
                    Points = d.SelectTokens("row").ToList()[0]["points"].Value<int>(),
                    GoalsFor = d.SelectTokens("row").ToList()[0]["goals_for"].Value<int>(),
                    GoalsAgainst = d.SelectTokens("row").ToList()[0]["goals_against"].Value<int>(),
                    Streak = d.SelectTokens("row").ToList()[0]["streak"].Value<string>(),      
                    Last10Wins = int.Parse(past10stats[0]),
                    Last10Losses = int.Parse(past10stats[1]),
                    Last10OTLosses = int.Parse(past10stats[2]),
                    Last10SOLosses = int.Parse(past10stats[3]),
                };

                teams.Add(t);
            }


            #region leaguestat media page
            /*
            var doc = GetHtmlDocument(GetStandingsLink());
            var rootDataNode = doc.DocumentNode.SelectSingleNode("//table[contains(concat(\" \", normalize-space(@class), \" \"), \"data\")]");
            var teamNodes = rootDataNode.SelectNodes("tr");
            now the first one is the header so skip that
            for (int teamIndex = 1; teamIndex <= 30; teamIndex++)
            {
                var teamNode = teamNodes[teamIndex];
                var dataNodes = teamNode.SelectNodes("td");

                var team = new Team()
                {
                    Rank = int.Parse(dataNodes[0].InnerText),
                    Name = dataNodes[2].InnerText.Trim(),
                    Wins = int.Parse(dataNodes[4].InnerText),
                    Losses = int.Parse(dataNodes[5].InnerText),
                    OvertimeLosses = int.Parse(dataNodes[6].InnerText),
                    ShootoutLosses = int.Parse(dataNodes[7].InnerText),
                    GoalsFor = int.Parse(dataNodes[8].InnerText),
                    GoalsAgainst = int.Parse(dataNodes[9].InnerText),
                    Points = int.Parse(dataNodes[10].InnerText),
                };

                teams.Add(team);

            }
            */

            #endregion

            #region Sportsnet
            /*
            get the table with the standings
            var divisions = doc.DocumentNode.SelectNodes("//table[contains(concat(\" \", normalize-space(@class), \" \"), \"data-table full-width align-center no-wrap\")]");

            therea re 4 divisions, so go through teh first 4, the 5th one is LEGEND

            for (int divisionIndex = 0; divisionIndex < 4; divisionIndex++)
            {
                var divisionTableNode = divisions[divisionIndex];
                var teamNodes = divisionTableNode.SelectNodes("tbody/tr");
                foreach (HtmlNode teamNode in teamNodes)
                {
                    var dataPoints = teamNode.SelectNodes("td");
                    var team = new Team()
                    {
                        Name = dataPoints[1].InnerText.Trim(),
                        Wins = int.Parse(dataPoints[3].InnerText),
                        Losses = int.Parse(dataPoints[4].InnerText),
                        OvertimeLosses = int.Parse(dataPoints[5].InnerText) + int.Parse(dataPoints[6].InnerText),
                        Points = int.Parse(dataPoints[7].InnerText),
                        GoalsFor = int.Parse(dataPoints[8].InnerText),
                        GoalsAgainst = int.Parse(dataPoints[9].InnerText)
                    };
                    teams.Add(team);
                }


            }


            now sort them by winning percentage and set their ransk
            teams = teams.OrderByDescending(t => t.Points).ToList();

            for (int rank = 1; rank <= teams.Count; rank++)
            {
                teams[rank-1].Rank = rank;
            } */
            #endregion

            return teams;
        }


        private string GetStandingsLink()
        {

            //nvm ahl don't work
            //2016-2017 is year 54, so need to adjust it according to the current date, but hard code for now
            //return "http://theahl.com/team-stats?standingsType=league&context=overall&specialTeams=false&season=54&sortKey=percentage&league=4&league_code=ahl";

            //sportsnet
            //return "http://www.sportsnet.ca/hockey/ahl/standings/";

            //leageustat media page
            //return "http://www.leaguestat.com/ahl/ahl/en/media/?step=4&sub=0";

            //league stat json
            return "http://lscluster.hockeytech.com/feed/index.php?feed=statviewfeed&view=teams&groupTeamsBy=league&context=overall&site_id=1&season=54&special=false&key=50c2cd9b5e18e390&client_code=ahl&league_id=4&division=undefined&sort=percentage";
        }
    }
}
