using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class Student
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Group { get; set; }

        public int MarksCount { get; set; }

        private List<int> Marks;

        public double AverageMark { get; set; }

        public Student()
        {
            this.Marks = new List<int>();
        }

        public Student(string surname, string name, string group, int marksCount, List<int> marks)
        {
            this.Surname = surname;
            this.Name = name;
            this.Group = group;
            this.MarksCount = marksCount;
            this.Marks = marks;
            this.AverageMark = this.Average();
        }

        public double GetMark(int index)
        {
            return this.Marks[index];
        }

        public double Average()
        {
            double sum = 0;
            for (int i = 0; i < MarksCount; i++)
            {
                sum += Marks[i];
            }

            return sum / MarksCount;
        }

        public int CompareTo(Student other)
        {
            if(this.AverageMark == other.AverageMark)
            {
                return this.Surname.CompareTo(other.Surname);
            }
            else
            {
                return other.AverageMark.CompareTo(this.AverageMark);
            }
        }
    }
}
