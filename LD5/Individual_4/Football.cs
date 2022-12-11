using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class Football : Player
    {
        public int YellowCards { get; set; }
        public override bool PlayedAll { get; set; }
        public override double Average { get; set; }
        public Football(char type, string team, string name, string surname, DateTime birthDate, int matchesPlayed, int score, int yellowCards) :
            base(type, team, name, surname, birthDate, matchesPlayed, score)
        {
            YellowCards = yellowCards;
        }
    }
}
