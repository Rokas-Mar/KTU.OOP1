using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Emit;

namespace Individual_4
{
    internal class InOutUtils
    {
        public static StudentRegister ReadStudents(string fileName)
        {
            StudentContainer Students = new StudentContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            string faculty = Lines[0];
            for(int i = 1; i < Lines.Length; i++)
            {
                string line = Lines[i];
                string[] Values = line.Split(';');
                string surname = Values[0];
                string name = Values[1];
                string group = Values[2];
                int markCount = Convert.ToInt32(Values[3]);
                List<int> marks = new List<int>();
                for(int j = 0; j < markCount; j++)
                {
                    marks.Add(Convert.ToInt32(Values[j + 4]));
                }
                Student student = new Student(surname, name, group, markCount, marks);
                Students.Add(student);
            }
            StudentRegister register = new StudentRegister(faculty, Students);
            return register;
        }

        public static void PrintStudents(string label, StudentRegister register)
        {
            Console.WriteLine(label);
            Console.WriteLine(new String('-', 127));
            Console.WriteLine("| {0, -123} ", register.Faculty);
            Console.WriteLine(new String('-', 127));
            Console.WriteLine("| {0, -18} | {1, -15} | {2, -10} | {3, 10} | {4, -18} | {5, -50} ",
                "Pavardė", "Vardas", "Grupė", "Vidurkis", "Pažymių skaičius", "Pažymiai");
            Console.WriteLine(new string('-', 127));
            for (int i = 0; i < register.Count(); i++)
            {
                Student student = register.Get(i);
                Console.Write("| {0, -18} | {1, -15} | {2, -10} | {3, 10:F3} | {4, 18} |",
                    student.Surname, student.Name, student.Group, student.AverageMark, student.MarksCount);
                for(int j = 0; j < student.MarksCount; j++)
                {
                    double mark = student.GetMark(j);
                    Console.Write(" {0}", mark);
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 127));
        }
    }
}
