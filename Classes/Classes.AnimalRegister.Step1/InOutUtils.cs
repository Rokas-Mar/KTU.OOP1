using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Classes.AnimalRegister.Step1
{
    static class InOutUtils
    {
        public static List<Dog> ReadDogs(string fileName)
        {
            List<Dog> Dogs = new List<Dog>();
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

                Dog dog = new Dog(id, name, breed, birthDate, gender);
                Dogs.Add(dog);
            }

            return Dogs;
        }

        public static void PrintDogs(List<Dog> Dogs)
        {
            Console.WriteLine(new String('-', 74));
            Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12} | {4, -8} |",
                "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
            Console.WriteLine(new string ('-', 74));
            foreach(Dog dog in Dogs)
            {
                Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12:yyyy-MM-dd} | {4, -8} | ",
                    dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }
    }
}
