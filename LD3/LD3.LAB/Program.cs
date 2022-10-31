using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;

namespace LD3.LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // constants of which houses to pick out
            const string type = "mūrinis";
            const double area = 100;

            // reads all houses to their respective companies
            HouseRegister Company1 = InOutUtils.ReadHouses(@"Houses.csv");
            HouseRegister Company2 = InOutUtils.ReadHouses(@"Houses2.csv");

            if(Company1.Count() != 0 || Company2.Count() != 0)
            {
                // prints initial info to txt
                File.WriteAllText(@"Initial.txt", String.Empty);
                InOutUtils.PrintHousesToTxt(@"Initial.txt", Company1);
                InOutUtils.PrintHousesToTxt(@"Initial.txt", Company2);

                // prints initial info to console
                InOutUtils.PrintHouses("Pirmoji agentūra", Company1);
                InOutUtils.PrintHouses("Antroji agentūra", Company2);

                // gets and prints all oldest houses
                HouseRegister OldestHouses = Company1.GetOldestHouses(Company2);
                InOutUtils.PrintOldestHouses("Seniausi namai", OldestHouses);

                // gets and prints all most sold streets
                List<string> Streets = Company1.GetMostSoldStreets(Company2);
                int[] streetCounts = Company1.GetStreetCount(Company2);
                int maxVal = streetCounts.Max();
                InOutUtils.PrintMostSoldStreets("Daugiausiai parduodamos gatvės", Streets, maxVal);

                // gets and prints all houses that intersect to csv
                HouseRegister Intersecting = Company1.Intersects(Company2);
                if (Intersecting != null)
                {
                    InOutUtils.PrintToCSVFile("Namai, parduodami abejose agenturose:", @"Kartojasi.csv", Intersecting);
                }
                else
                {
                    Console.WriteLine("Namų, parduodamų abejose agentūrose, nėra");
                }

                // get and prints all houses that are a certain type and area to a csv
                HouseRegister HousesTypeOverArea = Company1.GetMHousesOverN(type, area, Company2);
                if(HousesTypeOverArea != null)
                {
                    InOutUtils.PrintToCSVFile("Namai, " + type + " tipo ir didesni už " + area, @"M100.csv", HousesTypeOverArea);
                }
                else
                {
                    Console.WriteLine("Namų, " + type + " tipo ir didesnų už " + area + "nėra");
                }
            }
            else
            {
                Console.WriteLine("Nepakanka duomenų");
            }
        }
    }
}
