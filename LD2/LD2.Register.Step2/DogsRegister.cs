using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Register.Step2
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
            foreach (Dogs dog in Dogs)
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

        public Dogs getIndexedElement(int index) // individual 1
        {
            return this.AllDogs[index];
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dogs dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public Dogs FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }

        public Dogs FindOldestDog(string breed)
        {
            List<Dogs> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        public Dogs FindOldestDog(List<Dogs> Dog)
        {
            Dogs oldest = this.AllDogs[0];
            for (int i = 1; i < Dog.Count; i++)
            {
                if (DateTime.Compare(Dog[i].BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Dog[i];
                }
            }
            return oldest;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Dogs dog in this.AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public List<Dogs> FilterByBreed(string breed)
        {
            List<Dogs> Filtered = new List<Dogs>();
            foreach (Dogs dog in this.AllDogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }
    }
}
