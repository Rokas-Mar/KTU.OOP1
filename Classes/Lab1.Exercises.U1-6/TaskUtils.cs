using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.U1_6
{
    internal class TaskUtils
    {
        /// <summary>
        /// Finds oldest build date of house list
        /// </summary>
        /// <param name="Houses">List of houses</param>
        /// <returns>Build date of the oldest house</returns>
        public static DateTime FindOldestYear(List<House> Houses)
        {             DateTime oldest = DateTime.MaxValue;
            foreach (House house in Houses)
            {
                if (house.BuildYear < oldest)
                {
                    oldest = house.BuildYear;
                }
            }

            return oldest;
        }

        /// <summary>
        /// Finds oldest houses by camparing them to the oldest build date
        /// </summary>
        /// <param name="Houses">List of houses</param>
        /// <returns>A list of oldest houses</returns>
        public static List<House> GetOldestHouse(List<House> Houses)
        {
            List<House> oldestHouses = new List<House>();
            DateTime oldest = FindOldestYear(Houses);

            foreach (House house in Houses)
            {
                if (oldest == house.BuildYear)
                {
                    oldestHouses.Add(house);
                }
            }

            return oldestHouses;
        }

        /// <summary>
        /// Makes a list of streets with no duplicates
        /// </summary>
        /// <param name="Houses">List of houses</param>
        /// <returns>returns a string list of streets</returns>
        public static List<string> FindStreets(List<House> Houses)
        {
            List<string> Streets = new List<string>();

            foreach(House house in Houses)
            {
                string street = house.StreetName;
                if(!Streets.Contains(street))
                {
                    Streets.Add(street);
                }
            }

            return Streets;
        }

        /// <summary>
        /// Calculates how much houses are in each street
        /// </summary>
        /// <param name="Houses">List of houses</param>
        /// <param name="StreetCount">int array of how much the street name reoccures</param>
        /// <param name="Streets">List of streets with no duplicates</param>
        private static void StreetsAndCount(List<House> Houses, out int[] StreetCount, out List<string> Streets)
        {
            Streets = TaskUtils.FindStreets(Houses);
            StreetCount = new int[Streets.Count];

            for (int i = 0; i < Streets.Count; i++)
            {
                for (int j = 0; j < Houses.Count; j++)
                {
                    if (Streets[i] == Houses[j].StreetName)
                    {
                        StreetCount[i]++;
                    }
                }
            }
        }

        /// <summary>
        /// Finds streets which have the most houses for sale in them
        /// </summary>
        /// <param name="Houses">List of houses</param>
        /// <returns>A list of collected streets</returns>
        public static List<Street> MostSellingStreets(List<House> Houses)
        {
            int[] StreetCount;
            List<string> Streets;
            List<Street> MostSellingSt = new List<Street>();

            StreetsAndCount(Houses, out StreetCount, out Streets);

            int maxValue = StreetCount.Max();

            for (int i = 0; i < Streets.Count; i++)
            {
                if (StreetCount[i] == maxValue)
                {
                    Street street = new Street(Streets[i], StreetCount[i]);
                    MostSellingSt.Add(street);
                }
            }

            return MostSellingSt;
        }

        /// <summary>
        /// Finds brick houses which area is bigger than 100 q.m.
        /// </summary>
        /// <param name="Houses">List of houses</param>
        /// <returns>A list of collected houses</returns>
        public static List<House> FindBrickOver100Area(List<House> Houses)
        {
            List<House> foundHouses = new List<House>();

            foreach(House house in Houses)
            {
                if(house.HouseType.ToLower() == "mūrinis")
                {
                    if(house.HouseArea > 100)
                    {
                        foundHouses.Add(house);
                    }
                }
            }

            return foundHouses;
        }
    }
}
