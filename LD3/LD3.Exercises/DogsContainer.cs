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
    }
}
