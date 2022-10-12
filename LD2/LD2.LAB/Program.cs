using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD2.LAB
{
    /// <summary>
    /// Main Class
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            const double n = 100; // const of area

            HouseList Company1 = InOutUtils.ReadHouses(@"Houses.csv"); // gets company 1 info
            HouseList Company2 = InOutUtils.ReadHouses(@"Houses2.csv"); // gets company 2 info
            // prints both companies and their sold houses
            InOutUtils.PrintHouses(Company1);
            InOutUtils.PrintHouses(Company2);

            // combines company houses
            HouseList CombinedHouses = new HouseList();
            CombinedHouses = CombinedHouses.Combine(Company1, Company2);

            // gets and prints most sold streets
            List<SellingSt> SellingSts = CombinedHouses.GetMostSellingSt();
            InOutUtils.PrintStreet(SellingSts);

            // gets and prints oldest houses
            List<House> MinAge = CombinedHouses.GetOldestHouses();
            InOutUtils.PrintStreets(MinAge);

            // finds and prints to file brick houses that are over n area
            File.WriteAllText(@"M100.csv", String.Empty);
            List<House> BrickOverN = CombinedHouses.FindBrickHousesOverN(n);
            InOutUtils.PrintHousesToCSV(BrickOverN, @"M100.csv");

            Console.ReadLine();
        }
    }
}
