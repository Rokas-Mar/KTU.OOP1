using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class Flat : RealEstate
    {
        int Floor { get; set; }

        public Flat() { }
        public Flat(string city, string district, string street, int number, string type, DateTime buildDate, double area, int roomCount, int floor) : 
            base(city, district, street, number, type, buildDate, area, roomCount)
        {
            Floor = floor;
        }

        public abstract override string ToString()
        {
            return String.Format("| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {8} | {9} |",
                );
        }
    }
}
