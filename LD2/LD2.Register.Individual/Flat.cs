using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Register.Individual
{
    internal class Flat
    {
        public int Number { get; set; }
        public double Area { get; set; }
        public int RoomCount { get; set; }
        public double SellPrice { get; set; }
        public string Cell { get; set; }

        public int Floor
        {
            get
            {
                int whichFloor;
                if(this.Number % 27 == 0)
                {
                    return 9;
                }
                else
                {
                    switch(this.Number % 3 != 0)
                    {
                        case true:
                            whichFloor = ((this.Number - (this.Number / 27 * 27)) / 3) + 1;
                            break;
                        default:
                            whichFloor = (this.Number - (this.Number / 27 * 27)) / 3;
                            break;
                    }
                }
                return whichFloor;
            }
        }

        public Flat(int number, double area, int roomCount, double sellPrice, string cell)
        {
            Number = number;
            Area = area;
            RoomCount = roomCount;
            SellPrice = sellPrice;
            Cell = cell;
        }
    }
}
