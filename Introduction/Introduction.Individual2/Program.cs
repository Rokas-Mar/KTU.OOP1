using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Individual2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double functionRezult;
            double x;

            Console.WriteLine("Iveskite x reiksme");
            x = Convert.ToDouble(Console.ReadLine());


            if (x >= -1 && x < 0)
            {
                functionRezult = Math.Sin(x) * Math.Sin(x);
            }
            else if (x <= 0 && x < 1)
            {
                functionRezult = (x - 1) * (x - 1);
            }
            else
            {
                functionRezult = x * x + x + 1;
            }

            Console.WriteLine("Reiksme x = {0}, fx = {1}", x, functionRezult);
        }
    }
}
