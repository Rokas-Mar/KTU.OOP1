using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class ComparatorByStreet_Number : RealEstateComparator
    {
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
