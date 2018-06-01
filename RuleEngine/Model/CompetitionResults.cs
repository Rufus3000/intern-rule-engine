using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine.Model
{
    class CompetitionResults
    {
        private List<Race> races = new List<Race>();
        private List<CompetitionTeamResults> competition;


        public void LoadRaces()
        {
            races.Add(FileLoader.GetRace(@"C:\Git\RuleEngine\RuleEngine\RuleEngine\bin\Debug\netcoreapp2.0\data1\race1.csv"));
            races.Add(FileLoader.GetRace(@"C:\Git\RuleEngine\RuleEngine\RuleEngine\bin\Debug\netcoreapp2.0\data1\race2.csv"));
            races.Add(FileLoader.GetRace(@"C:\Git\RuleEngine\RuleEngine\RuleEngine\bin\Debug\netcoreapp2.0\data1\race3.csv"));
        }
        public void Sum() {
            foreach (Race r in races)
            {
                PointingSystem.Pointing(r.Teams);
                RankingSystem.Ranking(r.Teams);


                foreach (var team in r.Teams.OrderBy(x => x.Position))
                {
                    Console.WriteLine("{0} Position: {1} Points: {2} Rank:{3}", team.Name, team.Position, team.Points, team.Rank);

                }
                Console.WriteLine("-----------------------------------------------------------------------------");
            }
        }
        public void FinalResultsSum(int amount) { 
            competition = CompetitionTeamResults.GetResults(races);
            
            foreach(CompetitionTeamResults c in competition)
            {
                c.GetDiscard(amount);
            }
            competition = competition.OrderBy(x => x.GetPoints()).ToList();
        }
        public void ResultsOutput()
        {
            foreach(CompetitionTeamResults c in competition)
            {
                Console.WriteLine(c.ToString());
            }
        }

    }
    
}
