using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace LD3.Exercises
{
    static class InOutUtils
    {
        public static DogsContainer ReadDogs(string fileName)
        {
            DogsContainer Dogs = new DogsContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                string name = Values[1];
                string breed = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);

                Gender gender;
                Enum.TryParse(Values[4], out gender);

                Dogs dog = new Dogs(id, name, breed, birthDate, gender);
                if (!Dogs.Contains(dog))
                {
                    Dogs.Add(dog);
                }
            }

            return Dogs;
        }

        public static void PrintDogs(string label, DogsContainer Dogs)
        {
            Console.WriteLine(new String('-', 74));
            Console.WriteLine("| {0, -70} |", label);
            Console.WriteLine(new String('-', 74));
            Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12} | {4, -8} |",
                "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < Dogs.Count; i++)
            {
                Dogs dog = Dogs.Get(i);
                Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12:yyyy-MM-dd} | {4, -8} | ",
                    dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }

        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static void PrintDogsToCSVFile(string fileName, DogsContainer Dogs)
        {
            string[] lines = new string[Dogs.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}",
            "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < Dogs.Count; i++)
            {
                Dogs Dog = Dogs.Get(i);
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}",
                Dog.ID, Dog.Name, Dog.Breed, Dog.BirthDate, Dog.Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);

                Vaccination v = new Vaccination(id, vaccinationDate);

                Vaccinations.Add(v);
            }
            return Vaccinations;
        }
    }
}
