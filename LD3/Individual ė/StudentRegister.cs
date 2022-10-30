using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class StudentRegister
    {
        public string Faculty{ get; set; }
        private StudentContainer Students;

        public StudentRegister(string faculty, StudentContainer studentContainer)
        {
            Faculty = faculty;
            Students = studentContainer;
        }

        public StudentRegister()
        {
            Students = new StudentContainer();
        }

        public void Add(Student student)
        {
            Students.Add(student);
        }

        public Student Get(int index)
        {
            return Students.Get(index);
        }

        public bool Contains(Student element)
        {
            return Students.Contains(element);
        }

        public int Count()
        {
            return Students.Count;
        }

        public void Sort()
        {
            Students.Sort();
        }
    }
}
