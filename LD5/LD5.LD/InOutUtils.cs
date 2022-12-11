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
        public static RealEstateContainer ReadAgencyInfo(string fileName)
        {
            RealEstateContainer container = new RealEstateContainer();
            string[] Lines = File.ReadAllLines(fileName);
            string AgencyName = Lines[0];
            string AgencyStreet = Lines[1];
            string AgencyCell = Lines[2];
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
                        Flat flat = new Flat(city, district, street, number, type, buildDate, area, roomCount, floor);
                        container.Add(flat);
                        break;
                    case 'H':
                        string heating = parts[9];
                        House house = new House(city, district, street, number, type, buildDate, area, roomCount, heating);
                        container.Add(house);
                        break;
                    default:
                        break;
                }
            }
            return container;
        }

        public static void PrintRealEstate(Register realEstate)
        {
            Console.WriteLine(new String('-', 100));
            Console.WriteLine($"| {realEstate.AgencyName, 96} |");
            Console.WriteLine($"| {realEstate.AgencyAdress, 96} |");
            Console.WriteLine($"| {realEstate.AgencyCell, 96} |");
            Console.WriteLine(new String('-', 100));
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
            Console.WriteLine(new String('-', 100));
        }
    }
}
