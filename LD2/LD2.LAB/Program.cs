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
            HouseList AllHouses = InOutUtils.ReadHouses(@"Houses.csv");
            InOutUtils.PrintHouses(AllHouses);
        }
    }
}
