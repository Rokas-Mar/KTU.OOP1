using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.U1_6
{
    internal class Street
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public Street(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
