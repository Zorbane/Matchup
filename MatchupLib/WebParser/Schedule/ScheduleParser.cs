using MatchupLib.Models;
using MatchupLib.WebParser.Standings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchupLib.WebParser.Schedule
{
    public abstract class ScheduleParser : WebParser
    {
        public abstract string LeagueCode { get; }

        protected static Dictionary<string, List<Game>> AllGames = new Dictionary<string, List<Game>>();
        protected static Dictionary<string, List<Team>> AllTeams = new Dictionary<string, List<Team>>();
        protected static Dictionary<string, Dictionary<string, Team>> TeamsDictionary = new Dictionary<string, Dictionary<string, Team>>();

        public List<Game> GetGames(DateTime date)
        {
            List<Game> allGames = null;

            if (AllGames.ContainsKey(LeagueCode))
            {
                allGames = AllGames[LeagueCode];
            }

            if (allGames == null || allGames.Count == 0)
            {
                allGames = GetAllGames();
                AllGames[LeagueCode] = allGames;
            }

            return allGames.Where(g => g.Date.Date.Equals(date.Date)).ToList();
        }

        protected Team GetTeam(string teamName)
        {
            if (!TeamsDictionary.ContainsKey(LeagueCode))
            {
                TeamsDictionary.Add(LeagueCode, new Dictionary<string, Team>());
            }

            if (!AllTeams.ContainsKey(LeagueCode))
            {
                AllTeams.Add(LeagueCode, GetStandingsParser().GetStandings());
                AddNotExactTeams(AllTeams[LeagueCode], TeamsDictionary[LeagueCode]);
            }

            Team team;
            var teams = AllTeams[LeagueCode];
            var teamsDictionary = TeamsDictionary[LeagueCode];
            
            if (teamsDictionary.ContainsKey(teamName))
            {
                team = teamsDictionary[teamName];
            }
            else
            {
                team = teams.Where(t => t.Name.Contains(teamName)).FirstOrDefault();

                if (team == null)
                {
                    throw new NullReferenceException("Unable to find team for " + teamName);
                }

                teamsDictionary.Add(teamName, team);
            }

            return team;
        }

        protected virtual void AddNotExactTeams(List<Team> teams, Dictionary<string, Team> teamsDictionary)
        {

        }

        protected abstract List<Game> GetAllGames();

        protected abstract StandingsParser GetStandingsParser();
    }
}
