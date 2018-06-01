using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine.Model
{
    class CompetitionTeamResults
    {
        public string Name;
        private List<Team> teams;

        public CompetitionTeamResults(string name)
        {
            Name = name;
            teams = new List<Team>();
        }
        public static List<CompetitionTeamResults> GetResults(List<Race> races)
        {
            List<CompetitionTeamResults> teamsResults = new List<CompetitionTeamResults>();

            foreach (Team t in races[0].GetCopy())
            {
                CompetitionTeamResults competitionTeam = new CompetitionTeamResults(t.Name);
                competitionTeam.teams.Add(t);
                teamsResults.Add(competitionTeam);
            }
            for (int i = 1; i < races.Count; ++i)
            {
                List<Team> teams = races[i].GetCopy();

                for (int c0 = 0; c0 < teams.Count; c0++)
                {
                    for (int c1 = 0; c1 < teamsResults.Count; ++c1)
                    {
                        if (teamsResults[c1].Name == teams[c0].Name)
                        {
                            teamsResults[c1].teams.Add(teams[c0]);
                            break;
                        }
                    }
                }

            }
            return teamsResults;
        }
        public double GetPoints()
        {
            return teams.Select(x => x.Points).Sum();
        }
        public void GetDiscard(int amountOfDiscarded)
        {
            for (int i = 0; i < amountOfDiscarded; ++i)
            {
                Team discardedTeam;
                int worstRank = teams.Where(c => !c.Discarded).Select(c => c.Rank).Max();
                discardedTeam = teams.Where(c => !c.Discarded).Select(c => c).Where(c => c.Rank == worstRank).First();
                discardedTeam.Discarded = true;
            }
        }
        public override string ToString()
        {
            string discarded = "";
            foreach (Team t in teams)
            {
                if (t.Discarded)
                {
                    discarded += t.Points + ", ";
                }

            }
            return String.Format("{0} ended up with: {1}, discarded races:{2}", Name, GetPoints(), discarded);
        }
    }
}
