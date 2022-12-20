using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Emit;

namespace LD5.LD
{
    /// <summary>
    /// Class for all In and Out methods
    /// </summary>
    internal class InOutUtils
    {
        /// <summary>
        /// Reads Agency info from file
        /// </summary>
        /// <param name="fileName">name of file from which to read info from</param>
        /// <returns>Register element of Agency info</returns>
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

        /// <summary>
        /// Writes all initial data into txt file
        /// </summary>
        /// <param name="fileName">Txt file</param>
        /// <param name="Agency1">Register element</param>
        /// <param name="Agency2">Register element</param>
        /// <param name="Agency3">Register element</param>
        public static void PrintInitial(string fileName, Register Agency1, Register Agency2, Register Agency3)
        {
            if(File.Exists(fileName))
                File.Delete(fileName);

            Register temp = Agency1;

            for (int i = 0; i < 3; i++)
            {
                if(i == 1)
                {
                    temp = Agency2;
                }
                if(i == 2)
                {
                    temp = Agency3;
                }
                string[] lines = new string[temp.Count() + 11];
                lines[0] = string.Format(new String('-', 178));
                lines[1] = string.Format("| {0,-174} |", "Agency " + (i + 1));
                lines[2] = string.Format(new String('-', 178));
                lines[3] = string.Format($"| {temp.AgencyName,-174} |");
                lines[4] = string.Format($"| {temp.AgencyAdress,-174} |");
                lines[5] = string.Format($"| {temp.AgencyCell,-174} |");
                lines[6] = string.Format(new String('-', 178));
                lines[7] = string.Format("| {0, -5} | {1, -15} | {2, -20} | {3, -20} | {4, -10} | {5, -15} | {6, -12} | {7, -10} | {8, -15} | {9, -9} | {10, -13} |",
                "Type", "City", "District", "Street", "Number", "Build type", "Build Date", "Area", "Room Count", "Floor", "Heating type");
                lines[8] = string.Format(new String('-', 178));
                for (int j = 0; j < temp.Count(); j++)
                {
                    RealEstate realEstate = temp.Get(j);
                    if (realEstate is Flat)
                    {
                        lines[j + 9] = (realEstate as Flat).ToString();
                    }
                    else
                    {
                        lines[j + 9] = (realEstate as House).ToString();
                    }
                }
                lines[temp.Count() + 9] = string.Format(new String('-', 178));
                File.AppendAllLines(fileName, lines);
            }
        }

        /// <summary>
        /// Prints All RealEstate elements to console
        /// </summary>
        /// <param name="realEstate">RealEstate Ragister element</param>
        /// <param name="label">Table name</param>
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

        /// <summary>
        /// Prints streets to console
        /// </summary>
        /// <param name="Streets">StreetsContainer element</param>
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

        /// <summary>
        /// Prints RealEstate to CSV file
        /// </summary>
        /// <param name="fileName">file name to which RealEstate will be printed</param>
        /// <param name="RealEstate">RealEstate element</param>
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

        /// <summary>
        /// Prints a list of RealEstate without agency info
        /// </summary>
        /// <param name="realEstate">RealEstate element</param>
        /// <param name="label">Table name</param>
        public static void PrintRealEstateList(Register realEstate, string label)
        {
            Console.WriteLine(new String('-', 178));
            Console.WriteLine("| {0, -174} |", label);
            Console.WriteLine(new String('-', 178));
            Console.WriteLine("| {0, -5} | {1, -15} | {2, -20} | {3, -20} | {4, -10} | {5, -15} | {6, -12} | {7, -10} | {8, -15} | {9, -9} | {10, -13} |",
                "Type", "City", "District", "Street", "Number", "Build type", "Build Date", "Area", "Room Count", "Floor", "Heating type");
            Console.WriteLine(new String('-', 178));
            for (int i = 0; i < realEstate.Count(); i++)
            {
                RealEstate building = realEstate.Get(i);
                if (building is Flat)
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
    }
}
