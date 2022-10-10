using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Methods.Step1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char character;
            Console.WriteLine("Iveskite spausdinama simboli");
            character = Convert.ToChar(Console.Read());
            Program program = new Program();
            program.Display(character);
        }

        void Display(char characterToDisplay)
        {
            for(int i = 1; i < 51; i++)
            {
                if(i % 5 == 0)
                {
                    Console.WriteLine(characterToDisplay);
                }
                else
                {
                    Console.Write(characterToDisplay);
                }
            }
            Console.WriteLine("");
        }
    }
}
