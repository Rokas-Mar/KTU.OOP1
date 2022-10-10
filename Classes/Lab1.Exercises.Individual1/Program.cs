using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1.Exercises.Individual1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tourist> allTourists = InOutUtils.ReadAllTourists(@"Tourists.csv");
            List<Tourist> BiggestDoners = new List<Tourist>();
            if (allTourists.Count() > 0)
            {
                InOutUtils.PrintAllTourists(allTourists);
                BiggestDoners = TaskUtils.BiggestDonators(allTourists);
                if (BiggestDoners.Count() > 0)
                {
                    InOutUtils.PrintToCSVFile("TopDonators.csv", BiggestDoners, TaskUtils.CashCollected(allTourists));
                }
                else
                {
                    File.WriteAllText(@"Tourists.csv", "Nerasta");
                }
            }
            else
            {
                Console.WriteLine("Failas tuščias");
            }
        }
    }
}
