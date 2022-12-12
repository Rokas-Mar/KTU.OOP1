using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class ComparatorByArea_RoomCount : RealEstateComparator
    {
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
