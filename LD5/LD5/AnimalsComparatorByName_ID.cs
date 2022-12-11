using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5
{
    internal class AnimalsComparatorByName_ID : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            if(a.Name.CompareTo(b.Name) == 0)
            {
                return a.ID.CompareTo(b.ID);
            }
            return a.Name.CompareTo(b.Name);
        }
    }
}
