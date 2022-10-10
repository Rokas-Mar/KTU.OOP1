using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LD2.Register.Step1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dogs> allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            DogsRegister register = InOutUtils.ReadDogsRegister(@"Dogs.csv");


            Console.WriteLine("Registro informacija: ");
            InOutUtils.PrintDogs(register);

            Console.WriteLine("Is viso sunu: {0}", allDogs.Count);

            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();

            Dogs oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}",
             oldest.Name, oldest.Breed, oldest.CalculateAge());

            List<string> Breeds = register.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());

            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            List<Dogs> FilteredByBreed = register.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);
        }
    }
}
