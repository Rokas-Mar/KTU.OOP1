using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace K1_practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassRegister classRegister = InOut.Read(@"Duomenys.txt");
            InOut.Print(classRegister);
        }
    }

    internal class InOut
    {
        static public ClassRegister Read(string fileName)
        {
            ClassRegister ReadClasses = new ClassRegister();
            string[] lines = File.ReadAllLines(fileName);
            foreach(string line in lines)
            {
                string[] value = line.Split(';');
                string name = value[0];
                int count = Convert.ToInt32(value[1]);

                Class classes = new Class(name, count);
                ReadClasses.Add(classes);
            }
            return ReadClasses;
        }

        static public void Print(ClassRegister Classes)
        {
            for(int i = 0; i < Classes.Count(); i++)
            {
                Class Temp = Classes.GetIndexedElement(i);
                Console.WriteLine(Temp.Name + "   " + Temp.Count);
            }
        }
    }

    internal class Class
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public Class(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public Class()
        {
        }

        public override string ToString()
        {
            return String.Format("| {0, 10} | {1, 5} |", Name, Count);
        }
    }

    internal class ClassRegister
    {
        List<Class> AllClasses = new List<Class>();

        public ClassRegister(List<Class> Classes)
        {
            AllClasses = Classes;
        }

        public ClassRegister()
        {
            AllClasses = new List<Class>();
        }

        public void Add(Class classes)
        {
            AllClasses.Add(classes);
        }

        public int Count()
        {
            return AllClasses.Count;
        }

        public Class GetIndexedElement(int index)
        {
            return AllClasses[index];
        }
    }
}
