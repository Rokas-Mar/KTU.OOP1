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
        private int Capacity;
        public int Count { get; private set; }

        public DogsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.dogs = new Dogs[capacity];
        }

        public DogsContainer(DogsContainer container): this(container.Count + 1)
        {
            for(int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }

        public void Put(Dogs dog, int index)
        {
            this.dogs[index] = dog;
        }

        public void Insert(Dogs dog, int index)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.dogs[i] = this.dogs[i - 1];
            }
            this.dogs[index] = dog;
            this.Count++;
        }

        public void Remove(Dogs dog)
        {
            for(int i = 0; i < this.Count; i++)
            {
                if (this.Get(i) == dog)
                {
                    RemoveAt(i);
                }
            }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.dogs[index] = this.dogs[index + 1];
            }
            this.Count--;
        }

        public void Add(Dogs dog)
        {
            if(this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.dogs[this.Count++] = dog;
        }

        public Dogs Get(int index)
        {
            return this.dogs[index];
        }

        public bool Contains(Dogs dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Equals(dog))
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

        public Dogs FindOldestDog()
        {
            return this.FindOldestDog(this);
        }

        public Dogs FindOldestDog(string breed)
        {
            DogsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        public Dogs FindOldestDog(DogsContainer Dog)
        {
            Dogs oldest = this.Get(0);
            for (int i = 1; i < Dog.Count; i++)
            {
                if (DateTime.Compare(Dog.Get(i).BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Dog.Get(i);
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

        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }

        public Dogs FindDogByID(int ID)
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

                if (this.FindDogByID(vacc.DogID) != null)
                {
                    Dogs dog = this.FindDogByID(vacc.DogID);
                    if (vacc > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vacc.Date;
                    }
                }
            }
        }

        public DogsContainer FilterByVaccinationExpired()
        {
            DogsContainer Filtered = new DogsContainer();
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
            if(minimumCapacity > this.Capacity)
            {
                Dogs[] temp = new Dogs[minimumCapacity];
                for(int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }

        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Dogs a = this.dogs[i];
                    Dogs b = this.dogs[i + 1];
                    if(a.CompareTo(b) < 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public DogsContainer Intersect(DogsContainer other)
        {
            DogsContainer result = new DogsContainer();
            for(int i = 0; i < this.Count; i++)
            {
                Dogs current = this.dogs[i];
                if(other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
