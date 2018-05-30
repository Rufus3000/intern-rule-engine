using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine.Model
{
    class RankingSystem
    {
        public static void Ranking(List<Team> teams)
        {
            int counter = 1;
            foreach (Team t in teams.OrderBy(x => x.Position))
            {
                if ((double)t.Points%(double)counter != 0)
                {
                    t.Rank = t.Position;
                    counter++;
                }
                else
                {
                    t.Rank = counter;
                    counter++;
                }
            }
        }
    }
}
