using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1.Exercises.Individual1
{
    internal class InOutUtils
    {
        public static List<Tourist> ReadAllTourists(string fileName)
        {
            List<Tourist> tourists = new List<Tourist>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach(string line in Lines)
            {
                string[] parts = line.Split(';');
                string name = parts[0];
                string surname = parts[1];
                double cash = double.Parse(parts[2]);

                Tourist tourist = new Tourist(name, surname, cash);
                tourists.Add(tourist);
            }

            return tourists;
        }

        public static void PrintToCSVFile(string fileName, List<Tourist> tourists, double cashCollected)
        {
            string[] lines = new string[tourists.Count + 2];
            lines[0] = "Daugiausiai pinigų skyrę asmenys:";
            lines[1] = String.Format("{0};{1};{2}", "Vardas", "Pavardė", "Pinigų suma");

            for(int i = 0; i < tourists.Count; i++)
            {
                lines[i + 2] = String.Format("{0};{1};{2}", tourists[i].name, tourists[i].surname, tourists[i].cash);
            }

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
            File.AppendAllText(fileName, "Iš viso surinkta: " + cashCollected.ToString(), Encoding.UTF8);
        }

        public static void PrintAllTourists(List<Tourist> Tourists)
        {
            Console.WriteLine(new String('-', 49));
            Console.WriteLine("| {0, -10} | {1, -18} | {2, 11} |",
                "Vardas", "Pavardė", "Pinigų suma");
            Console.WriteLine(new String('-', 49));
            foreach(Tourist tourist in Tourists)
            {
                Console.WriteLine("| {0, -10} | {1, -18} | {2, 11} |",
                    tourist.name, tourist.surname, tourist.cash);
            }
            Console.WriteLine(new String('-', 49));

            Console.WriteLine("Iš viso surinkta: " + TaskUtils.CashCollected(Tourists) + " Eur");
        }
    }
}
