using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentRegister Students = InOutUtils.ReadStudents(@"Students.csv");
            InOutUtils.PrintStudents("Initial student list", Students);
            Students.Sort();
            InOutUtils.PrintStudents("Sorted student list", Students);
        }
    }
}
