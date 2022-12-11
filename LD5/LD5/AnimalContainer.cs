using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5
{
    internal class AnimalContainer
    {
        private Animal[] animals;
        private int Capacity;
        public int Count { get; private set; }

        public AnimalContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.animals = new Animal[capacity];
        }

        public AnimalContainer(AnimalContainer container) : this(container.Count + 1)
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }

        public void Put(Animal animal, int index)
        {
            this.animals[index] = animal;
        }

        public void Insert(Animal animal, int index)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.animals[i] = this.animals[i - 1];
            }
            this.animals[index] = animal;
            this.Count++;
        }

        public void Remove(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i) == animal)
                {
                    RemoveAt(i);
                }
            }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.animals[index] = this.animals[index + 1];
            }
            this.Count--;
        }

        public void Add(Animal animal)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[this.Count++] = animal;
        }

        public Animal Get(int index)
        {
            return this.animals[index];
        }

        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }


        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public Animal FindOldestDog()
        {
            return this.FindOldestDog(this);
        }

        public Animal FindOldestDog(string breed)
        {
            AnimalContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        public Animal FindOldestDog(AnimalContainer animal)
        {
            Animal oldest = this.Get(0);
            for (int i = 1; i < animal.Count; i++)
            {
                if (DateTime.Compare(animal.Get(i).BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = animal.Get(i);
                }
            }
            return oldest;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < this.Count; i++)
            {
                string breed = this.Get(i).Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public AnimalContainer FilterByBreed(string breed)
        {
            AnimalContainer Filtered = new AnimalContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }

        public Animal FindDogByID(int ID)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).ID == ID)
                {
                    return this.Get(i);
                }
            }
            return null;
        }

        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vacc in Vaccinations)
            {

                if (this.FindDogByID(vacc.AnimalID) != null)
                {
                    Animal dog = this.FindDogByID(vacc.AnimalID);
                    if (vacc > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vacc.Date;
                    }
                }
            }
        }

        public AnimalContainer FilterByVaccinationExpired()
        {
            AnimalContainer Filtered = new AnimalContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).RequiresVaccination)
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }
        }

        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if (comparator.Compare(a,b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public void Sort()
        {
            Sort(new AnimalsComparator());
        }

        public AnimalContainer Intersect(AnimalContainer other)
        {
            AnimalContainer result = new AnimalContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal current = this.animals[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
