using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class House : RealEstate
    {
        public string Heating { get; set; }

        public House() { }
        public House(char buildType, string city, string district, string street, int number, string type, DateTime buildDate, double area, int roomCount, string heatingType) :
            base(buildType, city, district, street, number, type, buildDate, area, roomCount)
        {
            Heating = heatingType;
        }

        public override string ToString()
        {
            return string.Format("{0} {1, 9} | {2, -13} |", base.ToString(), "", Heating);
        }
    }
}
