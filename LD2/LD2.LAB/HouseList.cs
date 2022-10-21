using System;
using System.Collections.Generic;
using System.Globalization;
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
        private List<SellingSt> AllStreets;

        public HouseList(string companyName, string companyAdress, string companyCell, List<House> allHouses, List<SellingSt> allStreets)
        {
            CompanyName = companyName;
            CompanyAdress = companyAdress;
            CompanyCell = companyCell;
            AllHouses = allHouses;
            AllStreets = allStreets;
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
        /// Add overload to append AllStreets List
        /// </summary>
        /// <param name="house"></param>
        public void Add(SellingSt house)
        {
            AllStreets.Add(house);
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
        /// Gets AllStreets count
        /// </summary>
        /// <returns>AllStreets count</returns>
        public int StreetCount()
        {
            return AllStreets.Count();
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
        /// Gets a street from List with the same index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public SellingSt GetIndexedStreet(int index)
        {
            return AllStreets[index];
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
        public DateTime FindMinAge(HouseList Company1, HouseList Company2)
        {
            DateTime date = DateTime.MaxValue;
            HouseList Check = Company1;
            int n = Company1.HouseCount();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Check.GetIndexedDate(j) < date)
                    {
                        date = Check.GetIndexedDate(j);
                    }
                }
                n = Company2.HouseCount();
                Check = Company2;
            }

            return date;
        }

        /// <summary>
        /// Gets the oldest houses by index
        /// </summary>
        /// <returns>List of oldest houses</returns>
        public HouseList GetOldestHouses(HouseList Company1, HouseList Company2)
        {
            DateTime date = this.FindMinAge(Company1, Company2);
            HouseList Houses = new HouseList();
            int n = Company1.HouseCount();
            HouseList Check = Company1;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (Check.GetIndexedDate(j) == date)
                    {

                        Houses.Add((House)Check.GetIndexedElement(j));
                    }
                }
                n = Company2.HouseCount();
                Check = Company2;
            }
            return Houses;
        }

        /// <summary>
        /// Gets streets with no repetitions of AllHouses
        /// </summary>
        /// <returns>List of houses</returns>
        public List<string> GetStreets(HouseList Company1, HouseList Company2)
        {
            List<string> Streets = new List<string>();
            HouseList Temp = Company1;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < Temp.HouseCount(); j++)
                {
                    if (!Streets.Contains(Temp.GetIndexedElement(j).Street))
                    {
                        Streets.Add(Temp.GetIndexedElement(j).Street);
                    }
                }
                Temp = Company2;
            }
            return Streets;
        }

        /// <summary>
        /// Counts houses in streets
        /// </summary>
        /// <returns>list of intigers of how much houses are in each street</returns>
        public int[] CountMostSoldSt(HouseList Company1, HouseList Company2)
        {
            List<string> Streets = this.GetStreets(Company1, Company2);
            HouseList Temp = Company1;
            int[] StreetCount = new int[Streets.Count()];
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < Streets.Count(); i++)
                {
                    for (int j = 0; j < Temp.HouseCount(); j++)
                    {
                        if (Streets[i] == Temp.GetIndexedElement(j).Street)
                        {
                            StreetCount[i]++;
                        }
                    }
                }
                Temp = Company2;
            }
            return StreetCount;
        }
        
        /// <summary>
        /// Gets all most sold streets and puts them in a list
        /// </summary>
        /// <param name="Company1">HouseList element</param>
        /// <param name="Company2">HouseList element</param>
        /// <returns>SellingSt List of streets and their count</returns>
        public List<SellingSt> GetMostSoldStreets(HouseList Company1, HouseList Company2)
        {
            HouseList Temp = new HouseList();
            List<SellingSt> SoldStreets = new List<SellingSt>();
            int[] StreetCount = Temp.CountMostSoldSt(Company1, Company2);
            List<string> Streets = Temp.GetStreets(Company1, Company2);
            int maxCount = StreetCount.Max();
            for (int i = 0; i < Streets.Count; i++)
            {
                if(StreetCount[i] == maxCount)
                {
                    SellingSt street = new SellingSt(Streets[i], StreetCount[i]);
                    SoldStreets.Add(street);
                }
            }
            return SoldStreets;
        }

        /// <summary>
        /// Finds streets which are made of brick and over n area
        /// </summary>
        /// <param name="n">area</param>
        /// <returns>List of houses</returns>
        public HouseList FindBrickHousesOverN(double n)
        {
            HouseList houses = new HouseList();

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
