using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;

namespace Lab1.Exercises.U1_6
{
    internal class InOutUtils
    {
        /// <summary>
        /// Prints houses to a TXT file
        /// </summary>
        /// <param name="fileName">TXT file name</param>
        /// <param name="Houses">List of houses</param>
        public static void PrintToTXTFile(string fileName, List<House> Houses)
        {
            string[] Lines = new string[Houses.Count + 4];
            Lines[0] = String.Format(new String('-', 124));
            Lines[1] = String.Format("| {0, -14} | {1, -20} | {2, -10} | {3, -15} | {4, -15:yyy-mm-dd} | {5, -11} | {6, -17} |",
            "Mikrorajonas", "Gatvė", "Namo numeris", "Namo tipas", "Pastatymo metai", "Plotas", "Kambarių skaičius");
            Lines[2] = String.Format(new String('-', 124));
            for (int i = 0; i < Houses.Count; i++)
            {
                Lines[i + 3] = String.Format("| {0, -14} | {1, -20} | {2, -10} | {3, -15} | {4, -15:yyy-mm-dd} | {5, -11} | {6, -17} |",
                Houses[i].District, Houses[i].StreetName, Houses[i].HouseNr, Houses[i].HouseType, Houses[i].BuildYear, Houses[i].HouseArea, Houses[i].RoomCount);
            }
            Lines[Houses.Count + 3] = String.Format(new String('-', 124));
            File.WriteAllLines(fileName, Lines, Encoding.UTF8);
        }

        /// <summary>
        /// Reads a file and puts collected info into a list
        /// </summary>
        /// <param name="fileName">A CSV file name</param>
        /// <returns>A list of houses</returns>
        public static List<House> ReadAllHouses(string fileName)
        {
            List<House> Houses = new List<House>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach(string line in Lines)
            {
                string[] parts = line.Split(';');
                string district = parts[0];
                string street = parts[1];
                int houseNr = Convert.ToInt32(parts[2]);
                string houseType = parts[3];
                DateTime buildYear = Convert.ToDateTime(parts[4]);
                double houseArea = Convert.ToDouble(parts[5]);
                int roomCount = Convert.ToInt32(parts[6]);

                House house = new House(district, street, houseNr, houseType, buildYear, houseArea, roomCount);
                Houses.Add(house);
            }

            return Houses;
        }

        /// <summary>
        /// Prints Houses list to the console
        /// </summary>
        /// <param name="Houses">A list of houses</param>
        public static void PrintHouses(List<House> Houses)
        {
            Console.WriteLine("Visi namai:");
            Console.WriteLine(new String('-', 124));
            Console.WriteLine("| {0, -14} | {1, -20} | {2, -10} | {3, -15} | {4, -15:yyy-mm-dd} | {5, -11} | {6, -17} |",
                "Mikrorajonas", "Gatvė", "Namo nr.", "Namo tipas", "Pastatymo metai", "Namo Plotas", "Kambarių skaičius");
            Console.WriteLine(new String('-', 124));
            foreach (House house in Houses)
            {
                Console.WriteLine("| {0, -14} | {1, -20} | {2, 10} | {3, -15} | {4, 15:yyy-mm-dd} | {5, 11} | {6, 17} |",
                    house.District, house.StreetName, house.HouseNr, house.HouseType, house.BuildYear, house.HouseArea, house.RoomCount);
            }
            Console.WriteLine(new String('-', 124));
        }

        /// <summary>
        /// Prints oldest houses to a console
        /// </summary>
        /// <param name="oldestHouses">Oldest house list</param>
        public static void PrintOldestHouses(List<House> oldestHouses)
        {
            Console.WriteLine("Seniausi namai:");
            Console.WriteLine(new String('-', 87));
            Console.WriteLine("| {0, -20} | {1, -10} | {2, -15} | {3, -15:yyy-mm-dd} | {4, -11} |",
                "Gatvė", "Namo nr.", "Namo tipas", "Pastatymo metai", "Namo Plotas");
            Console.WriteLine(new String('-', 87));
            foreach (House house in oldestHouses)
            {
                Console.WriteLine("| {0, -20} | {1, 10} | {2, -15} | {3, 15:yyy-mm-dd} | {4, 11} |",
                    house.StreetName, house.HouseNr, house.HouseType, house.BuildYear, house.HouseArea);
            }
            Console.WriteLine(new String('-', 87));
        }

        /// <summary>
        /// Prints the steet which has the most houses being sold
        /// </summary>
        /// <param name="Streets">A list of streets and their reoccurances</param>
        public static void PrintMostSellingSt(List<Street> Streets)
        {
            Console.WriteLine("Gatvė, kurioje daugausiai parduodama namų:");
            Console.WriteLine(new String('-', 34));
            Console.WriteLine("| Parduodamų namų kiekis: {0, 6} |", Streets[0].Amount);
            Console.WriteLine(new String('-', 34));
            Console.WriteLine("| {0, -30} |", "Gatvė(-s)");
            Console.WriteLine(new String('-', 34));
            foreach (Street street in Streets)
            {
                Console.WriteLine("| {0, -30} |", street.Name);
            }
            Console.WriteLine(new String('-', 34));
        }

        /// <summary>
        /// Prints houses to a CSV file
        /// </summary>
        /// <param name="fileName">A CSV file</param>
        /// <param name="Houses">A list of houses</param>
        public static void PrintToCSVFile(string fileName, List<House> Houses)
        {
            string[] Lines = new string[Houses.Count + 1];
            Lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6}",
            "Mikrorajonas", "Gatvė", "Namo numeris", "Namo tipas", "Pastatymo metai", "Plotas", "Kambarių skaičius");
            for (int i = 0; i < Houses.Count; i++)
            {
                Lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6}",
                Houses[i].District, Houses[i].StreetName, Houses[i].HouseNr, Houses[i].HouseType, Houses[i].BuildYear, Houses[i].HouseArea, Houses[i].RoomCount);
            }
            File.WriteAllLines(fileName, Lines, Encoding.UTF8);
        }
    }
}