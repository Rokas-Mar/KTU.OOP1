using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3.Exercises
{
    internal class DogsRegister
    {
        private DogsContainer AllDogs;

        public DogsRegister()
        {
            AllDogs = new DogsContainer();
        }

        public DogsRegister(List<Dogs> Dogs)
        {
            foreach (Dogs dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }

        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).Gender.Equals(gender))
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
            DogsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        public Dogs FindOldestDog(DogsContainer Dog)
        {
            Dogs oldest = this.AllDogs.Get(0);
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
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                string breed = this.AllDogs.Get(i).Breed;
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
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                if (this.AllDogs.Get(i).Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(this.AllDogs.Get(i));
                }
            }
            return Filtered;
        }

        public Dogs FindDogByID(int ID)
        {
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                if (this.AllDogs.Get(i).ID == ID)
                {
                    return this.AllDogs.Get(i);
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
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                if (this.AllDogs.Get(i).RequiresVaccination)
                {
                    Filtered.Add(this.AllDogs.Get(i));
                }
            }
            return Filtered;
        }
    }
}
