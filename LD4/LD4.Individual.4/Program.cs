// C++ Free Pascal

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LD4.Individual._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFw = "Zodziai.txt";
            const string CFr = "Rezultatai.txt";
            string punctuation = "[^a-zA-ZąčęėįšųūžĄČĘĖĮŠŲŪŽ1-9]+";
            TaskUtils.Process(CFw, CFd, CFr, punctuation);
        }
    }
}
