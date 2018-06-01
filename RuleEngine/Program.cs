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
            CompetitionResults results = new CompetitionResults();
            results.LoadRaces();
            results.Sum();
            results.FinalResultsSum(1);
            results.ResultsOutput();

            Console.ReadKey();
        }
    }
}
