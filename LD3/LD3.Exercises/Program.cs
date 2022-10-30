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
            DogsContainer container = InOutUtils.ReadDogs(@"Dogs.csv");
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");

            container.UpdateVaccinationsInfo(VaccinationsData);
            InOutUtils.PrintDogs("Registro informacija", container);

            DogsContainer allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            DogsContainer copy = new DogsContainer(allDogs);
            allDogs.Sort();
            InOutUtils.PrintDogs("Išrikiuoti šunys", allDogs);
            InOutUtils.PrintDogs("Šunų konteinerio kopija", copy);

            Console.WriteLine("Patinų: {0}", container.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", container.CountByGender(Gender.Female));
            Console.WriteLine();

            Dogs oldest = container.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}",
             oldest.Name, oldest.Breed, oldest.Age);

            List<string> Breeds = container.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            Console.WriteLine("Iš viso šunų: {0}", container.Count);

            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            DogsContainer FilteredByBreed = container.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs("Atrinkti šunys (" + selectedBreed + ")", FilteredByBreed);

            DogsContainer FilteredByVaccinationExpired = FilteredByBreed.FilterByVaccinationExpired();
            InOutUtils.PrintDogs("Reikia paskiepyti: ", FilteredByVaccinationExpired);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);
        }
    }
}
