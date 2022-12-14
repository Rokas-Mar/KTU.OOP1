using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    /// <summary>
    /// RealEstate container class
    /// </summary>
    internal class RealEstateContainer
    {
        private List<RealEstate> realEstates; // RealEstate List

        public RealEstateContainer() 
        {
            realEstates= new List<RealEstate>();
        }

        /// <summary>
        /// Adds element to container
        /// </summary>
        /// <param name="realEstate">RealEstate element</param>
        public void Add(RealEstate realEstate)
        {
            realEstates.Add(realEstate);
        }

        /// <summary>
        /// Adds a whole Container to current container
        /// </summary>
        /// <param name="realEstate">RealEstateContainer class element</param>
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

        /// <summary>
        /// Replaces element with given value at given index
        /// </summary>
        /// <param name="index">index to replace</param>
        /// <param name="value">Element to replace with</param>
        public void Replace(int index, RealEstate value)
        {
            realEstates[index] = value;
        }
        
        /// <summary>
        /// Gets indexed element
        /// </summary>
        /// <param name="index">index to get</param>
        /// <returns>RealEstate element</returns>
        public RealEstate Get(int index)
        {
            return realEstates[index];
        }

        /// <summary>
        /// Gets count of container elements
        /// </summary>
        /// <returns>intiger of element count</returns>
        public int Count()
        {
            return realEstates.Count;
        }

        /// <summary>
        /// Checks if current container contains element
        /// </summary>
        /// <param name="element">RealEstate element</param>
        /// <returns>true, if container contains element</returns>
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

        /// <summary>
        /// search algorithm to search for element
        /// </summary>
        /// <param name="element">RealEstate element</param>
        /// <returns>index of element location</returns>
        public int IndexSearchSorted(RealEstate element)
        {
            for(int i = 0; i < this.Count(); i++)
            {
                if (realEstates[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Sorts elements by comparator
        /// </summary>
        /// <param name="comparator">RealEstateCOmparator element</param>
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

        /// <summary>
        /// Empty sort method
        /// </summary>
        public void Sort()
        {
            Sort(new RealEstateComparator());
        }
    }
}
