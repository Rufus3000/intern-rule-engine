using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Model
{
    class Race
    {
        public List<Team> Teams = new List<Team>();


        public List<Team> GetCopy()
        {
            List<Team> team = new List<Team>(Teams.Count);
            foreach(Team t in Teams)
            {
                team.Add(t);
            }
            return team;
        }
    }
}
