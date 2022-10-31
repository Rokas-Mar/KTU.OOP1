using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3.LAB
{
    /// <summary>
    /// House container class
    /// </summary>
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

        /// <summary>
        /// Adds element to container
        /// </summary>
        /// <param name="element">House element</param>
        public void Add(House element)
        {
            if(this.Count == this.Capasity)
            {
                EnsureCapasity(this.Capasity * 2);
            }
            this.Houses[Count++] = element;
        }

        /// <summary>
        /// Gets element from container
        /// </summary>
        /// <param name="index">index of which element to get</param>
        /// <returns>House element</returns>
        public House Get(int index)
        {
            return this.Houses[index];
        }

        /// <summary>
        /// Checks if Container contains element
        /// </summary>
        /// <param name="element">House element</param>
        /// <returns>true if Container contains element</returns>
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

        /// <summary>
        /// Ensures Container capacity
        /// </summary>
        /// <param name="minCap">minimum capasity</param>
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
