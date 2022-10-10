using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.If.Individual1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char character;
            int a;
            int b;

            Console.WriteLine("Iveskite simboliu kieki:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Iveskite vienos eilutes simboliu kieki:");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite spasudinama simboli");
            character = (char)Console.Read();

            for(int i = a; a > 1; i--)
            {
                for(int j = 1; j < b + 1; j++)
                {
                    Console.Write(character);
                    i--;
                }
                Console.WriteLine("");
            }
        }
    }
}
