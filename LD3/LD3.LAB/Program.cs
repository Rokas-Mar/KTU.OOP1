using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD3.LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HouseRegister Company1 = InOutUtils.ReadHouses(@"Houses.csv");
            HouseRegister Company2 = InOutUtils.ReadHouses(@"Houses2.csv");

            if(Company1.Count() != 0 || Company2.Count() != 0)
            {
                File.WriteAllText(@"Initial.txt", String.Empty);
                InOutUtils.PrintHousesToTxt(@"Initial.txt", Company1);
                InOutUtils.PrintHousesToTxt(@"Initial.txt", Company2);
                InOutUtils.PrintHouses("Pirmoji agentūra", Company1);
                InOutUtils.PrintHouses("Antroji agentūra", Company2);
                HouseRegister OldestHouses = Company1.GetOldestHouses(Company2);
                InOutUtils.PrintOldestHouses("Seniausi namai", OldestHouses);

                List<string> Streets = Company1.GetMostSoldStreets(Company2);
                int[] streetCounts = Company1.GetStreetCount(Company2);
                int maxVal = streetCounts.Max();
                InOutUtils.PrintMostSoldStreets("Daugiausiai parduodamos gatvės", Streets, maxVal);

                HouseRegister Intersecting = Company1.Intersects(Company2);
                if (Intersecting != null)
                {
                    InOutUtils.PrintToCSVFile("Namai, parduodami abejose agenturose:", @"Kartojasi.csv", Intersecting);
                }
                else
                {
                    Console.WriteLine("Namų, parduodamų abejose agentūrose, nėra");
                }
            }
            else
            {
                Console.WriteLine("Nepakanka duomenų");
            }
        }
    }
}
