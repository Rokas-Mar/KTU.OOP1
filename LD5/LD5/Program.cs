using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LD5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimalContainer container = InOutUtils.ReadDogs(@"Animals.csv");
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");

            container.UpdateVaccinationsInfo(VaccinationsData);
            InOutUtils.PrintDogs("Registro informacija", container);

            AnimalContainer allDogs = InOutUtils.ReadDogs(@"Animals.csv");

            Console.WriteLine("Patinų: {0}", container.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", container.CountByGender(Gender.Female));
            Console.WriteLine();

            Animal oldest = container.FindOldestDog();
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
            AnimalContainer FilteredByBreed = container.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs("Atrinkti šunys (" + selectedBreed + ")", FilteredByBreed);

            AnimalContainer FilteredByVaccinationExpired = FilteredByBreed.FilterByVaccinationExpired();
            InOutUtils.PrintDogs("Reikia paskiepyti: ", FilteredByVaccinationExpired);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);

            AnimalContainer Sort1 = new AnimalContainer(allDogs);
            Sort1.Sort(new AnimalsComparatorByName_ID());
            InOutUtils.PrintDogs("Surikiuota pagal Varda ir ID", Sort1);

            AnimalContainer Sort2 = new AnimalContainer(allDogs);
            Sort2.Sort(new AnimalsComparatorByBDay_ID());
            InOutUtils.PrintDogs("Surikiuota pagal Gimimo data ir ID", Sort2);
        }
    }
}
