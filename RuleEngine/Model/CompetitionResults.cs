using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine.Model
{
    class CompetitionResults
    {
        public static List<Team> Results(List<Race> races)
        {
            Dictionary<string, double> ResultPoints = new Dictionary<string, double>();
            foreach(Race r in races)
            {
                foreach(Team t in r.Teams)
                {
                    if(ResultPoints.ContainsKey(t.Name))
                    {
                        ResultPoints[t.Name] += t.Points;
                    }
                    else
                    {
                        ResultPoints.Add(t.Name, t.Points);
                    }
                }
            }
            List<Team> fTeams = races[0].Teams;
            foreach(Team t in fTeams)
            {
                t.Points = ResultPoints[t.Name];
            }
            return fTeams.OrderBy(x => x.Points).ToList();
        }
    }
}
