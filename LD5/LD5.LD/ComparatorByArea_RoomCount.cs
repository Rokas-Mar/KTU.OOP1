using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    /// <summary>
    /// Comparator class for sorting by area and room count
    /// </summary>
    internal class ComparatorByArea_RoomCount : RealEstateComparator
    {
        /// <summary>
        /// Overrides compare method to sort by area and room count
        /// </summary>
        /// <param name="a">RealEstate element</param>
        /// <param name="b">RealEstate element</param>
        /// <returns>intiger of compared elements</returns>
        public override int Compare(RealEstate a, RealEstate b)
        {
            if (a.Area.CompareTo(b.Area) == 0)
            {
                return a.RoomCount.CompareTo(b.RoomCount);
            }
            return a.Area.CompareTo(b.Area);
        }
    }
}
