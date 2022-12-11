using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal abstract class Player
    {
        public char Type { get; set; }
        public string Team { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int MatchesPlayed { get; set; }
        public int Score { get; set; }
        public Player() { }
        public Player(char type, string team, string name, string surname, DateTime birthDate, int matchesPlayed, int score)
        {
            Type = type;
            Team = team;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            MatchesPlayed = matchesPlayed;
            Score = score;
        }
        public abstract bool PlayedAll { get; set; }
        public abstract double Average { get; set; }
        
    }
}
