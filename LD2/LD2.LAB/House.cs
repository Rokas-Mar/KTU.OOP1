using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.LAB
{
    /// <summary>
    /// Class of House and it's properties
    /// </summary>
    internal class House
    {
        public string District { get; set; } // in which district the house is
        public string Street { get; set; } // on which street the house is located
        public int Number { get; set; } // House number
        public string Type { get; set; } // Type of house(mūrinis, karkasinis, ect.)
        public DateTime BuildDate { get; set; } // Date when the house was built
        public double Area { get; set; } // House area
        public int RoomCount { get; set; } // House Room number

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
        /// Gets the age of house in years
        /// </summary>
        /// <returns>House age</returns>
        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BuildDate.Year;
            if (BuildDate > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
        /// <summary>
        /// Compares build dates of two house objects
        /// </summary>
        /// <param name="first">House class element</param>
        /// <param name="second">House class element</param>
        /// <returns>true if first building is older</returns>
        public static bool operator <(House first, House second)
        {
            return first.BuildDate < second.BuildDate;
        }
        /// <summary>
        /// Compares build dates of two house objects
        /// </summary>
        /// <param name="first">House class element</param>
        /// <param name="second">House class element</param>
        /// <returns>true if second building is older</returns>
        public static bool operator >(House first, House second)
        {
            return first.BuildDate > second.BuildDate;
        }
        /// <summary>
        /// Compares build dates of two house objects
        /// </summary>
        /// <param name="first">House class element</param>
        /// <param name="second">House class element</param>
        /// <returns>true if first building is older or same age</returns>
        public static bool operator <=(House first, House second)
        {
            return first.BuildDate <= second.BuildDate;
        }
        /// <summary>
        /// Compares build dates of two house objects
        /// </summary>
        /// <param name="first">House class element</param>
        /// <param name="second">House class element</param>
        /// <returns>true if second building is older or same age</returns>
        public static bool operator >=(House first, House second)
        {
            return first.BuildDate >= second.BuildDate;
        }
    }
}
