using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class RealEstateContainer
    {
        private List<RealEstate> realEstates;

        public RealEstateContainer() 
        {
            realEstates= new List<RealEstate>();
        }

        public void Add(RealEstate realEstate)
        {
            realEstates.Add(realEstate);
        }

        public void Add(RealEstateContainer realEstate)
        {
            for(int i = 0; i < realEstates.Count; i++)
            {
                if (!this.Contains(realEstate.Get(i)))
                {
                    this.Add(realEstate);
                }
            }
        }

        public void Replace(int index, RealEstate value)
        {
            realEstates[index] = value;
        }

        public RealEstate Get(int index)
        {
            return realEstates[index];
        }

        public int Count()
        {
            return realEstates.Count;
        }

        public bool Contains(RealEstate element)
        {
            for (int i = 0; i < this.Count(); i++)
            {
                if (this.realEstates[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Sort(RealEstateComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count() - 1; i++)
                {
                    RealEstate a = realEstates[i];
                    RealEstate b = realEstates[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        realEstates[i] = b;
                        realEstates[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public void Sort()
        {
            Sort(new RealEstateComparator());
        }
    }
}
