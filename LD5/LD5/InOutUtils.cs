using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using LD5;

namespace LD5
{
    static class InOutUtils
    {
        public static AnimalContainer ReadDogs(string fileName)
        {
            AnimalContainer animals = new AnimalContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string type = Values[0];
                int id = int.Parse(Values[1]);
                string name = Values[2];
                string breed = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);

                Gender gender;
                Enum.TryParse(Values[5], out gender);
                
                switch(type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(Values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    case "GUINEAPIG":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        animals.Add(guineaPig);
                        break;
                    default:
                        break;
                }
            }

            return animals;
        }

        public static void PrintDogs(string label, AnimalContainer Animals)
        {
            Console.WriteLine(new String('-', 88));
            Console.WriteLine("| {0, -84} |", label);
            Console.WriteLine(new String('-', 88));
            Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12} | {4, -8} | {5, -11} |",
                "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis", "Agresyvus");
            Console.WriteLine(new string('-', 88));
            for (int i = 0; i < Animals.Count; i++)
            {
                Animal animal = Animals.Get(i);
                if (animal is Dog)
                {
                    bool agro = (animal as Dog).Aggresive;
                    Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12:yyyy-MM-dd} | {4, -8} | {5, -11} |",
                        animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender, agro);
                }
                else
                {
                    Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12:yyyy-MM-dd} | {4, -8} | {5, -11} |",
                        animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender, "");
                }
            }
            Console.WriteLine(new string('-', 88));
        }

        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static void PrintDogsToCSVFile(string fileName, AnimalContainer Animals)
        {
            string[] lines = new string[Animals.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}",
            "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < Animals.Count; i++)
            {
                Animal animal = Animals.Get(i);
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}",
                animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender);
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
