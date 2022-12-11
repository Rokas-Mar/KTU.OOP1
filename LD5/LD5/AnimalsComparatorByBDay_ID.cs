using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5
{
    internal class AnimalsComparatorByBDay_ID : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            if(a.BirthDate.CompareTo(b.BirthDate) == 0)
            {
                return a.ID.CompareTo(b.ID);
            }
            return a.BirthDate.CompareTo(b.BirthDate);
        }
    }
}
