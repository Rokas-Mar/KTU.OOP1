using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    /// <summary>
    /// Street container class
    /// </summary>
    internal class StreetsContainer
    {
        private List<Street> StreetList;

        public StreetsContainer()
        {
            StreetList = new List<Street>();
        }

        /// <summary>
        /// Adds element to container
        /// </summary>
        /// <param name="street">Street element</param>
        public void Add(Street street)
        {
            StreetList.Add(street);
        }

        /// <summary>
        /// Gets indexed element
        /// </summary>
        /// <param name="index">index to get</param>
        /// <returns>Street element</returns>
        public Street Get(int index)
        {
            return StreetList[index];
        }

        /// <summary>
        /// Checks if container contains element
        /// </summary>
        /// <param name="street">Street element</param>
        /// <returns>true, if container contains element</returns>
        public bool Contains(Street street)
        {
            for(int i = 0; i < StreetList.Count; i++)
            {
                if (this.StreetList[i] == street)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets index of element
        /// </summary>
        /// <param name="street">Street element</param>
        /// <returns>index of found element</returns>
        public int IndexOf(Street street)
        {
            for (int i = 0; i < StreetList.Count; i++)
            {
                if (this.StreetList[i] == street)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Adds street count to Street
        /// </summary>
        /// <param name="index">index to which to add</param>
        public void AddCount(int index)
        {
            if(!(index < 0))
            StreetList[index].Count++;
        }

        /// <summary>
        /// Gets count of streets
        /// </summary>
        /// <returns>intiger of streets</returns>
        public int Count()
        {
            return StreetList.Count;
        }

        /// <summary>
        /// Gets max count from container
        /// </summary>
        /// <returns>intiger of max count</returns>
        public int GetMaxCount()
        {
            int maxval = 0;

            for(int i = 0; i < StreetList.Count(); i++)
            {
                if (StreetList[i].Count > maxval)
                {
                    maxval= StreetList[i].Count;
                }
            }

            return maxval;
        }
    }
}
