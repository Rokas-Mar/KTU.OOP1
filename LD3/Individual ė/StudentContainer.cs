using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class StudentContainer
    {
        private Student[] students;
        public int Count { get; private set; }
        private int Capacity;

        public StudentContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.students = new Student[Capacity];
        }

        public void Add(Student element)
        {
            this.students[this.Count++] = element;
        }

        public Student Get(int index)
        {
            return this.students[index];
        }

        public bool Contains(Student element)
        {
            return students.Contains(element);
        }

        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Student a = this.students[i];
                    Student b = this.students[i + 1];
                    if (a.CompareTo(b) < 0)
                    {
                        this.students[i] = b;
                        this.students[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
