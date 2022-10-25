using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LD3.Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DogsContainer register = InOutUtils.ReadDogs(@"Dogs.csv");
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");

            register.UpdateVaccinationsInfo(VaccinationsData);

            Console.WriteLine("Registro informacija: ");
            InOutUtils.PrintDogs(register);

            Console.WriteLine("Reikia paskiepyti: ");
            DogsContainer FilteredByVaccinationExpired = register.FilterByVaccinationExpired();
            InOutUtils.PrintDogs(FilteredByVaccinationExpired);

            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();

            Dogs oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}",
             oldest.Name, oldest.Breed, oldest.Age);

            List<string> Breeds = register.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            Console.WriteLine("Iš viso šunų: {0}", register.Count);

            //Console.WriteLine("Kokios veislės šunis atrinkti?");
            //string selectedBreed = Console.ReadLine();
            //DogsContainer FilteredByBreed = register.FilterByBreed(selectedBreed);
            //InOutUtils.PrintDogs(FilteredByBreed);

            //string fileName = selectedBreed + ".csv";
            //InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);
        }
    }
}
