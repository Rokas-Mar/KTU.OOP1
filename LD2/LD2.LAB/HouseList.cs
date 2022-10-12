using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LD2.LAB
{
    /// <summary>
    /// Class of calculations that include House class
    /// </summary>
    internal class HouseList
    {
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public string CompanyCell { get; set; } // Company cellphone

        private List<House> AllHouses; // List of house class elements

        public HouseList(string companyName, string companyAdress, string companyCell, List<House> allHouses)
        {
            CompanyName = companyName;
            CompanyAdress = companyAdress;
            CompanyCell = companyCell;
            AllHouses = allHouses;
        }

        public HouseList()
        {
            AllHouses = new List<House>();
        }

        /// <summary>
        /// Add method overload to append AllHouses List
        /// </summary>
        /// <param name="house">House class element</param>
        public void Add(House house)
        {
            AllHouses.Add(house);
        }

        /// <summary>
        /// Calculates the count of houses in AllHouses List
        /// </summary>
        /// <returns>int count of houses in the list</returns>
        public int HouseCount()
        {
            return AllHouses.Count();
        }

        /// <summary>
        /// Gets an element from List with same index
        /// </summary>
        /// <param name="index">which element to get</param>
        /// <returns>House element</returns>
        public House GetIndexedElement(int index)
        {
            return AllHouses[index];
        }
        
        /// <summary>
        /// Gets indexed element date
        /// </summary>
        /// <param name="index">which element to get</param>
        /// <returns>date of an indexed element</returns>
        public DateTime GetIndexedDate(int index)
        {
            return AllHouses[index].BuildDate;
        }

        /// <summary>
        /// Finds the minimum age of AllHouses List
        /// </summary>
        /// <returns>min age of AllAHouses</returns>
        public DateTime FindMinAge()
        {
            DateTime date = DateTime.MaxValue;

            foreach (House house in AllHouses)
            {
                if (house.BuildDate < date)
                {
                    date = house.BuildDate;
                }
            }

            return date;
        }

        /// <summary>
        /// Gets the oldest houses by index
        /// </summary>
        /// <returns>List of oldest houses</returns>
        public List<House> GetOldestHouses()
        {
            DateTime date = this.FindMinAge();
            List<House> Houses = new List<House>();
            foreach (House house in AllHouses)
            {
                if (house.BuildDate == date)
                {
                    Houses.Add(house);
                }
            }
            return Houses;
        }

        /// <summary>
        /// Combunes two company houses into one list
        /// </summary>
        /// <param name="Company1">Company 1</param>
        /// <param name="Company2">Company 2</param>
        /// <returns>List of combined houses in both companies</returns>
        public HouseList Combine(HouseList Company1, HouseList Company2)
        {
            HouseList Houses = Company1;

            for(int i = 0; i < Company2.HouseCount(); i++)
            {
                Houses.Add(Company2.GetIndexedElement(i));
            }
            return Houses;
        }

        /// <summary>
        /// Gets streets with no repetitions of AllHouses
        /// </summary>
        /// <returns>List of houses</returns>
        public List<string> GetSteets()
        {
            List<string> Streets = new List<string>();
            foreach (House house in AllHouses)
            {
                if (!Streets.Contains(house.Street))
                {
                    Streets.Add(house.Street);
                }
            }

            return Streets;
        }

        /// <summary>
        /// Counts houses in streets
        /// </summary>
        /// <returns>list of intigers of how much houses are in each street</returns>
        public int[] CountMostSoldSt()
        {
            List<string> Streets = this.GetSteets();

            int[] StreetCount = new int[Streets.Count()];
            for (int i = 0; i < Streets.Count(); i++)
            {
                for (int j = 0; j < AllHouses.Count(); j++)
                {
                    if (Streets[i] == AllHouses[j].Street)
                    {
                        StreetCount[i]++;
                    }
                }
            }
            return StreetCount;
        }

        /// <summary>
        /// gets most selling street list
        /// </summary>
        /// <returns>list of selling streets</returns>
        public List<SellingSt> GetMostSellingSt()
        {
            int[] StreetCount = this.CountMostSoldSt();
            List<string> Streets = this.GetSteets();
            List<SellingSt> MostSoldStreets = new List<SellingSt>();
            int maxVal = StreetCount.Max();

            for (int i = 0; i < Streets.Count(); i++)
            {
                if (StreetCount[i] == maxVal)
                {
                    SellingSt street = new SellingSt(Streets[i], StreetCount[i]);
                    MostSoldStreets.Add(street);
                }
            }
            return MostSoldStreets;
        }

        /// <summary>
        /// Finds streets which are made of brick and over n area
        /// </summary>
        /// <param name="n">area</param>
        /// <returns>List of houses</returns>
        public List<House> FindBrickHousesOverN(double n)
        {
            List<House> houses = new List<House>();

            for(int i = 0; i < AllHouses.Count; i++)
            {
                if (AllHouses[i].Area > n)
                {
                    if(AllHouses[i].Type.Trim().ToLower() == "mūrinis")
                    {
                        houses.Add(AllHouses[i]);
                    }
                }
            }
            return houses;
        }
    }
}
