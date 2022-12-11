using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class TeamContainer
    {
        private List<Team> teams;

        public TeamContainer() 
        {
            teams = new List<Team>();
        }

        public void Add(Team team)
        {
            teams.Add(team);
        }

        public Team Get(int index)
        {
            return teams[index];
        }

        public Team GetByName(string name)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (this.Get(i).Name == name)
                {
                    return teams[i];
                }
            }
            return null;
        }
        public int Count()
        {
            return teams.Count;
        }
    }
}
