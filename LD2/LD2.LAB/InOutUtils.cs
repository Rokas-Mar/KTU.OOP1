using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD2.LAB
{
    static class InOutUtils
    {
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
    }
}
