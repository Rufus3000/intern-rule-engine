using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine.Model
{
    class PointingSystem
    {
        public static void Pointing(List<Team> teams)
        {
            int rank = 1;
            double buffer = 0;
            teams.OrderBy(x => x.Position);
            var duplicated = teams.GroupBy(g => g.Position).Where(x => x.Count() > 0).ToDictionary(x => x.Key, y => y.Count());
            foreach (KeyValuePair<int, int> i in duplicated)
            {
                if (!(i.Value > 1))
                {
                    teams[rank - 1].Points = rank;
                    //output.Add(rank);
                    rank++;
                }
                else
                {
                    buffer = (double)(rank * i.Value + i.Value - 1) / i.Value;
                    for (int z = i.Value; z > 0; z--)
                    {
                        teams[rank - z].Points(buffer);
                        //output.Add(buffer);
                    }
                    rank += i.Value;
                }
            }

        }
    }
}
 