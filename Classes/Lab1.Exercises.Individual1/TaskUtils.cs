using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.Individual1
{
    internal class TaskUtils
    {
        public static List<Tourist> ShareCash(List<Tourist> Tourists)
        {
            List<Tourist> touristCollected = new List<Tourist>();

            for(int i = 0; i < Tourists.Count; i++)
            {
                touristCollected.Add(Tourists[i]);
                touristCollected[i].cash /= 4;
            }

            return touristCollected;
        }

        public static double CashCollected(List<Tourist> Tourists)
        {
            double totalCash = 0;

            foreach(Tourist tourist in Tourists)
            {
                totalCash += (tourist.cash / 4);
            }

            return totalCash;
        }

        public static double MostDonated(List<Tourist> Tourists)
        {
            double maxDono = double.MinValue;

            foreach (Tourist tourist in Tourists)
            {
                if (maxDono < tourist.cash)
                {
                    maxDono = tourist.cash;
                }
            }

            return maxDono;
        }

        public static List<Tourist> BiggestDonators(List<Tourist> Tourists)
        {
            List<Tourist> BiggestDoners = new List<Tourist>();
            double maxDono = MostDonated(Tourists);

            foreach (Tourist tourist in Tourists)
            {
                if (tourist.cash == maxDono && tourist.cash > 0)
                {
                    BiggestDoners.Add(tourist);
                }
            }

            return BiggestDoners;
        }
    }
}
