using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Register.Step1
{
    internal class DogsRegister
    {
        private List<Dogs> AllDogs;

        public DogsRegister()
        {
            AllDogs = new List<Dogs>();
        }

        public DogsRegister(List<Dogs> Dogs)
        {
            AllDogs = Dogs;
            foreach(Dogs dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }

        public void Add(Dogs dog)
        {
            AllDogs.Add(dog);
        }
        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        public List<Dogs> returnIndexedElement(int index)
        {
            List<Dogs> dogs = this.AllDogs[index];
            return dogs[index];
        }

    }
}
