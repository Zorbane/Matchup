using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchupLib.Models;
using Newtonsoft.Json.Linq;

namespace MatchupLib.WebParser.Standings.LeagueStandings
{
    abstract class CHLStandingsParser : StandingsParser
    {
        protected abstract string LeagueStatLink { get;}

        public override List<Team> GetStandings()
        {
            var teams = new List<Team>();
            var jsonString = GetHtml(LeagueStatLink);
            var json = JObject.Parse(jsonString);
            var statview = json["SiteKit"]["Statviewtype"]; //this has all the data

            foreach(var jteam in statview.Children())
            {
                //first check if it is the header, we don't want to do that
                if (jteam["repeatheader"] == null)
                {
                    var team = new Team()
                    {
                        Name = jteam["name"].Value<string>(),
                        Rank = jteam["rank"].Value<int>(),
                        Wins = jteam["wins"].Value<int>(),
                        Losses = jteam["losses"].Value<int>(),
                        OvertimeLosses = jteam["ot_losses"].Value<int>(),
                        ShootoutLosses = jteam["shootout_losses"].Value<int>(),
                        GoalsFor = jteam["goals_for"].Value<int>(),
                        GoalsAgainst = jteam["goals_against"].Value<int>(),
                        Points = jteam["points"].Value<int>(),
                        Last10Wins = jteam["past_10_wins"].Value<int>(),
                        Last10Losses = jteam["past_10_losses"].Value<int>(),
                        Last10SOLosses = jteam["past_10_ot_losses"].Value<int>(),
                        Last10OTLosses = jteam["past_10_shootout_losses"].Value<int>(),
                        Streak = jteam["streak"].Value<string>(),                        
                    };

                    teams.Add(team);
                }
            }


            return teams;
        }
    }
}
