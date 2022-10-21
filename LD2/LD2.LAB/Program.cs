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
            const double n = 100; // constans of area

            HouseList Company1 = InOutUtils.ReadHouses(@"Houses.csv"); // gets company 1 info
            HouseList Company2 = InOutUtils.ReadHouses(@"Houses2.csv"); // gets company 2 info

            if (Company1 != null && Company2 != null)
            {
                // prints both companies and their sold houses
                InOutUtils.PrintHouses(Company1);
                InOutUtils.PrintHouses(Company2);

                // prints all start info into txt file
                File.WriteAllText(@"startInfo.txt", String.Empty);
                InOutUtils.PrintHousesToTxt(@"startInfo.txt", Company1);
                InOutUtils.PrintHousesToTxt(@"startInfo.txt", Company2);

                // gets and prints most sold streets
                List<SellingSt> houseList = Company1.GetMostSoldStreets(Company1, Company2);
                InOutUtils.PrintStreet(houseList);

                // gets and prints oldest houses
                HouseList MinAge = new HouseList();
                InOutUtils.PrintStreets(MinAge.GetOldestHouses(Company1, Company2));

                File.WriteAllText(@"M100.csv", string.Empty);
                HouseList BrickOverN1 = Company1.FindBrickHousesOverN(n);
                HouseList BrickOverN2 = Company2.FindBrickHousesOverN(n);
                // prints houses if any one of them has elements
                if (BrickOverN1 != null && BrickOverN2 != null)
                {
                    InOutUtils.PrintHousesToCSV(BrickOverN1, BrickOverN2, @"M100.csv");
                }
                else
                {
                    Console.WriteLine("Mūrinių namų, didesnio ploto už n nerasta");
                }
            }
            else 
            {
                Console.WriteLine("Nepakanka duomenų");
            }
            Console.ReadLine();
        }
    }
}
