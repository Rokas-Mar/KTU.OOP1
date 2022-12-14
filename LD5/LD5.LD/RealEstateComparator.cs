using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    /// <summary>
    /// Main comparator class
    /// </summary>
    internal class RealEstateComparator
    {
        /// <summary>
        /// Compares two elements
        /// </summary>
        /// <param name="a">RealEstate element</param>
        /// <param name="b">RealEstate element</param>
        /// <returns>Intiger of compared elements</returns>
        public virtual int Compare(RealEstate a, RealEstate b)
        {
            return a.CompareTo(b);
        }
    }
}
