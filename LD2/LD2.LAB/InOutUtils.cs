using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD2.LAB
{
    /// <summary>
    /// Class of all Read and Print methods
    /// </summary>
    static class InOutUtils
    {
        /// <summary>
        /// Reads all houses from a txt file
        /// </summary>
        /// <param name="fileName">which file to read from</param>
        /// <returns></returns>
        public static HouseList ReadHouses(string fileName)
        {
            HouseList Houses = new HouseList();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            Houses.CompanyName = Lines[0];
            Houses.CompanyAdress = Lines[1];
            Houses.CompanyCell = Lines[2];
            for(int i = 3; i < Lines.Length; i++)
            {
                string line = Lines[i];
                string[] Values = line.Split(';');
                string district = Values[0];
                string street = Values[1];
                int Number = Convert.ToInt32(Values[2]);
                string type = Values[3];
                DateTime buildDate = DateTime.Parse(Values[4]);
                double area = Convert.ToDouble(Values[5]);
                int roomCount = Convert.ToInt32(Values[6]);

                House house = new House(district, street, Number, type, buildDate, area, roomCount);

                Houses.Add(house);
            }
            return Houses;
        }
        /// <summary>
        /// Prints all houses to console
        /// </summary>
        /// <param name="houses">HouseList element</param>
        public static void PrintHouses(HouseList houses)
        {
            Console.WriteLine(new String('-', 51));
            Console.WriteLine("| {0, 15} | {1, 15} | {2, 11} |", "Kompanija", "Adresas", "Numeris");
            Console.WriteLine(new String('-', 51));
            Console.WriteLine("| {0, 15} | {1, 15} | {2, 11} |", houses.CompanyName, houses.CompanyAdress, houses.CompanyCell);
            Console.WriteLine(new String('-', 117));
            Console.WriteLine("| {0, 15} | {1, 20} | {2, 8} | {3, 15} | {4, 10} | {5, 7} | {6, 20} |", "Mikrorajonas", "Gatvė", "Numeris", "Tipas", "Metai", "Plotas", "Kambariu skaičius");
            Console.WriteLine(new String('-', 117));
            for (int i = 0; i < houses.HouseCount(); i++)
            {
                House house = houses.GetIndexedElement(i);
                Console.WriteLine("| {0, 15} | {1, 20} | {2, 8} | {3, 15} | {4, 10:yyyy/MM/dd} | {5, 7} | {6, 20} |", house.District, house.Street, house.Number, house.Type, house.BuildDate, house.Area, house.RoomCount);
            }
            Console.WriteLine(new String('-', 117));
        }
        /// <summary>
        /// Prints all oldest houses from a list
        /// </summary>
        /// <param name="Houses">House List element</param>
        public static void PrintStreets(List<House> Houses)
        {
            Console.WriteLine(new String('-', 65));
            Console.WriteLine("| {0, -61} |", "Seniausias namas");
            Console.WriteLine(new String('-', 65));
            Console.WriteLine("| {0, 8} | {1, 24} | {2, 10} | {3, 10} |", "Amžius", "Adresas", "Tipas", "Plotas");
            Console.WriteLine(new String('-', 65));
            foreach (House house in Houses)
            {
                Console.WriteLine("| {0, 8} | {1, 24} | {2, 10} | {3, 10} |", house.GetAge(), house.Street + " " + house.Number, house.Type, house.Area);
            }
            Console.WriteLine(new String('-', 65));
        }
        /// <summary>
        /// Prints all streets which have the most houses sold in them
        /// </summary>
        /// <param name="SoldStreets">SellingSt List element</param>
        public static void PrintStreet(List<SellingSt> SoldStreets)
        {
            Console.WriteLine(new String('-', 48));
            Console.WriteLine("| Daugiausiai parduodamų namų turinčios gatvės |");
            Console.WriteLine(new String('-', 48));
            foreach (SellingSt street in SoldStreets)
            {
                Console.WriteLine("| {0, -30} | {1, 11} |", street.Street, street.StCount);
            }
            Console.WriteLine(new String('-', 48));
        }
        /// <summary>
        /// Prints all houses to a CSV file
        /// </summary>
        /// <param name="Houses">House list element</param>
        /// <param name="fileName">File to which houses should be printed</param>
        public static void PrintHousesToCSV(List<House> Houses, string fileName)
        {
            string[] lines = new string[Houses.Count() + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6}", "Mikrorajonas", "Gatvė", "Numeris", "Tipas", "Metai", "Plotas", "Kambariu skaičius");
            for(int i = 0; i < Houses.Count(); i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6}",
                    Houses[i].District, Houses[i].Street, Houses[i].Number, Houses[i].Type, Houses[i].BuildDate, Houses[i].Area, Houses[i].RoomCount);
            }
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
