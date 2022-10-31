using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3.LAB
{
    /// <summary>
    /// House class
    /// </summary>
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

        /// <summary>
        /// Gets age of House
        /// </summary>
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BuildDate.Year;
                if (this.BuildDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        /// <summary>
        /// Formates House to print as a table
        /// </summary>
        /// <returns>Formated string of House</returns>
        public override string ToString()
        {
            return String.Format("| {0, -20} | {1, -20} | {2, 10} | {3, -15} | {4, 18:yyyy/MM/dd} | {5, 8} | {6, 18} |", District, Street, Number, Type, BuildDate, Area, RoomCount);
        }

        /// <summary>
        /// overrides < operator
        /// </summary>
        /// <param name="lh">left House element</param>
        /// <param name="rh">right DateTime element</param>
        /// <returns>true if lh build date is lesser than rh</returns>
        public static bool operator <(House lh, DateTime rh)
        {
            return lh.BuildDate < rh;
        }

        /// <summary>
        /// overrides > operator
        /// </summary>
        /// <param name="lh">left House element</param>
        /// <param name="rh">right DateTime element</param>
        /// <returns>true if lh build date is greater than rh</returns>
        public static bool operator >(House lh, DateTime rh)
        {
            return lh.BuildDate > rh;
        }

        /// <summary>
        /// overrides == operator
        /// </summary>
        /// <param name="ls">left string element</param>
        /// <param name="rh">right House element</param>
        /// <returns>true if string is equal to house street</returns>
        public static bool operator ==(string ls, House rh)
        {
            return ls == rh.Street;
        }

        /// <summary>
        /// overrides != operator
        /// </summary>
        /// <param name="ls">left string element</param>
        /// <param name="rh">right House element</param>
        /// <returns>true if string is not equal to house street</returns>
        public static bool operator !=(string ls, House rh)
        {
            return ls != rh.Street;
        }

        /// <summary>
        /// overrides GetHashCode
        /// </summary>
        /// <returns>Hash code of current object</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// overrides Equals
        /// </summary>
        /// <param name="obj">object whis is compared to house</param>
        /// <returns>true if disctricts, streets and house numbers match</returns>
        public override bool Equals(object obj)
        {
            return this.District == ((House)obj).District && this.Street == ((House)obj).Street && this.Number == ((House)obj).Number;
        }
    }
}
