using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Model
{
    class Team
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public double Points { get; set; }
        public int Rank { get; set; }
        public List<int> RaceResults = new List<int>();

    }
}
