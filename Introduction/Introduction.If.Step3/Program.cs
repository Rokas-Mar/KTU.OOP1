using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.If.Step3
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

            for (int i = 1; i < a + 1; i++)
            {
                if (i % b == 0)
                {
                    Console.WriteLine(character);
                }
                else
                {
                    Console.Write(character);
                }
            }
            Console.WriteLine("");
        }
    }
}
