using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3.Exercises
{
    internal class DogsContainer
    {
        private Dogs[] dogs;
        public int Count { get; private set; }

        public DogsContainer()
        {
            this.dogs = new Dogs[16];
        }

        public void Add(Dogs dog)
        {
            this.dogs[this.Count++] = dog;
        }

        public Dogs Get(int index)
        {
            return this.dogs[index];
        }

        public bool Contains(Dogs dog)
        {
            for(int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
