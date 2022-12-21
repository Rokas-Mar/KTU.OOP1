using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD5.LD
{
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        static void Main(string[] args)
        {
            // Constant input and output files
            const string InitialData1 = @"Agency1.csv";
            const string InitialData2 = @"Agency2.csv";
            const string InitialData3 = @"Agency3.csv";
            const string Intersecting = @"Kartojasi.csv";
            const string HousesFile = @"Namas100.csv";
            const string FlatsFile = @"Butas50.csv";
            const string InitialData = @"InitialData.txt";

            const double HouseArea = 100;
            const double FlatArea = 50;

            // Reads all agency info
            Register Agency1 = InOutUtils.ReadAgencyInfo(InitialData1);
            Register Agency2 = InOutUtils.ReadAgencyInfo(InitialData2);
            Register Agency3 = InOutUtils.ReadAgencyInfo(InitialData3);

            // Process if at least one Agency has elements
            if (Agency1.Count() > 0 || Agency2.Count() > 0 || Agency3.Count() > 0)
            {
                // Prints all agency info to console and txt file
                InOutUtils.PrintRealEstate(Agency1, "Pirmoji agentura");
                InOutUtils.PrintRealEstate(Agency2, "Antroji agentura");
                InOutUtils.PrintRealEstate(Agency3, "Trecioji agentura");
                InOutUtils.PrintInitial(InitialData, Agency1, Agency2, Agency3);

                // Gets most sold streets and prints them
                StreetsContainer Streets = TaskUtils.GetMostSoldStreets(Agency1, Agency2, Agency3);
                InOutUtils.PrintStreets(Streets);

                // Gets oldest houses and prints them
                Register OldestHouses = TaskUtils.GetOldestHouses(Agency1, Agency2, Agency3);
                InOutUtils.PrintRealEstateList(OldestHouses, "Oldest Houses");

                // Gets all intersecting houses, sorts them and prints them to csv file
                Register IntersectingHouses = TaskUtils.IntersectingEntries(Agency1, Agency2, Agency3);
                if (IntersectingHouses.Count() > 0)
                {
                    IntersectingHouses.Sort();
                    InOutUtils.PrintToCSV(Intersecting, IntersectingHouses);
                }
                else
                {
                    Console.WriteLine("No intersecting real estate found");
                }

                // Gets real estate that is House type and over HouseArea area
                Register HousesOver100 = TaskUtils.CollectEstateOverArea(Agency1, Agency2, Agency3, typeof(House), HouseArea);
                if (HousesOver100.Count() > 0)
                {
                    HousesOver100.Sort(new ComparatorByArea_RoomCount());
                    InOutUtils.PrintToCSV(HousesFile, HousesOver100);
                }
                else
                {
                    Console.WriteLine("Houses over 100 sq. m. don't exist...");
                    File.WriteAllText(HousesFile, "");
                }

                // Gets real estate that is Flat type and over FlatArea area
                Register FlatsOver50 = TaskUtils.CollectEstateOverArea(Agency1, Agency2, Agency3, typeof(Flat), FlatArea);
                if (FlatsOver50.Count() > 0)
                {
                    FlatsOver50.Sort(new ComparatorByArea_RoomCount());
                    InOutUtils.PrintToCSV(FlatsFile, FlatsOver50);
                }
                else
                {
                    Console.WriteLine("Flats over 50 sq. m. don't exist...");
                    File.WriteAllText(FlatsFile, "");
                }
            }
            else
            {
                Console.WriteLine("All agency files are empty");
            }
        }
    }
}
