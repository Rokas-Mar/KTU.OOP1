using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string InitialData1 = @"Agency1.csv";
            const string InitialData2 = @"Agency2.csv";
            const string InitialData3 = @"Agency3.csv";
            const string Intersecting = @"Kartojasi.csv";
            const string HousesFile = @"Namas100.csv";
            const string FlatsFile = @"Butas50.csv";

            Register Agency1 = InOutUtils.ReadAgencyInfo(InitialData1);
            InOutUtils.PrintRealEstate(Agency1, "Pirmoji agentura");

            Register Agency2 = InOutUtils.ReadAgencyInfo(InitialData2);
            InOutUtils.PrintRealEstate(Agency2, "Antroji agentura");

            Register Agency3 = InOutUtils.ReadAgencyInfo(InitialData3);
            InOutUtils.PrintRealEstate(Agency3, "Trecioji agentura");

            List<Register> Agencies = new List<Register>() { Agency1, Agency2, Agency3 };

            StreetsContainer Streets = TaskUtils.GetMostSoldStreets(Agencies);
            InOutUtils.PrintStreets(Streets);

            Register OldestHouses = TaskUtils.GetOldestHouses(Agencies);
            InOutUtils.PrintRealEstate(OldestHouses, "Oldest Houses");

            Register IntersectingHouses = TaskUtils.IntersectingEntries(Agencies);
            IntersectingHouses.Sort();
            InOutUtils.PrintToCSV(Intersecting, IntersectingHouses);
        }
    }
}
