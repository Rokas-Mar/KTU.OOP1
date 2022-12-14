using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    /// <summary>
    /// Comparator class for sorting bu street and number
    /// </summary>
    internal class ComparatorByStreet_Number : RealEstateComparator
    {
        /// <summary>
        /// Overrides Compare method to sort by street and number
        /// </summary>
        /// <param name="a">RealEstate element</param>
        /// <param name="b">RealEstate element</param>
        /// <returns>intiger of compared elements</returns>
        public override int Compare(RealEstate a, RealEstate b)
        {
            if (a.Street.CompareTo(b.Street) == 0)
            {
                return a.Number.CompareTo(b.Number);
            }
            return a.Street.CompareTo(b.Street);
        }
    }
}
