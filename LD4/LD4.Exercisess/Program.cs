using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD4.Exercisess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            LettersFrequency letters = new LettersFrequency();
            InOut.Repetitions(CFd, letters);
            string line = Console.ReadLine();
            letters.line = line;
            letters.Count();
            InOut.PrintRepetitions(CFr, letters);

            int No = InOut.LongestLine(CFd);
            InOut.RemoveLine(CFd, CFr, No);
            Console.WriteLine("Ilgiausios eilutės nr. {0, 4:d}", No + 1);
        }
    }
}
