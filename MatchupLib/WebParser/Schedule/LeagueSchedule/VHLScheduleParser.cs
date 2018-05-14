using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;
using MatchupLib.WebParser.Standings.LeagueStandings;
using HtmlAgilityPack;
using MatchupLib.WebParser.Standings;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{
    class VHLScheduleParser : ScheduleParser
    {
        private const string VHLScheduleLink = "http://www.vhlru.ru/en/calendar/425/0/";

        public override string LeagueCode
        {
            get
            {
                return "VHL";
            }
        }

        protected override StandingsParser GetStandingsParser()
        {
            return new VHLStandingsParser();
        }

        protected override List<Game> GetAllGames()
        {
            var doc = GetHtmlDocument(VHLScheduleLink);
            var rootNode = doc.DocumentNode;
            var matcheslists = GetNodesFromClasses(rootNode, "uni_table matches");
            var allGames = new List<Game>();
            
            //this will return two, the first one is the completed games, the second one the future games.  both have the same formatting
            foreach (HtmlNode matchesListNode in matcheslists)
            {
                var dataNodes = matchesListNode.SelectNodes("tr");
                foreach(var dataNode in dataNodes)
                {
                    //check if its the header
                    if (dataNode.SelectSingleNode("th") == null)
                    {

                        //date
                        var dateString = GetNodeFromClasses(dataNode, "date").SelectSingleNode("h4").InnerText;
                        var date = DateTime.ParseExact(dateString, "dd.MM.yy", System.Globalization.CultureInfo.InvariantCulture);

                        //games
                        var gamesNodes = GetNodeFromClasses(dataNode, "number").SelectSingleNode("table").SelectNodes("tr");
                        foreach (var gameNode in gamesNodes)
                        {
                            var teams = GetNodeFromClasses(gameNode, "col_team").SelectNodes("a");
                            var visitor = teams[0].InnerText;
                            var home = teams[1].InnerText;

                            Game game = new Game()
                            {
                                Date = date,
                                AwayTeam = GetTeam(visitor),
                                HomeTeam = GetTeam(home),
                            };
                            allGames.Add(game);                        
                        }                        
                    }
                }
            }

            return allGames;

        }
    }
}
