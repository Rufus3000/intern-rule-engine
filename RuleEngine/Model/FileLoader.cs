using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RuleEngine.Model
{
    class FileLoader
    {
        public static Race GetRace(String path)
        {
            IEnumerable<string> text = File.ReadLines(path);
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
                currentLine++;
            }
            return race;
        }
    }
}
