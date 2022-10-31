using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LD3.LAB
{
    internal class HouseRegister
    {
        public string Company { get; set; }
        public string Adress { get; set; }
        public string Cell { get; set; }
        private HouseContainer Houses;

        public HouseRegister(string company, string adress, string cell)
        {
            Company = company;
            Adress = adress;
            Cell = cell;
            this.Houses = new HouseContainer();
        }

        public HouseRegister()
        {
            this.Houses = new HouseContainer();
        }

        public void Add(House element)
        {
            this.Houses.Add(element);
        }

        public House Get(int index)
        {
            return Houses.Get(index);
        }

        public int Count()
        {
            return this.Houses.Count;
        }

        public bool Contains(House house)
        {
            return this.Houses.Contains(house);
        }

        public DateTime FindOldestDate(HouseRegister Company)
        {
            DateTime date = DateTime.MaxValue;
            HouseRegister Temp = this;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < Temp.Count(); j++)
                {
                    House house = Temp.Get(j);
                    if (house < date)
                    {
                        date = house.BuildDate;
                    }
                }
                Temp = Company;
            }
            return date;
        }

        public HouseRegister GetOldestHouses(HouseRegister Company)
        {
            DateTime date = this.FindOldestDate(Company);
            HouseRegister Temp = this;
            HouseRegister Found = new HouseRegister();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Temp.Count(); j++)
                {
                    House house = Temp.Get(j);
                    if (house.BuildDate == date && !Found.Contains(house))
                    {
                        Found.Add(house);
                    }
                }
                Temp = Company;
            }
            return Found;
        }

        public List<string> GetStreets(HouseRegister Company)
        {
            List<string> Streets = new List<string>();
            HouseRegister Temp = this;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < Temp.Count(); j++)
                {
                    House house = Temp.Get(j);
                    if(!Streets.Contains(house.Street))
                    {
                        Streets.Add(house.Street);
                    }
                }
            }
            return Streets;
        }

        public int[] GetStreetCount(HouseRegister Company)
        {
            List<string> Streets = this.GetStreets(Company);
            HouseRegister Temp = this;
            int count = this.Count();
            int[] streetCount = new int[Streets.Count()];
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < Streets.Count(); j++)
                {
                    for(int k = 0; k < count; k++)
                    {
                        if(Streets[j] == Temp.Get(k))
                        {
                            streetCount[j]++;
                        }
                    }
                }
                Temp = Company;
                count = Company.Count();
            }    
            return streetCount;
        }

        public List<string> GetMostSoldStreets(HouseRegister Company)
        {
            List<string> Found = new List<string>();
            List<string> Streets = this.GetStreets(Company);
            int[] streetCount = this.GetStreetCount(Company);
            int maxVal = streetCount.Max();
            for (int k = 0; k < streetCount.Count(); k++)
            {
                if (streetCount[k] == maxVal)
                {
                    Found.Add(Streets[k]);
                }
            }
            return Found;
        }

        public HouseRegister Intersects(HouseRegister Company)
        {
            HouseRegister houseRegister = new HouseRegister();
            for(int i = 0; i < Company.Count(); i++)
            {
                House house = Company.Get(i);
                if (this.Houses.Contains(house))
                {
                    houseRegister.Add(Company.Get(i));
                }
            }
            return houseRegister;
        }

        public HouseRegister GetMHousesOverN(string type, double area, HouseRegister Company)
        {
            HouseRegister Filtered = new HouseRegister();
            HouseRegister Temp = this;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < Temp.Count(); j++)
                {
                    House house = Temp.Get(j);
                    if(house.Type.ToLower().Trim() == type.ToLower().Trim() && house.Area > area)
                    {
                        if (!Filtered.Contains(house))
                        {
                            Filtered.Add(house);
                        }
                    }
                }
                Temp = Company;
            }
            return Filtered;
        }
    }
}
