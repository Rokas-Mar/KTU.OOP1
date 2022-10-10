using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.U1_6
{
    internal class House
    {
        public string District { get; set; }
        public string StreetName { get; set; }
        public int HouseNr { get; set; }
        public string HouseType { get; set; }
        public DateTime BuildYear { get; set; }
        public double HouseArea { get; set; }
        public int RoomCount { get; set; }

        public House(string district, string street, int houseNr, string houseType, DateTime buildYear, double houseArea, int roomCount)
        {
            this.District = district;
            this.StreetName = street;
            this.HouseNr = houseNr;
            this.HouseType = houseType;
            this.BuildYear = buildYear;
            this.HouseArea = houseArea;
            this.RoomCount = roomCount;
        }
    }
}
