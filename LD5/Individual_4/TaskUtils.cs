using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class TaskUtils
    {
        public static PlayerContainer GetPlayersByCity(TeamContainer teams, PlayerContainer Players) 
        {
            PlayerContainer result = new PlayerContainer();
            for (int i = 0; i < Players.Count; i++)
            {
                Player player = Players.Get(i);
                for(int j = 0; j < teams.Count(); j++)
                {
                    if (teams.Get(j).Name == player.Team && player.Score > player.Average && player.PlayedAll)
                    {
                        result.Add(player);
                    }
                }
            }
            return result;
        }

        public static TeamContainer GetTeamsByCity(TeamContainer teams, string name)
        {
            TeamContainer result = new TeamContainer();
            for(int i = 0; i < teams.Count(); i++)
            {
                if(teams.Get(i).City.ToLower().Trim() == name.ToLower().Trim())
                {
                    result.Add(teams.Get(i));
                }
            }
            return result;
        }

        public static double GetTeamAverage(PlayerContainer Players, string team)
        {
            double sum = 0;
            int count = 0;
            for(int i = 0; i < Players.Count; i++)
            {
                Player player = Players.Get(i);
                if(player.Team == team)
                {
                    sum += player.Score;
                    count++;
                }
            }
            return sum / count;
        }

        public static void SetPlayerAverage(PlayerContainer Players)
        {
            for(int i = 0; i < Players.Count; i++)
            {
                Players.Get(i).Average = GetTeamAverage(Players, Players.Get(i).Team);
            }
        }

        public static void SetPlayerPlayedAll(PlayerContainer Players, TeamContainer Teams)
        {
            for(int i = 0; i < Players.Count; i++)
            {
                if (Players.Get(i).MatchesPlayed == Teams.GetByName(Players.Get(i).Team).MatchesPlayed)
                {
                    Players.Get(i).PlayedAll = true;
                }
            }
        }
    }
}
