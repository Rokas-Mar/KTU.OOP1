using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Individual3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            char symbol;
            bool goodSymbol = false;

            Console.WriteLine("Iveskite pirmaji skaiciu: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Iveskite antraji skaiciu: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Iveskite operacijos simboli(+, -, *, /): ");
            symbol = Convert.ToChar(Console.ReadLine());
            while (!goodSymbol)
            {
                if(symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/')
                {
                    goodSymbol = true;
                }
                else
                {
                    Console.WriteLine("Klaidinga operacija");
                    Console.WriteLine("Iveskite operacijos simboli(+, -, *, /): ");
                    symbol = Convert.ToChar(Console.ReadLine());
                }
            }

            if(symbol == '+')
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, symbol, b, a + b);
            }
            else if(symbol == '-')
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, symbol, b, a - b);
            }
            else if(symbol == '*')
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, symbol, b, a * b);
            }
            else
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, symbol, b, a / b);
            }
        }
    }
}
