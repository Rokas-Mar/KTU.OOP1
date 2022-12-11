using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class Flat : RealEstate
    {
        public int Floor { get; set; }

        public Flat() { }
        public Flat(char buildType, string city, string district, string street, int number, string type, DateTime buildDate, double area, int roomCount, int floor) : 
            base(buildType, city, district, street, number, type, buildDate, area, roomCount)
        {
            Floor = floor;
        }

        public override string ToString()
        {
            return string.Format("{0} {1, 9} | {2, 13} |", base.ToString(), Floor, "");
        }
    }
}
