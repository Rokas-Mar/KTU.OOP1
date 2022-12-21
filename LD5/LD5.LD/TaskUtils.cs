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
        /// Gets a StreetContainer with all non-repeating streets
        /// </summary>
        /// <param name="Agency1">Register element</param>
        /// <param name="Agency2">Register element</param>
        /// <param name="Agency3">Register element</param>
        /// <returns>StreetContainer element</returns>
        public static StreetsContainer GetStreets(Register Agency1, Register Agency2, Register Agency3)
        {
            Register Estate = new Register();
            Register temp = Agency1;
            StreetsContainer CollectedStreets = new StreetsContainer();

            for (int i = 0; i < 3; i++)
            {
                if (i == 1)
                {
                    temp = Agency2;
                }
                if (i == 2)
                {
                    temp = Agency3;
                }
                for(int j = 0; j < temp.Count(); j++)
                {
                    Street street = new Street(temp.Get(j).Street);
                    if(!CollectedStreets.Contains(street) && !Estate.Contains(temp.Get(j)))
                    {
                        CollectedStreets.Add(street);
                        Estate.Add(temp.Get(j));
                    }
                    else if(!Estate.Contains(temp.Get(j)))
                    {
                        int index = CollectedStreets.IndexOf(street);
                        CollectedStreets.AddCount(index);
                    }
                }
            }
            return CollectedStreets;
        }

        /// <summary>
        /// Gets most sold streets
        /// </summary>
        /// <param name="Agency1">Register element</param>
        /// <param name="Agency2">Register element</param>
        /// <param name="Agency3">Register element</param>
        /// <returns>StreetContainer element with most sold streets</returns>
        public static StreetsContainer GetMostSoldStreets(Register Agency1, Register Agency2, Register Agency3)
        {
            StreetsContainer Streets = GetStreets(Agency1, Agency2, Agency3);
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
        /// Finds the oldest date of all Agencies
        /// </summary>
        /// <param name="Agency1">Register element</param>
        /// <param name="Agency2">Register element</param>
        /// <param name="Agency3">Register element</param>
        /// <returns>DateTime element of oldest date</returns>
        public static DateTime GetOldestDate(Register Agency1, Register Agency2, Register Agency3)
        {
            DateTime minVal = DateTime.MaxValue;
            Register temp = Agency1;
            for (int j = 0; j < 3; j++)
            {
                if (j == 1)
                {
                    temp = Agency2;
                }
                if(j == 2)
                {
                    temp = Agency3;
                }
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
        /// Gets oldest houses of all agencies
        /// </summary>
        /// <param name="Agency1">Register element</param>
        /// <param name="Agency2">Register element</param>
        /// <param name="Agency3">Register element</param>
        /// <returns>Register element of oldest houses</returns>
        public static Register GetOldestHouses(Register Agency1, Register Agency2, Register Agency3)
        {
            Register Result = new Register();

            DateTime minDate = GetOldestDate(Agency1, Agency2, Agency3);
            Register temp = Agency1;
            for (int j = 0; j < 3; j++)
            {
                if (j == 1)
                {
                    temp = Agency2;
                }
                if(j == 2)
                {
                    temp = Agency3;
                }

                for (int i = 0; i < temp.Count(); i++)
                {
                    if (temp.Get(i).BuildDate == minDate && !Result.Contains(temp.Get(i)))
                    {
                        Result.Add(temp.Get(i));
                    }
                }
            }

            return Result;
        }

        /// <summary>
        /// Gets all intersecting enitries
        /// </summary>
        /// <param name="Agency1">Register element</param>
        /// <param name="Agency2">Register element</param>
        /// <param name="Agency3">Register element</param>
        /// <returns>Register element containing all intersecting buildings</returns>
        public static Register IntersectingEntries(Register Agency1, Register Agency2, Register Agency3)
        {
            Register Result = new Register();

            Result.Add(Agency1.Intersects(Agency2));
            Result.Add(Agency1.Intersects(Agency3));
            Result.Add(Agency2.Intersects(Agency3));

            return Result;
        }

        /// <summary>
        /// Gets Estate with area over given area
        /// </summary>
        /// <param name="Agency1">Regsiter element</param>
        /// <param name="Agency2">Regsiter element</param>
        /// <param name="Agency3">Regsiter element</param>
        /// <param name="type">Type of estate to get</param>
        /// <param name="area">Area to get</param>
        /// <returns>Register of all collected Real Estate</returns>
        public static Register CollectEstateOverArea(Register Agency1, Register Agency2, Register Agency3, Type type, double area)   
        {
            Register Collected = new Register();
            Register temp = Agency1;
            for (int i = 0; i < 3; i++)
            {
                if (i == 1)
                {
                    temp = Agency2;
                }
                if (i == 2)
                {
                    temp = Agency3;
                }
                for(int j = 0; j < temp.Count(); j++)
                {
                    if(temp.Get(j).GetType() == type)
                    {
                        if (temp.Get(j).Area > area)
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
