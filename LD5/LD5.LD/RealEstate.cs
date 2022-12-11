using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal abstract class RealEstate
    {
        public char BuildType { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public DateTime BuildDate { get; set; }
        public double Area { get; set; }
        public int RoomCount { get; set; }

        public RealEstate() 
        {

        }

        public RealEstate(char buildType, string city, string district, string street, int number, string type, DateTime buildDate, double area, int roomCount)
        {
            BuildType = buildType;
            City = city;
            District = district;
            Street = street;
            Number = number;
            this.Type = type;
            BuildDate = buildDate;
            Area = area;
            RoomCount = roomCount;
        }

        public int CompareTo(RealEstate other)
        {
            int result = this.Street.CompareTo(other.Street);
            if (result == 0)
            {
                return other.Number.CompareTo(this.Number);
            }
            return result;
        }

        public override string ToString()
        {
            return String.Format("| {0, -5} | {1, -15} | {2, -20} | {3, -20} | {4, 10} | {5, -15} | {6, 12:yyyy/MM/dd} | {7, 10} | {8, -15} |",
                BuildType, City, District, Street, Number, Type, BuildDate, Area, RoomCount);
        }

        public override bool Equals(object obj)
        {
            return this.BuildType == ((RealEstate)obj).BuildType && this.City == ((RealEstate)obj).City && this.District == ((RealEstate)obj).District && this.Street == ((RealEstate)obj).Street && this.Number == ((RealEstate)obj).Number;
        }
    }
}
