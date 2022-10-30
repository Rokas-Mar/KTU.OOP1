using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3.LAB
{
    internal class HouseContainer
    {
        private House[] Houses;
        public int Count { get; private set; }
        private int Capasity;

        public HouseContainer(int capasity = 16)
        {
            this.Capasity = capasity;
            this.Houses = new House[capasity];
        }

        public void Add(House element)
        {
            if(this.Count == this.Capasity)
            {
                EnsureCapasity(this.Capasity * 2);
            }
            this.Houses[Count++] = element;
        }

        public House Get(int index)
        {
            return this.Houses[index];
        }

        public bool Contains(House element)
        {
            for(int i = 0; i < this.Count; i++)
            {
                if (this.Houses[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void EnsureCapasity(int minCap)
        {
            if(minCap > this.Capasity)
            {
                House[] temp = new House[minCap];
                for(int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Houses[i];
                }
                this.Capasity = minCap;
                this.Houses = temp;
            }
        }
    }
}
