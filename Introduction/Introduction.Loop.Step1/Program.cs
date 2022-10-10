using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Loop.Step1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skaiciai nuo 1 iki 10 ir ju kvadratai:");
            for(int i = 1; i < 11; i++)
            {
                Console.WriteLine("{0}  {1}", i, i * i);
            }
        }
    }
}
