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
        private RealEstateContainer realEstate;

        public Register(string agencyName, string agencyAdress, string agencyCell)
        {
            AgencyName = agencyName;
            AgencyAdress = agencyAdress;
            AgencyCell = agencyCell;
            realEstate = new RealEstateContainer();
        }

        public Register()
        {
            realEstate = new RealEstateContainer();
        }

        public void Add(RealEstate realEstate)
        {
            this.realEstate.Add(realEstate);
        }

        public RealEstate Get(int index)
        {
            return realEstate.Get(index);
        }

        public int Count()
        {
            return realEstate.Count();
        }
    }
}
