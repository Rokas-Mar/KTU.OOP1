using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
