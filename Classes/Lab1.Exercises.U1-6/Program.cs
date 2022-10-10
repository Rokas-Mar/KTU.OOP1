using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.U1_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<House> AllHouses = InOutUtils.ReadAllHouses(@"Houses.csv"); // Main variable of all houses
            if (AllHouses.Count > 0)
            {
                InOutUtils.PrintToTXTFile("StartingData.txt", AllHouses);
                List<string> Streets = TaskUtils.FindStreets(AllHouses);
                List<Street> MostSellingSt = TaskUtils.MostSellingStreets(AllHouses);
                List<House> BrickHouses = TaskUtils.FindBrickOver100Area(AllHouses);
                InOutUtils.PrintHouses(AllHouses);
                Console.WriteLine("");
                InOutUtils.PrintOldestHouses(TaskUtils.GetOldestHouse(AllHouses));
                Console.WriteLine("");
                InOutUtils.PrintMostSellingSt(MostSellingSt);
                if (BrickHouses.Count > 0)
                {
                    InOutUtils.PrintToCSVFile("BrickHousesAreaOver100.csv", BrickHouses);
                }
            }
            else
            {
                Console.WriteLine("Sąrašas tuščias");
            }
        }
    }
}
