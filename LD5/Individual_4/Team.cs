using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class Team
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }
        public int MatchesPlayed { get; set; }

        public Team() { }
        public Team(string name, string city, string coach, int matchesPlayed)
        {
            Name = name;
            City = city;
            Coach = coach;
            MatchesPlayed = matchesPlayed;
        }
    }
}
