using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5
{
    internal class AnimalsComparator
    {
        public virtual int Compare(Animal a, Animal b)
        {
            return a.CompareTo(b);
        }
    }
}
