using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    /// <summary>
    /// RealEstate child class defining House element
    /// </summary>
    internal class House : RealEstate
    {
        public string Heating { get; set; } // Heating type of house element

        public House() { }
        public House(char buildType, string city, string district, string street, int number, string type, DateTime buildDate, double area, int roomCount, string heatingType) :
            base(buildType, city, district, street, number, type, buildDate, area, roomCount)
        {
            Heating = heatingType;
        }

        /// <summary>
        /// Overrides ToString methid to output a formated line
        /// </summary>
        /// <returns>formated string line</returns>
        public override string ToString()
        {
            return string.Format("{0} {1, 9} | {2, -13} |", base.ToString(), "", Heating);
        }
    }
}
