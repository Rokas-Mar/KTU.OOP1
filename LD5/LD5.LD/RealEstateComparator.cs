using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class RealEstateComparator
    {
        public virtual int Compare(RealEstate a, RealEstate b)
        {
            return a.CompareTo(b);
        }
    }
}
