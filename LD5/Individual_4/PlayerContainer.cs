using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class PlayerContainer
    {
        private Player[] players;
        private int Capacity;
        public int Count { get; private set; }

        public PlayerContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.players = new Player[capacity];
        }

        public void Add(Player animal)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.players[this.Count++] = animal;
        }

        public Player Get(int index)
        {
            return this.players[index];
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Player[] temp = new Player[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.players[i];
                }
                this.Capacity = minimumCapacity;
                this.players = temp;
            }
        }
    }
}
