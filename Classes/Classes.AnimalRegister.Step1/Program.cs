using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Classes.Register.Step2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog test = new Dog(123, "Reksas", "Buldogas", new DateTime(2014, 1, 1), Gender.Male);
            Console.WriteLine("Registro Nr: {0}", test.ID);
            Console.WriteLine("Vardas: {0}", test.Name);
            Console.WriteLine("Veislė: {0}", test.Breed);
            Console.WriteLine("Gimimo data: {0:yyyy-MM-dd}", test.BirthDate);
            Console.WriteLine("Lytis: {0}", test.Gender);
        }
    }
}
