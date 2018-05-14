using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;
using MatchupLib.WebParser.Standings;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{
    abstract class SwedenScheduleParser : ScheduleParser
    {
        private string link;

        public SwedenScheduleParser(string scheduleLink)
        {
            link = scheduleLink;
        }

        protected override List<Game> GetAllGames()
        {
            var games = new List<Game>();
            var doc = GetHtmlDocument(link);
            var rootNode = doc.DocumentNode;
            var table = GetNodeFromClasses(rootNode, "tblContent");
            var trs = table.SelectNodes("tr");

            //skip first two because of headers
            for (int i = 2; i < trs.Count; i++)
            {                
                var data = trs[i].SelectNodes("td");
                var dateString = data[1].InnerText;
                var teams = data[2].InnerText;

                var date = DateTime.Parse(dateString);
                var homeTeam = teams.Split('-')[0].Trim();
                var awayTeam = teams.Split('-')[1].Trim();


                var game = new Game()
                {
                    Date = date,
                    HomeTeam = GetTeam(homeTeam),
                    AwayTeam = GetTeam(awayTeam),
                };

                games.Add(game);
            }



            return games;
        }
    }
}
