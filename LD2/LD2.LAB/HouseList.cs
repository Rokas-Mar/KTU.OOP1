using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LD2.LAB
{
    internal class HouseList
    {
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public string CompanyCell { get; set; }

        private List<House> AllHouses;

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

        public void Add(House house)
        {
            AllHouses.Add(house);
        }

        public int HouseCount()
        {
            return AllHouses.Count();
        }

        public House GetIndexedElement(int index)
        {
            return AllHouses[index];
        }

        public DateTime GetIndexedDate(int index)
        {
            return AllHouses[index].BuildDate;
        }

        public House FindMinAge()
        {
            DateTime date = DateTime.MaxValue;
            House oldest = new House();

            foreach(House house in AllHouses)
            {
                if(house.BuildDate < date)
                {
                    date = house.BuildDate;
                    oldest = house;
                }
            }
            return oldest;
        }

        public List<string> GetSteets()
        {
            List<string> Streets = new List<string>();
            foreach(House house in AllHouses)
            {
                if(!Streets.Contains(house.Street))
                {
                    Streets.Add(house.Street);
                }    
            }

            return Streets;
        }

        public int[] CountMostSoldSt()
        {
            List<string> Streets = this.GetSteets();

            int[] StreetCount = new int[Streets.Count()];
            for(int i = 0; i < Streets.Count(); i++)
            {
                for(int j = 0; j < AllHouses.Count(); j++)
                {
                    if (Streets[i] == AllHouses[j].Street)
                    {
                        StreetCount[i]++;
                    }
                }
            }
            return StreetCount;
        }

        public List<House> GetMostSellingSt()
        {
            int[] StreetCount = this.CountMostSoldSt();
            List<string> Streets = this.GetSteets();
            List<House> MostSoldStreets = new List<House>();
            int maxVal = StreetCount.Max();

            for(int i = 0; i < AllHouses.Count(); i++)
            {
                if (StreetCount[i] == maxVal)
                {
                    MostSoldStreets.Add(AllHouses[i]);
                }    
            }
            return MostSoldStreets;
        }
    }
}
