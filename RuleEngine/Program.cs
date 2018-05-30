using System;
using System.Collections.Generic;
using System.Linq;
using RuleEngine.Model;

namespace RuleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Race> races = new List<Race>();
            races.Add(FileLoader.GetRace(@"C:\Git\RuleEngine\RuleEngine\RuleEngine\bin\Debug\netcoreapp2.0\data1\race1.csv"));
            races.Add(FileLoader.GetRace(@"C:\Git\RuleEngine\RuleEngine\RuleEngine\bin\Debug\netcoreapp2.0\data1\race2.csv"));
            races.Add(FileLoader.GetRace(@"C:\Git\RuleEngine\RuleEngine\RuleEngine\bin\Debug\netcoreapp2.0\data1\race3.csv"));

            foreach (Race r in races)
            {
                PointingSystem.Pointing(r.Teams);
                RankingSystem.Ranking(r.Teams);

                foreach (var team in r.Teams.OrderBy(x => x.Position))
                {
                   Console.WriteLine("{0} Position: {1} Points: {2} Rank:{3}",team.Name, team.Position, team.Points, team.Rank);
                    
                }
                Console.WriteLine("-----------------------------------------------------------------------------");
            }/*
            foreach (Team t in races[0].Teams.OrderBy(x => x.Position))
            {
                Console.WriteLine(t.Name);
            }
            PointingSystem.Pointing(races[0].Teams);

            foreach (Team t in races[0].Teams.OrderBy(x => x.Position))
            {
                
                Console.WriteLine(t.Name + " " + t.Points);
            }
                */
                

            Console.ReadKey();
        }
    }
}
