using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD4.LD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CInitialFile = "Knyga.txt";
            const string CInfoFile = "Rodikliai.txt";
            const string CChangedFile = "ManoKnyga.txt";

            const string spacing = " ";

            TaskUtils.Process(CInitialFile, CInfoFile);
            TaskUtils.Align(CInitialFile, CChangedFile, spacing);
        }
    }
}
