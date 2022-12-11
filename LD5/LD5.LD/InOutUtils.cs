using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD5.LD
{
    internal class InOutUtils
    {
        public static Register ReadAgencyInfo(string fileName)
        {
            Register realEstate = new Register();
            string[] Lines = File.ReadAllLines(fileName);
            realEstate.AgencyName = Lines[0];
            realEstate.AgencyAdress = Lines[1];
            realEstate.AgencyCell = Lines[2];
            for(int i = 0; i < Lines.Length - 3; i++)
            {
                string[] parts = Lines[i + 3].Split(';');
                char houseType = Convert.ToChar(parts[0]);
                string city = parts[1];
                string district = parts[2];
                string street = parts[3];
                int number = Convert.ToInt32(parts[4]);
                string type = parts[5];
                DateTime buildDate = Convert.ToDateTime(parts[6]);
                double area = Convert.ToDouble(parts[7]);
                int roomCount = Convert.ToInt32(parts[8]);

                switch(houseType)
                {
                    case 'F':
                        int floor = Convert.ToInt32(parts[9]);
                        Flat flat = new Flat(houseType, city, district, street, number, type, buildDate, area, roomCount, floor);
                        if (!realEstate.Contains(flat))
                        {
                            realEstate.Add(flat);
                        }
                        break;
                    case 'H':
                        string heating = parts[9];
                        House house = new House(houseType, city, district, street, number, type, buildDate, area, roomCount, heating);
                        if (!realEstate.Contains(house))
                        {
                            realEstate.Add(house);
                        }
                        break;
                    default:
                        break;
                }
            }
            return realEstate;
        }

        public static void PrintRealEstate(Register realEstate, string label)
        {
            Console.WriteLine(new String('-', 178));
            Console.WriteLine($"| {label, -174} |");
            Console.WriteLine(new String('-', 178));
            Console.WriteLine($"| {realEstate.AgencyName, -174} |");
            Console.WriteLine($"| {realEstate.AgencyAdress, -174} |");
            Console.WriteLine($"| {realEstate.AgencyCell, -174} |");
            Console.WriteLine(new String('-', 178));
            Console.WriteLine("| {0, -5} | {1, -15} | {2, -20} | {3, -20} | {4, -10} | {5, -15} | {6, -12} | {7, -10} | {8, -15} | {9, -9} | {10, -13} |",
                "Type", "City", "District", "Street", "Number", "Build type", "Build Date", "Area", "Room Count", "Floor", "Heating type");
            Console.WriteLine(new String('-', 178));
            for(int i = 0; i < realEstate.Count(); i++)
            {
                RealEstate building = realEstate.Get(i);
                if(building is Flat)
                {
                    Console.WriteLine((building as Flat).ToString());
                }
                else
                {
                    Console.WriteLine((building as House).ToString());
                }
            }
            Console.WriteLine(new String('-', 178));
        }

        public static void PrintStreets(StreetsContainer Streets)
        {
            Console.WriteLine(new String('-', 40));
            Console.WriteLine("| {0, -36} |", $"Most sold streets({Streets.GetMaxCount()}):");
            Console.WriteLine(new String('-', 40));
            for(int i = 0; i < Streets.Count(); i++)
            {
                Console.WriteLine("| {0, -36} |", Streets.Get(i).St);
            }
            Console.WriteLine(new String('-', 40));
        }

        public static void PrintToCSV(string fileName, Register RealEstate)
        {
            string[] lines = new string[RealEstate.Count() + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}",
            "Type", "City", "District", "Street", "Number", "Type", "Build date", "Area", "Room count", "Heating type", "Floor");
            for (int i = 0; i < RealEstate.Count(); i++)
            {
                RealEstate realEstate = RealEstate.Get(i);
                if (realEstate is Flat)
                {
                    lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6:yyyy/MM/dd};{7};{8};{9};{10}",
                        realEstate.BuildType, realEstate.City, realEstate.District, realEstate.Street, realEstate.Number, realEstate.Type, realEstate.BuildDate, realEstate.Area, realEstate.RoomCount, "", (realEstate as Flat).Floor);
                }
                else
                {
                    lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6:yyyy/MM/dd};{7};{8};{9};{10}",
                        realEstate.BuildType, realEstate.City, realEstate.District, realEstate.Street, realEstate.Number, realEstate.Type, realEstate.BuildDate, realEstate.Area, realEstate.RoomCount, (realEstate as House).Heating, "");
                }
            }

            File.WriteAllLines(fileName, lines);
        }
    }
}
