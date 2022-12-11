using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class House : RealEstate
    {
        string Heating { get; set; }

        public House() { }
        public House(string city, string district, string street, int number, string type, DateTime buildDate, double area, int roomCount, string heatingType) :
            base(city, district, street, number, type, buildDate, area, roomCount)
        {
            Heating = heatingType;
        }
    }
}
