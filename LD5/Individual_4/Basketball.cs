using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class Basketball : Player
    {
        public int Rebounds { get; set; }
        public int Assists { get; set; }
        public override bool PlayedAll { get; set; }
        public override double Average { get; set; }

        public Basketball(char type, string team, string name, string surname, DateTime birthDate, int matchesPlayed, 
            int score, int rebounds, int resPasses) :
            base(type, team, name, surname, birthDate, matchesPlayed, score)
        {
            Rebounds = rebounds;
            Assists = resPasses;
        }

    }
}
