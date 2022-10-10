using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab1.Excercises.Register.Step6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dog> allDogs = InOutUtils.ReadDogs(@"Dogs.csv");

            Console.WriteLine("Registro informacija: ");
            InOutUtils.PrintDogs(allDogs);

            Console.WriteLine("Is viso sunu: {0}", allDogs.Count);

            Console.WriteLine("Patinų: {0}", TaskUtils.CountByGender(allDogs, Gender.Male));
            Console.WriteLine("Patelių: {0}", TaskUtils.CountByGender(allDogs, Gender.Female));
            Console.WriteLine();

        }
    }
}
