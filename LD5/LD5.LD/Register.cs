using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
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

        public void Add(RealEstate realEstate)
        {
            realEstates.Add(realEstate);
        }

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

        public void Replace(int index, RealEstate value)
        {
            realEstates.Replace(index, value);
        }

        public RealEstate Get(int index)
        {
            return realEstates.Get(index);
        }

        public int Count()
        {
            return realEstates.Count();
        }

        public bool Contains(RealEstate realEstate)
        {
            return realEstates.Contains(realEstate);
        }

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

        public void Sort(RealEstateComparator comparator)
        {
            realEstates.Sort(comparator);
        }

        public void Sort()
        {
            realEstates.Sort();
        }
    }
}
