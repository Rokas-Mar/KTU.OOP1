using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Register.Individual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlatList allFlats = InOutUtils.ReadFlats(@"Flats.csv");

            InOutUtils.PrintFlats(allFlats);

            Console.WriteLine("Iveskite norimą kambarių skaičių, norimų aukštų intervalą ir maksimalią kainą");
            string requestedRoomCount = Console.ReadLine();
            int roomCount = Convert.ToInt32(requestedRoomCount);
            string requestedFloorStart = Console.ReadLine();
            int floorStart = Convert.ToInt32(requestedFloorStart);
            string requestedFloorStartEnd = Console.ReadLine();
            int floorEnd = Convert.ToInt32(requestedFloorStartEnd);
            string requestedPrice = Console.ReadLine();
            double price = Convert.ToDouble(requestedPrice);
            if (floorStart <= floorEnd)
            {
                FlatList requestedFlats = allFlats.FindRequestedFlats(roomCount, floorStart, floorEnd, price);

                InOutUtils.PrintFlats(requestedFlats);
            }
            else
            {
                Console.WriteLine("Netinkamas intervalas");
            }
        }
    }
}
