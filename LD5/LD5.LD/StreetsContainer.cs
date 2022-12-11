using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class StreetsContainer
    {
        private List<Street> StreetList;

        public StreetsContainer()
        {
            StreetList = new List<Street>();
        }

        public void Add(Street street)
        {
            StreetList.Add(street);
        }

        public Street Get(int index)
        {
            return StreetList[index];
        }

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

        public void AddCount(int index)
        {
            if(!(index < 0))
            StreetList[index].Count++;
        }

        public int Count()
        {
            return StreetList.Count;
        }

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
