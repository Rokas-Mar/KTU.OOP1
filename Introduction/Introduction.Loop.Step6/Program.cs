using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Loop.Step6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;

            int t = 0;

            Console.WriteLine("Iveskite rezius:");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            Console.WriteLine("Skaiciai nuo {0} iki {1}, ju kvadratai ir kubai:", a, b);
            for (int i = a; i < b + 1; i++)
            {
                Console.WriteLine("{0}  {1}  {2}", i, i * i, i * i * i);
                t++;
            }
            Console.WriteLine("Skaiciuota kartu - {0}", t);
        }
    }
}
