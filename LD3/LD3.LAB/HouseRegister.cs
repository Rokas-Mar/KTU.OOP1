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
    /// <summary>
    /// House register class
    /// </summary>
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

        /// <summary>
        /// Link to Container Add()
        /// </summary>
        /// <param name="element">element to add to container</param>
        public void Add(House element)
        {
            this.Houses.Add(element);
        }

        /// <summary>
        /// Link to Container Get()
        /// </summary>
        /// <param name="index">index of which element to get</param>
        /// <returns>House element</returns>
        public House Get(int index)
        {
            return Houses.Get(index);
        }

        /// <summary>
        /// Link to Container Put()
        /// </summary>
        /// <param name="element">element to put</param>
        /// <param name="index">where to put the element</param>
        public void Put(House element, int index)
        {
            Houses.Put(element, index);
        }
        
        /// <summary>
        /// Link to Container Insert()
        /// </summary>
        /// <param name="element">element to insert</param>
        /// <param name="index">where to insert</param>
        public void Insert(House element, int index)
        {
            Houses.Insert(element, index);
        }

        /// <summary>
        /// Link to Container Remove()
        /// </summary>
        /// <param name="element">which element to remove</param>
        public void Remove(House element)
        {
            Houses.Remove(element);
        }

        /// <summary>
        /// Link to Container RemoveAt()
        /// </summary>
        /// <param name="index">which index to remove</param>
        public void RemoveAt(int index)
        {
            Houses.RemoveAt(index);
        }

        /// <summary>
        /// Link to Container Count
        /// </summary>
        /// <returns>Container Count element</returns>
        public int Count()
        {
            return this.Houses.Count;
        }

        /// <summary>
        /// Link to Container Contains()
        /// </summary>
        /// <param name="house">House element</param>
        /// <returns>true if Container contains element</returns>
        public bool Contains(House house)
        {
            return this.Houses.Contains(house);
        }

        /// <summary>
        /// Finds the oldest house build date
        /// </summary>
        /// <param name="Company">Second company</param>
        /// <returns>DateTime element of oldest house build date</returns>
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

        /// <summary>
        /// Gets the oldest houses
        /// </summary>
        /// <param name="Company">Second Company</param>
        /// <returns>HouseRegister of oldest houses</returns>
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

        /// <summary>
        /// Gets streets with no repetitions
        /// </summary>
        /// <param name="Company">Second company</param>
        /// <returns>List of street names</returns>
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
                Temp = Company;
            }
            return Streets;
        }

        /// <summary>
        /// Gets how much a specific street is repeated
        /// </summary>
        /// <param name="Company">Second company</param>
        /// <returns>Array of ints with all street repetitions</returns>
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

        /// <summary>
        /// Gets most sold streets
        /// </summary>
        /// <param name="Company">Second company</param>
        /// <returns>List of all most sold streets</returns>
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

        /// <summary>
        /// Finds all houses that appear in both companies
        /// </summary>
        /// <param name="Company">Second company</param>
        /// <returns>HouseRegister of all intersecting houses</returns>
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

        /// <summary>
        /// Gets all houses that are a certain type and are above a certain area
        /// </summary>
        /// <param name="type">const type</param>
        /// <param name="area">const area</param>
        /// <param name="Company">Second company</param>
        /// <returns>HouseRegister of found houses</returns>
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

        /// <summary>
        /// Link to Container Sort()
        /// </summary>
        public void Sort()
        {
            Houses.Sort();
        }
    }
}
