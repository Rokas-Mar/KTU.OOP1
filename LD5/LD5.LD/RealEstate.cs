using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal abstract class RealEstate
    {
        string City { get; set; }
        string District { get; set; }
        string Street { get; set; }
        int Number { get; set; }
        string type { get; set; }
        DateTime BuildDate { get; set; }
        double Area { get; set; }
        int RoomCount { get; set; }

        public RealEstate() 
        {

        }

        public RealEstate(string city, string district, string street, int number, string type, DateTime buildDate, double area, int roomCount)
        {
            City = city;
            District = district;
            Street = street;
            Number = number;
            this.type = type;
            BuildDate = buildDate;
            Area = area;
            RoomCount = roomCount;
        }

        public abstract ToString();
    }
}
