using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Excercises.Register.Step6
{
    static class TaskUtils
    {
        public static int CountByGender(List<Dog> Dogs, Gender gender)
        {
            int count = 0;
            foreach(Dog dog in Dogs)
            {
                if(dog.Gender.Equals(gender))
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

    }
}
