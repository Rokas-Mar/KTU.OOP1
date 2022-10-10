using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.Individual1
{
    internal class Tourist
    {
        public string name { get; set; }
        public string surname { get; set; }
        public double cash { get; set; }

        public Tourist(string name, string surname, double cash)
        {
            this.name = name;
            this.surname = surname;
            this.cash = cash;
        }
    }
}
