using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Loop.Step4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 20;

            Console.WriteLine("Skaiciai nuo {0} iki {1}, ju kvadratai ir kubai:", a, b);
            for (int i = a; i < b + 1; i++)
            {
                Console.WriteLine("{0}  {1}  {2}", i, i * i, i * i * i);
            }
        }
    }
}
