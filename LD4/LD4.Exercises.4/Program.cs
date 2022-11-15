using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD4.Exercises._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            string Punctuation = "[\\s,.;:!?()\\-]+";
            Console.WriteLine("Sutampanciu zodziu {0, 3:d}", TaskUtils.Process(CFd, Punctuation));
        }
    }
}
