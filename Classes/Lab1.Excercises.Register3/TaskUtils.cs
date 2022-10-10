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
    }
}
