using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Excercises.Register.Step6
{
    static class TaskUtils
    {
        public static int CountByGender(List<Dog> Dogs, Gender gender)
        {
            int count = 0;
            foreach (Dog dog in Dogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public static Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for (int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(Dogs[i].BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }

        public static List<string> FindBreeds(List<Dog> Dogs)
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in Dogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public static List<Dog> FilterByBreed(List<Dog> Dogs, string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                if (dog.Breed.Equals(breed))
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        public static List<string> GetBreeds(List<Dog> Dogs)
        {
            List<string> Breeds = new List<string>();

            foreach(Dog dog in Dogs)
            {
                Breeds.Add(dog.Breed);
            }

            return Breeds;
        }

        public static string MostPopularBreed(List<string> Breeds, List<Dog> Dogs)
        {
            int[] BreedCount = new int[Breeds.Count];

            for(int i = 0; i < Breeds.Count; i++)
            {
                for(int j = 0; j < Dogs.Count; j++)
                {
                    if (Breeds[i] == Dogs[j].Breed)
                    {
                        BreedCount[i]++;
                    }
                }
            }
            int maxValue = BreedCount.Max();
            return Breeds[BreedCount.ToList().IndexOf(maxValue)];
        }
    }
}
