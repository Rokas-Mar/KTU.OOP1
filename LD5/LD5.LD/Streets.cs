using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    /// <summary>
    /// Main Street class
    /// </summary>
    internal class Street
    {
        public string St { get; set; } // Street name
        public int Count { get; set; } // Street repetitions count

        public Street() { }

        public Street(string street) 
        {
            St = street;
            Count = 1;
        }

        public Street(string street, int count)
        {
            St = street;
            Count = count;
        }

        /// <summary>
        /// == override
        /// </summary>
        /// <param name="street">Street element</param>
        /// <param name="other">Street elememt</param>
        /// <returns>true, if elements match</returns>
        public static bool operator ==(Street street, Street other)
        {
            if(street.St == other.St)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// != override
        /// </summary>
        /// <param name="street">Street element</param>
        /// <param name="other">Street element</param>
        /// <returns>true, if elements don't match</returns>
        public static bool operator !=(Street street, Street other)
        {
            if (street.St != other.St)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Equals override
        /// </summary>
        /// <param name="obj">other object</param>
        /// <returns>true, if object equals given object</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// GetHashCode override
        /// </summary>
        /// <returns>base hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
