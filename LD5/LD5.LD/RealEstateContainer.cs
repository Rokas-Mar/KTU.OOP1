using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class RealEstateContainer
    {
        List<RealEstate> realEstates;

        public RealEstateContainer() { }

        public void Add(RealEstate realEstate)
        {
            realEstates.Add(realEstate);
        }

        public RealEstate Get(int index)
        {
            return realEstates[index];
        }

        public int Count()
        {
            return realEstates.Count;
        }
    }
}
