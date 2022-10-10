using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace LD2.Register.Step2
{
    static class InOutUtils
    {
        public static List<Dogs> ReadDogs(string fileName)
        {
            List<Dogs> Dogs = new List<Dogs>();
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
                Dogs.Add(dog);
            }

            return Dogs;
        }

        public static DogsRegister ReadDogsRegister(string fileName)
        {
            DogsRegister Dogs = new DogsRegister();
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
                Dogs.Add(dog);
            }

            return Dogs;
        }

        public static void PrintDogs(List<Dogs> Dogs)
        {
            Console.WriteLine(new String('-', 74));
            Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12} | {4, -8} |",
                "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            foreach (Dogs dog in Dogs)
            {
                Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12:yyyy-MM-dd} | {4, -8} | ",
                    dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }

        public static void PrintDogs(DogsRegister Dogs)
        {
            Console.WriteLine(new String('-', 74));
            Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12} | {4, -8} |",
                "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < Dogs.DogsCount(); i++)
            {
                Dogs dog = Dogs.getIndexedElement(i);
                Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12:yyyy-MM-dd} | {4, -8} | ",
                    dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }
        public static void PrintDogsRegister(DogsRegister register)
        {

        }
        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static void PrintDogsToCSVFile(string fileName, List<Dogs> Dogs)
        {
            string[] lines = new string[Dogs.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}",
            "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < Dogs.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}",
                Dogs[i].ID, Dogs[i].Name, Dogs[i].Breed, Dogs[i].BirthDate, Dogs[i].Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
