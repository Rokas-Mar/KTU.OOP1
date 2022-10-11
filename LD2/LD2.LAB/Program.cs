using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HouseList Company1 = InOutUtils.ReadHouses(@"Houses.csv");
            HouseList Company2 = InOutUtils.ReadHouses(@"Houses2.csv");
            InOutUtils.PrintHouses(Company1);
            InOutUtils.PrintHouses(Company2);

            int maxVal = Company1.CountMostSoldSt().Max();
            if(Company1.CountMostSoldSt().Max() > Company2.CountMostSoldSt().Max())
            {

            }

            House oldest1 = Company1.FindMinAge();
            House oldest2 = Company2.FindMinAge();

            if(oldest1 < oldest2)
            {
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(oldest1.BuildDate.ToString("yyyyMMdd"));
                int age = (now - dob) / 10000;
                InOutUtils.PrintHouse(oldest1, age);
            }
            else
            {
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(oldest2.BuildDate.ToString("yyyyMMdd"));
                int age = (now - dob) / 10000;
                InOutUtils.PrintHouse(oldest2, age);
            }

            Console.ReadLine();
        }
    }
}
