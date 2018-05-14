using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;
using Newtonsoft.Json.Linq;
using MatchupLib.WebParser.Standings.LeagueStandings;
using MatchupLib.WebParser.Standings;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{
    class AHLScheduleParser : ScheduleParser
    {
        private readonly string[] nextYearMonths = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
        private readonly string[] prevYearMonths = new string[] { "Oct", "Nov", "Dec" };
        private const string LeagueStatScheduleLink = "http://lscluster.hockeytech.com/feed/index.php?feed=statviewfeed&view=schedule&team=-1&season=54&month=-1&location=homeaway&key=50c2cd9b5e18e390&client_code=ahl&site_id=1&league_id=4";

        public override string LeagueCode
        {
            get
            {
                return "AHL";
            }
        }

        protected override List<Game> GetAllGames()
        {
            var allGames = new List<Game>();
            var jsonString = GetHtml(LeagueStatScheduleLink);

            //clean up, this json has a ([ and ]) in the beginning and end respectively
            jsonString = jsonString.Substring(2);
            jsonString = jsonString.Substring(0, jsonString.Length - 2);

            JObject json = JObject.Parse(jsonString);
            var data = json["sections"][0]["data"];

            //this is to make it faster to find teams, as the team name in schedule and dates don't actually match up
            var teamsDictionary = new Dictionary<string, Team>();

            foreach (var d in data)
            {
                //since the season straddles two years we have to add years to some of the months
                var gameday = d.SelectTokens("row").ToList()[0]["date_with_day"].Value<string>();
                var gametime = d.SelectTokens("row").ToList()[0]["game_status"].Value<string>();

                if (DateTime.Today.Month <= 6)
                {
                    if (prevYearMonths.Any(n => gameday.Contains(n)))
                    {
                        var nextYear = DateTime.Today.Year - 1;
                        gameday += " " + nextYear;
                    }
                }
                else
                {
                    if (nextYearMonths.Any(n => gameday.Contains(n)))
                    {
                        var nextYear = DateTime.Today.Year + 1;
                        gameday += " " + nextYear;
                    }
                }

                var game = new Game()
                {
                    Date = DateTime.Parse(gameday),
                    AwayTeam = GetTeam(d.SelectTokens("row").ToList()[0]["visiting_team_city"].Value<string>()),
                    HomeTeam = GetTeam(d.SelectTokens("row").ToList()[0]["home_team_city"].Value<string>())
                };

                allGames.Add(game);
            }

            return allGames;
        }

        protected override void AddNotExactTeams(List<Team> teams, Dictionary<string, Team> teamsDictionary)
        { 
            teamsDictionary.Add("W-B/Scranton", teams.Where(t => t.Name.Equals("Wilkes-Barre/Scranton Penguins")).FirstOrDefault());
            base.AddNotExactTeams(teams, teamsDictionary);
        }

        protected override StandingsParser GetStandingsParser()
        {
            return new AHLStandingsParser();
        }
    }
}
