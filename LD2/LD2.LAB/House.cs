using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.LAB
{
    internal class House
    {
        public string District { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public DateTime BuildDate { get; set; }
        public double Area { get; set; }
        public int RoomCount { get; set; }

        public House(string district, string street, int number, string type, DateTime buildDate, double area, int roomCount)
        {
            District = district;
            Street = street;
            Number = number;
            Type = type;
            BuildDate = buildDate;
            Area = area;
            RoomCount = roomCount;
        }

        public House()
        {
        }

        public static bool operator <(House first, House second)
        {
            return first.BuildDate < second.BuildDate;
        }

        public static bool operator >(House first, House second)
        {
            return first.BuildDate > second.BuildDate;
        }
    }
}
