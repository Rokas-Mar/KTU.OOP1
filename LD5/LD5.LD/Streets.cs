using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5.LD
{
    internal class Street
    {
        public string St { get; set; }
        public int Count { get; set; }

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

        public static bool operator ==(Street street, Street other)
        {
            if(street.St == other.St)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Street street, Street other)
        {
            if (street.St != other.St)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
