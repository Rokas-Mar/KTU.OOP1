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

            // Reads all agency info
            Register Agency1 = InOutUtils.ReadAgencyInfo(InitialData1);
            Register Agency2 = InOutUtils.ReadAgencyInfo(InitialData2);
            Register Agency3 = InOutUtils.ReadAgencyInfo(InitialData3);

            // Process
            if (Agency1.Count() > 0 && Agency2.Count() > 0 && Agency3.Count() > 0)
            {
                InOutUtils.PrintRealEstate(Agency1, "Pirmoji agentura");
                InOutUtils.PrintRealEstate(Agency2, "Antroji agentura");
                InOutUtils.PrintRealEstate(Agency3, "Trecioji agentura");

                List<Register> Agencies = new List<Register>() { Agency1, Agency2, Agency3 };

                StreetsContainer Streets = TaskUtils.GetMostSoldStreets(Agencies);
                InOutUtils.PrintStreets(Streets);

                Register OldestHouses = TaskUtils.GetOldestHouses(Agencies);
                InOutUtils.PrintRealEstateList(OldestHouses, "Oldest Houses");

                Register IntersectingHouses = TaskUtils.IntersectingEntries(Agencies);
                IntersectingHouses.Sort();
                InOutUtils.PrintToCSV(Intersecting, IntersectingHouses);

                Register HousesOver100 = TaskUtils.CollectHousesOver100(Agencies);
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

                Register FlatsOver50 = TaskUtils.CollectFlatsOver50(Agencies);
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
