using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LD5.LD
{
    /// <summary>
    /// Task utility class
    /// </summary>
    internal class TaskUtils
    {
        /// <summary>
        /// Gets all streets with no repetitions
        /// </summary>
        /// <param name="realEstate">Register list</param>
        /// <returns>Street container element</returns>
        public static StreetsContainer GetStreets(List<Register> realEstate)
        {
            StreetsContainer Streets = new StreetsContainer();
            for (int j = 0; j < realEstate.Count; j++)
            {
                Register temp = realEstate[j];

                for (int i = 0; i < temp.Count(); i++)
                {
                    Street street = new Street(temp.Get(i).Street);
                    if (!Streets.Contains(street))
                    {
                        Streets.Add(street);
                    }
                    else
                    {
                        int index = Streets.IndexOf(street);
                        Streets.AddCount(index);
                    }
                }
            }
            return Streets;
        }

        /// <summary>
        /// Gets most sold streets
        /// </summary>
        /// <param name="realEstate">Register List element</param>
        /// <returns>street container element with most sold streets</returns>
        public static StreetsContainer GetMostSoldStreets(List<Register> realEstate)
        {
            StreetsContainer Streets = GetStreets(realEstate);
            int maxCount = Streets.GetMaxCount();

            StreetsContainer Filtered = new StreetsContainer();

            for(int i = 0; i < Streets.Count(); i++)
            {
                if(maxCount == Streets.Get(i).Count)
                {
                    Filtered.Add(Streets.Get(i));
                }
            }

            return Filtered;
        }

        /// <summary>
        /// Gets the oldest date amongst RealEstate
        /// </summary>
        /// <param name="realEstate">Register List element</param>
        /// <returns>Date of oldest house</returns>
        public static DateTime GetOldestDate(List<Register> realEstate)
        {
            DateTime minVal = DateTime.MaxValue;

            for(int j = 0; j < realEstate.Count; j++)
            {
                Register temp = realEstate[j];
                for(int i = 0; i < temp.Count(); i++)
                {
                    if(minVal > temp.Get(i).BuildDate)
                    {
                        minVal = temp.Get(i).BuildDate;
                    }
                }
            }

            return minVal;
        }

        /// <summary>
        /// Gets oldest houses
        /// </summary>
        /// <param name="realEstate">Register List element</param>
        /// <returns>Register of all oldest houses</returns>
        public static Register GetOldestHouses(List<Register> realEstate)
        {
            Register Result = new Register();

            DateTime minDate = GetOldestDate(realEstate);

            for (int j = 0; j < realEstate.Count; j++)
            {
                Register temp = realEstate[j];

                for (int i = 0; i < temp.Count(); i++)
                {
                    if (temp.Get(i).BuildDate == minDate)
                    {
                        Result.Add(temp.Get(i));
                    }
                }
            }

            return Result;
        }

        /// <summary>
        /// Gets all houses that are in multiple agencies
        /// </summary>
        /// <param name="realEstate">Register List element</param>
        /// <returns>Register of intersecting RealEstate</returns>
        public static Register IntersectingEntries(List<Register> realEstate)
        {
            Register Result = new Register();

            for(int i = 1; i < realEstate.Count; i++)
            {
                for(int j = 0; j < realEstate.Count - 1; j++)
                {
                    if(i == j)
                    {
                        break;
                    }
                    
                    for(int k = 0; k < realEstate[j].Count(); k++)
                    {
                        Result.Add(realEstate[i].Intersects(realEstate[j]));
                    }
                }
            }

            return Result;
        }

        /// <summary>
        /// Gets Houses with plot over 100
        /// </summary>
        /// <param name="realEstate">Register List element</param>
        /// <returns>Register of all collected houses</returns>
        public static Register CollectHousesOver100(List<Register> realEstate)
        {
            Register Collected = new Register();

            for(int i = 0; i < realEstate.Count(); i++)
            {
                Register temp = realEstate[i];
                for(int j = 0; j < temp.Count(); j++)
                {
                    if(temp.Get(j) is House)
                    {
                        if (temp.Get(j).Area > 100)
                        {
                            Collected.Add(temp.Get(j));
                        }
                    }
                }
            }

            return Collected;
        }

        /// <summary>
        /// Gets Flats with area over 50
        /// </summary>
        /// <param name="realEstate">Register List element</param>
        /// <returns>Register of collected elements</returns>
        public static Register CollectFlatsOver50(List<Register> realEstate)
        {
            Register Collected = new Register();

            for (int i = 0; i < realEstate.Count(); i++)
            {
                Register temp = realEstate[i];
                for (int j = 0; j < temp.Count(); j++)
                {
                    if (temp.Get(j) is Flat)
                    {
                        if (temp.Get(j).Area > 50)
                        {
                            Collected.Add(temp.Get(j));
                        }
                    }
                }
            }

            return Collected;
        }
    }
}
