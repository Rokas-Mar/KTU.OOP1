using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Register.Step1
{
    static class TaskUtils
    {
        public static int CountByGender(List<Dogs> Dogs, Gender gender)
        {
            int count = 0;
            foreach (Dogs dog in Dogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public static Dogs FindOldestDog(List<Dogs> Dogs)
        {
            Dogs oldest = Dogs[0];
            for (int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(Dogs[i].BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }

        public static List<string> FindBreeds(List<Dogs> Dogs)
        {
            List<string> Breeds = new List<string>();
            foreach (Dogs dog in Dogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public static List<Dogs> FilterByBreed(List<Dogs> Dogs, string breed)
        {
            List<Dogs> Filtered = new List<Dogs>();
            foreach (Dogs dog in Dogs)
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
