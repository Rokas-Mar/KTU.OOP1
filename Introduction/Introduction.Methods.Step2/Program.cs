using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Methods.Step2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double functionResult;
            int a;
            double x;

            Console.WriteLine("Iveskite a reiksme: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Iveskite x reiksme: ");
            x = Convert.ToDouble(Console.ReadLine());

            Program program = new Program();
            functionResult = program.CalculateValue(a, x);
            Console.WriteLine("Reiksme a = {0}, reiksme x = {1}, fx = {2}", a, x, functionResult);
        }

        double CalculateValue(int a, double x)
        {
            double value;

            if(x <= 0)
            {
                value = a * Math.Exp(-1);
            }
            else if(x < 1)
            {
                value = 5 * a * x - 7;
            }
            else
            {
                value = Math.Pow(x + 1, 0.5);
            }

            return value;
        }
    }
}
