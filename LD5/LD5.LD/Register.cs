using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    /// <summary>
    /// Register class containing Container class
    /// </summary>
    internal class Register
    {
        public string AgencyName { get; set; }
        public string AgencyAdress { get; set; }
        public string AgencyCell { get; set; }
        private RealEstateContainer realEstates;

        public Register(string agencyName, string agencyAdress, string agencyCell)
        {
            AgencyName = agencyName;
            AgencyAdress = agencyAdress;
            AgencyCell = agencyCell;
            realEstates = new RealEstateContainer();
        }

        public Register()
        {
            realEstates = new RealEstateContainer();
        }

        /// <summary>
        /// Call to container to add element
        /// </summary>
        /// <param name="realEstate">RealEstate element</param>
        public void Add(RealEstate realEstate)
        {
            realEstates.Add(realEstate);
        }

        /// <summary>
        /// Adds another Register to current register
        /// </summary>
        /// <param name="realEstate"></param>
        public void Add(Register realEstate)
        {
            for(int i = 0; i < realEstate.Count(); i++)
            {
                if(!this.Contains(realEstate.Get(i)))
                {
                    this.Add(realEstate.Get(i));
                }
            }
        }

        /// <summary>
        /// Call to container to replace element
        /// </summary>
        /// <param name="index">index to replace</param>
        /// <param name="value">value to replace with</param>
        public void Replace(int index, RealEstate value)
        {
            realEstates.Replace(index, value);
        }

        /// <summary>
        /// Gets indexed element
        /// </summary>
        /// <param name="index">index to retrieve</param>
        /// <returns>RealEstate element</returns>
        public RealEstate Get(int index)
        {
            return realEstates.Get(index);
        }

        /// <summary>
        /// Gets count of elements
        /// </summary>
        /// <returns>intiger of element count</returns>
        public int Count()
        {
            return realEstates.Count();
        }

        /// <summary>
        /// Checks if container contains element
        /// </summary>
        /// <param name="realEstate">ealEstate element</param>
        /// <returns>true, if container contains element</returns>
        public bool Contains(RealEstate realEstate)
        {
            return realEstates.Contains(realEstate);
        }

        /// <summary>
        /// Checks intersecting elements with current and given Registers
        /// </summary>
        /// <param name="Agency">Register element</param>
        /// <returns>Register element of intersecting elements</returns>
        public Register Intersects(Register Agency)
        {
            Register houseRegister = new Register();
            for (int i = 0; i < Agency.Count(); i++)
            {
                RealEstate house = Agency.Get(i);
                if (this.realEstates.Contains(house))
                {
                    houseRegister.Add(Agency.Get(i));
                }
            }
            return houseRegister;
        }

        /// <summary>
        /// Call to container to sort
        /// </summary>
        /// <param name="comparator"></param>
        public void Sort(RealEstateComparator comparator)
        {
            realEstates.Sort(comparator);
        }

        /// <summary>
        /// Call to sort method in container class
        /// </summary>
        public void Sort()
        {
            realEstates.Sort();
        }
    }
}
