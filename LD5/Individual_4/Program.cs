using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            const string PlayerFile = @"Zaidejai.csv";
            const string TeamFile = @"Komandos.csv";
            PlayerContainer Players = InOutUtils.ReadPlayers(PlayerFile);
            TeamContainer Teams = InOutUtils.ReadTeams(TeamFile);

            InOutUtils.PrintPlayers(Players, "Pradinis sarasas");
            InOutUtils.PrintTeams(Teams, "Teams");

            Console.WriteLine("Kurio miesto žaidėjus atrinkti?");
            string city = Console.ReadLine();

            TaskUtils.SetPlayerPlayedAll(Players, Teams);
            TaskUtils.SetPlayerAverage(Players);

            TeamContainer FilteredTeams = TaskUtils.GetTeamsByCity(Teams, city);
            PlayerContainer PlayersByCity = TaskUtils.GetPlayersByCity(FilteredTeams, Players);

            if (PlayersByCity.Count != 0)
            {
                InOutUtils.PrintPlayers(PlayersByCity, "Atrinkti žaidėjai");
            }
            else
            {
                Console.WriteLine("Nerasta");
            }
        }
    }
}
