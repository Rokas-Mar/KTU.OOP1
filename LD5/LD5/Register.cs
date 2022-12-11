using LD5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD5
{
    internal class Register
    {
        private AnimalContainer AllAnimals;

        public Register()
        {
            AllAnimals = new AnimalContainer();
        }

        public Register(List<Animal> Dogs)
        {
            foreach (Animal dog in Dogs)
            {
                this.AllAnimals.Add(dog);
            }
        }

        public int AnimalsCount()
        {
            return this.AllAnimals.Count;
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                if (AllAnimals.Get(i).Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public Animal FindOldestDog()
        {
            return this.FindOldestDog(this.AllAnimals);
        }

        public Animal FindOldestDog(string breed)
        {
            AnimalContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        public Animal FindOldestDog(AnimalContainer Dog)
        {
            Animal oldest = this.AllAnimals.Get(0);
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
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                string breed = this.AllAnimals.Get(i).Breed;
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
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                if (this.AllAnimals.Get(i).Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(this.AllAnimals.Get(i));
                }
            }
            return Filtered;
        }

        public Animal FindDogByID(int ID)
        {
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                if (this.AllAnimals.Get(i).ID == ID)
                {
                    return this.AllAnimals.Get(i);
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
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                if (this.AllAnimals.Get(i).RequiresVaccination)
                {
                    Filtered.Add(this.AllAnimals.Get(i));
                }
            }
            return Filtered;
        }

        public int CountAggresiveDogs()
        {
            int count = 0;
            for(int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal animal = this.AllAnimals.Get(i);
                if(animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
