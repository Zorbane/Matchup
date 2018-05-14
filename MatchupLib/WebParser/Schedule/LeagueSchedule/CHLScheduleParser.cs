using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;
using Newtonsoft.Json.Linq;

namespace MatchupLib.WebParser.Schedule.LeagueSchedule
{
    abstract class CHLScheduleParser : ScheduleParser
    {
        protected abstract string LeagueStatLink { get; }

        protected override List<Game> GetAllGames()
        {
            var allGames = new List<Game>();
            var jsonString = GetHtml(LeagueStatLink);
            var json = JObject.Parse(jsonString);
            var schedule = json["SiteKit"]["Schedule"];

            foreach(var jgame in schedule)
            {
                var dateString = jgame["GameDateISO8601"].Value<string>();
                var month = int.Parse(dateString.Substring(0,2));
                var day = int.Parse(dateString.Substring(3, 2));
                var year = int.Parse(dateString.Substring(6, 4));
                // DateTime.ParseExact(dateString, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                var date = new DateTime(year, month, day);
                var visitor = jgame["visiting_team_name"].Value<string>();
                var home = jgame["home_team_name"].Value<string>();

                var game = new Game()
                {
                     Date = date,
                     AwayTeam  = GetTeam(visitor),
                     HomeTeam = GetTeam(home)                     
                };

                allGames.Add(game);
            }

            return allGames;
        }
    }
}
