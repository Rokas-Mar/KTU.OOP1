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
        /// Compares dates between House element and date
        /// </summary>
        /// <param name="house">House element</param>
        /// <param name="date">DateTime element</param>
        /// <returns>true if house build date is less than the date it is compared to</returns>
        public static bool operator <(House house, DateTime date)
        {
            return house.BuildDate < date;
        }
        /// <summary>
        /// Compares dates between House element and date
        /// </summary>
        /// <param name="house">House element</param>
        /// <param name="date">DateTime element</param>
        /// <returns>true if house build date is greater than the date it is compared to</returns>
        public static bool operator >(House house, DateTime date)
        {
            return house.BuildDate > date;
        }

        /// <summary>
        /// Checks if build date is equal to date
        /// </summary>
        /// <param name="house">House element</param>
        /// <param name="date">DateTime element</param>
        /// <returns>true if build date is equal to date</returns>
        public static bool operator ==(House house, DateTime date)
        {
            return house.BuildDate == date;
        }

        /// <summary>
        /// Checks if build date is not equal to date
        /// </summary>
        /// <param name="house">House element</param>
        /// <param name="date">DateTime element</param>
        /// <returns>true if build date is not equal to date</returns>
        public static bool operator !=(House house, DateTime date)
        {
            return house.BuildDate != date;
        }

        /// <summary>
        /// GetHashCode override
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Equals override
        /// </summary>
        /// <param name="obj">Class object</param>
        /// <returns>true if obj equals to object</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
