using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.LAB
{
    /// <summary>
    /// Class of streets and their accurance count
    /// </summary>
    internal class SellingSt
    {
        public string Street { get; set; } //House street
        public int StCount { get; set; } // Street accurance count
        public SellingSt(string street, int stCount)
        {
            Street = street;
            StCount = stCount;
        }
        public SellingSt()
        {
        }
    }
}
