using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Individual_4
{
    internal class InOutUtils
    {
        public static PlayerContainer ReadPlayers(string fileName)
        {
            PlayerContainer Players = new PlayerContainer();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach(string line in lines)
            {
                string[] Values = line.Split(';');
                char type = Convert.ToChar(Values[0]);
                string team = Values[1];
                string surname = Values[2];
                string name = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);
                int matchesPlayed = int.Parse(Values[5]);
                int score = int.Parse(Values[6]);
                
                switch(type)
                {
                    case 'B':
                        int rebounds = int.Parse(Values[7]);
                        int resPasses = int.Parse(Values[8]);
                        Basketball basketball = new Basketball(type, team, name, surname, birthDate, matchesPlayed, score, rebounds, resPasses);
                        Players.Add(basketball);
                        break;
                    case 'F':
                        int yellowCards = int.Parse(Values[7]);
                        Football football = new Football(type, team, name, surname, birthDate, matchesPlayed, score, yellowCards);
                        Players.Add(football);
                        break;
                    default:
                        break;
                }
            }
            return Players;
        }

        public static TeamContainer ReadTeams(string fileName)
        {
            TeamContainer teams = new TeamContainer();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach(string line in lines)
            {
                string[] parts = line.Split(';');
                string name = parts[0];
                string city = parts[1];
                string coach = parts[2];
                int matches = int.Parse(parts[3]);

                Team team = new Team(name, city, coach, matches);
                teams.Add(team);
            }
            return teams;
        }

        public static void PrintPlayers(PlayerContainer Players, string label)
        {
            Console.WriteLine(new String('-', 165));
            Console.WriteLine("| {0, -161} |", label);
            Console.WriteLine(new String('-', 165));
            Console.WriteLine("| {0, -8} | {1, -15} | {2, -15} | {3, -20} | {4, -14} | {5, -20} | {6, -8} | {7, -10} | {8, -10} | {9, -14} | {10, 10} {11, 12:F3}",
                "Type", "Team", "Name", "Surname", "Birth date", "Matches played", "Score", "Rebounds", "Assists", "Yellow cards", "PlayedAll", "Average");
            Console.WriteLine(new String('-', 165));
            for(int i = 0; i < Players.Count; i++)
            {
                Player player = Players.Get(i);
                if (player is Basketball)
                {
                    Console.WriteLine("| {0, -8} | {1, -15} | {2, -15} | {3, -20} | {4, 14:yyyy/MM/dd} | {5, 20} | {6, 8} | {7, 10} | {8, 10} | {9, 14} | {10, 10} {11, 12:F3}",
                        player.Type, player.Team, player.Name, player.Surname, player.BirthDate, player.MatchesPlayed, player.Score, (player as Basketball).Rebounds, (player as Basketball).Assists, "", player.PlayedAll, player.Average);
                }
                else if(player is Football)
                {
                    Console.WriteLine("| {0, -8} | {1, -15} | {2, -15} | {3, -20} | {4, 14:yyyy/MM/dd} | {5, 20} | {6, 8} | {7, 10} | {8, 10} | {9, 14} | {10, 10} {11, 12:F3}",
                        player.Type, player.Team, player.Name, player.Surname, player.BirthDate, player.MatchesPlayed, player.Score, "", "", (player as Football).YellowCards, player.PlayedAll, player.Average);
                }
            }
            Console.WriteLine(new String('-', 165));
        }

        public static void PrintTeams(TeamContainer Teams, string label)
        {
            Console.WriteLine(new String('-', 84));
            Console.WriteLine("| {0, -80} |", label);
            Console.WriteLine(new String('-', 84));
            Console.WriteLine("| {0, -15} | {1, -10} | {2, -30} | {3, 16} |", "Team name", "City", "Coach", "Match count");
            Console.WriteLine(new String('-', 84));
            for (int i = 0; i < Teams.Count(); i++)
            {
                Team team = Teams.Get(i);
                Console.WriteLine("| {0, -15} | {1, -10} | {2, -30} | {3, 16} |", team.Name, team.City, team.Coach, team.MatchesPlayed);
            }
            Console.WriteLine(new String('-', 84));
        }
    }
}
