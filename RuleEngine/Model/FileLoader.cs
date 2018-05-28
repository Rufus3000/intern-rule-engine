using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RuleEngine.Model
{
    class FileLoader
    {
        //pridat do parametru string path, zatim jde o testovaci fazi
        public static Race GetRace()
        {
            IEnumerable<string> text = File.ReadLines(Directory.GetCurrentDirectory() + "data1/race1.csv");
            Race race = new Race();
            int currentLine = 1;
            foreach (string l in text)
            {
                string[] line = l.Split(',');
                if (currentLine != 1)
                {
                    Team team = new Team();
                    team.Name = line[0];
                    team.Position = int.Parse(line[1]);
                    race.Teams.Add(team);
                }
            }
            return race;
        }
    }
}
