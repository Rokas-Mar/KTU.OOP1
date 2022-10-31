using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Emit;

namespace LD3.LAB
{
    internal class InOutUtils
    {
        public static HouseRegister ReadHouses(string fileName)
        {
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            string company = Lines[0];
            string adress = Lines[1];
            string cell = Lines[2];
            HouseRegister houseReg = new HouseRegister(company, adress, cell);
            for (int i = 3; i < Lines.Length; i++)
            {
                string line = Lines[i];
                string[] Values = line.Split(';');
                string district = Values[0].Trim();
                string street = Values[1].Trim();
                int number = Convert.ToInt32(Values[2]);
                string type = Values[3].Trim();
                DateTime date = Convert.ToDateTime(Values[4]);
                double area = Convert.ToDouble(Values[5]);
                int roomCount = Convert.ToInt32(Values[6]);

                House house = new House(district, street, number, type, date, area, roomCount);
                if (!houseReg.Contains(house))
                {
                    houseReg.Add(house);
                }
            }
            return houseReg;
        }

        public static void PrintHousesToTxt(string fileName, HouseRegister Houses)
        {
            string[] lines = new string[Houses.Count() + 8];
            lines[0] = new String('-', 47);
            lines[1] = String.Format("| {0, -43} |", Houses.Company);
            lines[2] = String.Format("| {0, -43} |", Houses.Adress);
            lines[3] = String.Format("| {0, -43} |", Houses.Cell);
            lines[4] = String.Format(new String('-', 131));
            lines[5] = String.Format("| {0, -20} | {1, -20} | {2, -10} | {3, -15} | {4, -18:yyyy/MM/dd} | {5, -8} | {6, -18} |", "Mikrorajonas", "Gatvė", "Numeris", "Tipas", "Pastatymo metai", "Plotas", "Kambarių skaičius");
            lines[6] = String.Format(new String('-', 131));
            for (int i = 0; i < Houses.Count(); i++)
            {
                House house = Houses.Get(i);
                lines[i + 7] = String.Format(house.ToString());
            }
            lines[Houses.Count() + 7] = String.Format(new String('-', 131));
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        public static void PrintHouses(string label, HouseRegister Houses)
        {
            Console.WriteLine(new String('-', 47));
            Console.WriteLine("| {0, -43} |", label);
            Console.WriteLine(new String('-', 47));
            Console.WriteLine("| {0, -43} |", Houses.Company);
            Console.WriteLine("| {0, -43} |", Houses.Adress);
            Console.WriteLine("| {0, -43} |", Houses.Cell);
            Console.WriteLine(new String('-', 131));
            Console.WriteLine("| {0, -20} | {1, -20} | {2, -10} | {3, -15} | {4, -18:yyyy/MM/dd} | {5, -8} | {6, -18} |", "Mikrorajonas", "Gatvė", "Numeris", "Tipas", "Pastatymo metai", "Plotas", "Kambarių skaičius");
            Console.WriteLine(new String('-', 131));
            for (int i = 0; i < Houses.Count(); i++)
            {
                House house = Houses.Get(i);
                Console.WriteLine(house.ToString());
            }
            Console.WriteLine(new String('-', 131));
        }

        public static void PrintOldestHouses(string label, HouseRegister Houses)
        {
            Console.WriteLine(new String('-', 110));
            Console.WriteLine("| {0, -106} |", label);
            Console.WriteLine(new String('-', 110));
            Console.WriteLine("| {0, -20} | {1, -20} | {2, -10} | {3, -15} | {4, -18} | {5, -8} |", "Mikrorajonas", "Gatvė", "Numeris", "Tipas", "Amžius", "Plotas");
            Console.WriteLine(new String('-', 110));
            for (int i = 0; i < Houses.Count(); i++)
            {
                House house = Houses.Get(i);
                Console.WriteLine("| {0, -20} | {1, -20} | {2, 10} | {3, -15} | {4, 18} | {5, 8} |", house.District, house.Street, house.Number, house.Type, house.Age, house.Area);
            }
            Console.WriteLine(new String('-', 110));
        }

        public static void PrintMostSoldStreets(string label, List<string> Streets, int maxVal)
        {
            Console.WriteLine(new String('-', 47));
            Console.WriteLine("| {0, -43} |", label + " (" + maxVal + ")");
            Console.WriteLine(new String('-', 47));
            for (int i = 0; i < Streets.Count(); i++)
            {
                Console.WriteLine("| {0, -43} |", Streets[i]);
            }
            Console.WriteLine(new String('-', 47));
        }

        public static void PrintToCSVFile(string label, string fileName, HouseRegister Houses)
        {
            string[] lines = new string[Houses.Count() + 2];
            lines[0] = String.Format("{0}", label);
            lines[1] = String.Format("{0};{1};{2};{3};{4};{5};{6}", "Mikrorajonas", "Gatvė", "Numeris", "Tipas", "Metai", "Plotas", "Kambarių skaičius");
            for (int i = 0; i < Houses.Count(); i++)
            {
                House House = Houses.Get(i);
                lines[i + 2] = String.Format("{0};{1};{2};{3};{4, 1:yyyy/MM/dd};{5};{6}",
                    House.District, House.Street, House.Number, House.Type, House.BuildDate, House.Area, House.RoomCount);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
