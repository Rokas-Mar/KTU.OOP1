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
            if (allDogs.Count > 0)
            {
                InOutUtils.PrintDogs(allDogs);

                Console.WriteLine("Is viso sunu: {0}", allDogs.Count);
                List<string> mostFrequent = TaskUtils.GetBreeds(allDogs);
                Console.WriteLine("Patinų: {0}", TaskUtils.CountByGender(allDogs, Gender.Male));
                Console.WriteLine("Patelių: {0}", TaskUtils.CountByGender(allDogs, Gender.Female));
                Console.WriteLine();

                Dog oldest = TaskUtils.FindOldestDog(allDogs);
                Console.WriteLine("Seniausias šuo");
                Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}",
                 oldest.Name, oldest.Breed, oldest.CalculateAge());

                List<string> Breeds = TaskUtils.FindBreeds(allDogs);
                Console.WriteLine("Šunų veislės:");
                InOutUtils.PrintBreeds(Breeds);
                Console.WriteLine();

                string mostPopBreed = TaskUtils.MostPopularBreed(Breeds, allDogs);
                Console.WriteLine("Populiariausia veislė: " + mostPopBreed);
                Console.WriteLine();

                Console.WriteLine("Kokios veislės šunis atrinkti?");
                string selectedBreed = Console.ReadLine();
                List<Dog> FilteredByBreed = TaskUtils.FilterByBreed(allDogs, selectedBreed);
                if (FilteredByBreed.Count > 0)
                {
                    InOutUtils.PrintDogs(FilteredByBreed);
                    string fileName = selectedBreed + ".csv";
                    InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);
                }
                else
                {
                    Console.WriteLine("Veisle nerasta");
                }
            }
            else
            {
                Console.WriteLine("Šunų nerasta");
            }
        }
    }
}
