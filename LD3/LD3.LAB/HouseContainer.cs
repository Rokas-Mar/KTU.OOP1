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
        private int Capacity;

        public HouseContainer(int capasity = 16)
        {
            this.Capacity = capasity;
            this.Houses = new House[capasity];
        }

        /// <summary>
        /// Adds element to container
        /// </summary>
        /// <param name="element">House element</param>
        public void Add(House element)
        {
            if(this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
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
        /// Puts house element into index
        /// </summary>
        /// <param name="element">House element</param>
        /// <param name="index">index to put element into</param>
        public void Put(House element, int index)
        {
            this.Houses[index] = element;
        }

        /// <summary>
        /// Inserts element into given spot
        /// </summary>
        /// <param name="element">House element</param>
        /// <param name="index">index to insert element into</param>
        public void Insert(House element, int index)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.Houses[i] = this.Houses[i - 1];
            }
            this.Houses[index] = element;
            this.Count++;
        }

        /// <summary>
        /// Removes element from container
        /// </summary>
        /// <param name="element">which element to remove</param>
        public void Remove(House element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i) == element)
                {
                    RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Removes indexed element from Container
        /// </summary>
        /// <param name="index">which element to remove</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.Houses[index] = this.Houses[index + 1];
            }
            this.Count--;
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
        public void EnsureCapacity(int minCap)
        {
            if(minCap > this.Capacity)
            {
                House[] temp = new House[minCap];
                for(int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Houses[i];
                }
                this.Capacity = minCap;
                this.Houses = temp;
            }
        }

        /// <summary>
        /// Sorts houses by Street and Number
        /// </summary>
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    House a = this.Houses[i];
                    House b = this.Houses[i + 1];
                    if (a.CompareTo(b) < 0)
                    {
                        this.Houses[i] = b;
                        this.Houses[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
