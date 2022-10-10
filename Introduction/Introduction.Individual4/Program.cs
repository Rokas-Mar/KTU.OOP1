using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Introduction.Individual4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1257);

            string name;
            string ending;

            Console.WriteLine("Koks Tavo vardas?");
            name = Console.ReadLine();

            Program program = new Program();

            ending = program.FindEnding(name);

            switch(ending)
            {
                case "as":
                    Console.WriteLine("Labas, {0}{1}", name.Remove(name.Length - 1), "i!");
                    break;
                case "is":
                    Console.WriteLine("Labas, {0}!", name.Remove(name.Length - 1));
                    break;
                case "ys":
                    name = name.Remove(name.Length - 1);
                    name = name.Remove(name.Length - 1);
                    Console.WriteLine("Labas, {0}{1}", name, "į!");
                    break;
                case "a":
                    Console.WriteLine("Labas, {0}", name);
                    break;
                case "ė":
                    Console.WriteLine("Labas, {0}{1}", name.Remove(name.Length - 1), "e!");
                    break;
            }
        }

        string FindEnding(string name)
        {
            name.ToLower();

            if (name[name.Length - 1] == 's')
            {
                char a = name[name.Length - 1];
                char b = name[name.Length - 2];

                return b.ToString() + a.ToString();
            }
            else
            {
                return Convert.ToString(name[name.Length - 1]);
            }

        }
    }
}
