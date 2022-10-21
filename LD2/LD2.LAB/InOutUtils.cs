using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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
        /// Prints all start info into txt file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="Houses">HouseList element</param>
        public static void PrintHousesToTxt(string fileName, HouseList Houses)
        {
            string[] lines = new string[Houses.HouseCount() + 4];
            lines[0] = String.Format(new String('-', 117));
            lines[1] = String.Format("| {0, -15} | {1, -20} | {2, -8} | {3, -15} | {4, -10} | {5, -7} | {6, -20} | ",
                "Mikrorajonas", "Gatvė", "Numeris", "Tipas", "Metai", "Plotas", "Kambariu skaicius");
            lines[2] = String.Format(new String('-', 117));
            for (int i = 0; i < Houses.HouseCount(); i++)
            {
                House house = Houses.GetIndexedElement(i);
                lines[i + 3] = String.Format("| {0, -15} | {1, -20} | {2, 8} | {3, -15} | {4, 10:yyyy/MM/dd} | {5, 7} | {6, 20} | ",
                    house.District, house.Street, house.Number, house.Type, house.BuildDate, house.Area, house.RoomCount);
            }
            lines[Houses.HouseCount() + 3] = String.Format(new String('-', 117));
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
        /// <summary>
        /// Prints all houses to console
        /// </summary>
        /// <param name="houses">HouseList element</param>
        public static void PrintHouses(HouseList houses)
        {
            Console.WriteLine(new String('-', 51));
            Console.WriteLine("| {0, -15} | {1, -15} | {2, 11} |", "Kompanija", "Adresas", "Numeris");
            Console.WriteLine(new String('-', 51));
            Console.WriteLine("| {0, -15} | {1, -15} | {2, 11} |", houses.CompanyName, houses.CompanyAdress, houses.CompanyCell);
            Console.WriteLine(new String('-', 117));
            Console.WriteLine("| {0, -15} | {1, -20} | {2, -8} | {3, -15} | {4, -10} | {5, -7} | {6, -20} |", "Mikrorajonas", "Gatvė", "Numeris", "Tipas", "Metai", "Plotas", "Kambariu skaičius");
            Console.WriteLine(new String('-', 117));
            for (int i = 0; i < houses.HouseCount(); i++)
            {
                House house = houses.GetIndexedElement(i);
                Console.WriteLine("| {0, -15} | {1, -20} | {2, 8} | {3, -15} | {4, 10:yyyy/MM/dd} | {5, 7} | {6, 20} |", house.District, house.Street, house.Number, house.Type, house.BuildDate, house.Area, house.RoomCount);
            }
            Console.WriteLine(new String('-', 117));
        }
        /// <summary>
        /// Prints all oldest houses from a list
        /// </summary>
        /// <param name="Houses">House List element</param>
        public static void PrintStreets(HouseList Houses)
        {
            Console.WriteLine(new String('-', 65));
            Console.WriteLine("| {0, -61} |", "Seniausias namas");
            Console.WriteLine(new String('-', 65));
            Console.WriteLine("| {0, -8} | {1, -24} | {2, -10} | {3, -10} |", "Amžius", "Adresas", "Tipas", "Plotas");
            Console.WriteLine(new String('-', 65));
            for(int i = 0; i < Houses.HouseCount(); i++)
            {
                House house = Houses.GetIndexedElement(i);
                Console.WriteLine("| {0, 8} | {1, -24} | {2, -10} | {3, 10} |", house.GetAge(), house.Street + " " + house.Number, house.Type, house.Area);
            }
            Console.WriteLine(new String('-', 65));
        }
        /// <summary>
        /// Prints all streets which have the most houses sold in them
        /// </summary>
        /// <param name="Streets">SellingSt List element</param>
        public static void PrintStreet(List<SellingSt> Streets)
        {
            Console.WriteLine(new String('-', 53));
            Console.WriteLine("| Gatvės, turinčios daugiausiai parduodamų namų ({0}) |", Streets[0].StCount);
            Console.WriteLine(new String('-', 53));
            for (int i = 0; i < Streets.Count(); i++)
            {
                Console.WriteLine("| {0, -49} |", Streets[i].Street);
            }
            Console.WriteLine(new String('-', 53));
        }
        /// <summary>
        /// Prints all houses to a CSV file
        /// </summary>
        /// <param name="Company1">HouseList list element</param>
        /// <param name="Company2">HouseList list element</param>
        /// <param name="fileName">File to which houses should be printed</param>
        public static void PrintHousesToCSV(HouseList Company1, HouseList Company2, string fileName)
        {
            string[] lines = new string[Company1.HouseCount() + Company2.HouseCount() + 1];
            int count = 0;
            HouseList Temp = Company1;
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6}", "Mikrorajonas", "Gatvė", "Numeris", "Tipas", "Metai", "Plotas", "Kambarių skaičius");
            for(int j = 0; j < 2; j++)
            {
                int m = 0;
                for (int i = count; i < Temp.HouseCount() + count; i++)
                {
                    House Houses = Temp.GetIndexedElement(m);
                    lines[i + 1] = String.Format("{0};{1};{2};{3};{4, 1:yyyy/MM/dd};{5};{6}",
                        Houses.District, Houses.Street, Houses.Number, Houses.Type, Houses.BuildDate, Houses.Area, Houses.RoomCount);
                    m++;
                }
                count = Company1.HouseCount();
                Temp = Company2;
            }
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
