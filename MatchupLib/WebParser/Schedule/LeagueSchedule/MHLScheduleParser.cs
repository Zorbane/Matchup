using MatchupLib.Models;
using MatchupLib.WebParser.Standings.LeagueStandings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.WebParser.Standings;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{


    class MHLScheduleParser : ScheduleParser
    {
        private const string MHLScheduleLink = "http://engmhl.khl.ru/calendar/423/0/0/";

        public override string LeagueCode
        {
            get
            {
                return "MHL";
            }
        }

        protected override StandingsParser GetStandingsParser()
        {
            return new MHLStandingsParser();
        }

        protected override void AddNotExactTeams(List<Team> teams, Dictionary<string, Team> teamsDictionary)
        {
            teamsDictionary.Add("Altai U-K", teams.Where(t => t.Name.Contains("Altai")).FirstOrDefault());
            teamsDictionary.Add("Sputnik Al", teams.Where(t => t.Name.Contains("Sputnik")).FirstOrDefault());
            teamsDictionary.Add("HC Riga", teams.Where(t => t.Name.Contains("HK Riga")).FirstOrDefault());
            base.AddNotExactTeams(teams, teamsDictionary);
        }

        protected override List<Game> GetAllGames()
        {
            var doc = GetHtmlDocument(MHLScheduleLink);
            var rootNode = doc.DocumentNode;
            var allGames = new List<Game>();

            var calendarItemsNodes = GetNodesFromClasses(rootNode, "b_calendar_items_group");
            


            //there should be 3, now future and past, same structure
            foreach (var calendarItem in calendarItemsNodes)
            {
                //get each day
                var calendarDayItemsNodes = GetNodesFromClasses(calendarItem, "calendar_dayitems");

                //it might be null if there are no current, past or future games
                if (calendarDayItemsNodes != null)
                {
                    foreach (var calendarDayItemNode in calendarDayItemsNodes)
                    {
                        //get the date
                        var dateString = GetNodeFromClasses(GetNodeFromClasses(calendarDayItemNode, "b_calendar_items_day"), "b_calendar_items_day_date ib").InnerText;
                        var date = DateTime.Parse(dateString.Substring(0, dateString.IndexOf(',')));
                        var gameNodes = GetNodeFromClasses(calendarDayItemNode, "row").SelectNodes("div");

                        foreach (var gameNode in gameNodes)
                        {
                            //get both teams, first is away second is home
                            var teamsNodes = GetNodesFromClasses(gameNode, "b_calendar_item_team_name");
                            var away = teamsNodes[0].InnerText.Trim();
                            var home = teamsNodes[1].InnerText.Trim();

                            var game = new Game()
                            {
                                Date = date,
                                AwayTeam = GetTeam(away),
                                HomeTeam = GetTeam(home)
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
