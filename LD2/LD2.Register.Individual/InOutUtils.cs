using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD2.Register.Individual
{
    class InOutUtils
    {
        public static FlatList ReadFlats(string fileName)
        {
            FlatList Flats = new FlatList();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int number = int.Parse(Values[0]);
                double area = double.Parse(Values[1]);
                int roomCount = int.Parse(Values[2]);
                double sellPrice = double.Parse(Values[3]);
                string cell = Values[4];

                Flat flat = new Flat(number, area, roomCount, sellPrice, cell);
                if (!Flats.Contains(flat))
                {
                    Flats.Add(flat);
                }
            }
            return Flats;
        }

        public static void PrintFlats(FlatList flats)
        {
            Console.WriteLine(new String('-', 81));
            Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12} | {4, -15} |",
                "Buto Nr.", "Plotas", "Kambariu Sk.", "Kaina", "Telefonas");
            Console.WriteLine(new string('-', 81));
            for (int i = 0; i < flats.FlatCount(); i++)
            {
                Flat flat = flats.GetIndexedElement(i);
                Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12:F2} | {4, -15} | ",
                    flat.Number, flat.Area, flat.RoomCount, flat.SellPrice, flat.Cell);
            }
            Console.WriteLine(new string('-', 81));
        }

        public static void PrintFlats(List<Flat> flats)
        {
            Console.WriteLine(new String('-', 81));
            Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12} | {4, -15} |",
                "Buto Nr.", "Plotas", "Kambariu Sk.", "Kaina", "Telefonas");
            Console.WriteLine(new string('-', 81));
            if(flats.Count != 0)
            {
                for (int i = 0; i < flats.Count; i++)
                {
                    Flat flat = flats[i];
                    Console.WriteLine("| {0, 8} | {1, -15} | {2, -15} | {3, -12:F2} | {4, -15} | ",
                        flat.Number, flat.Area, flat.RoomCount, flat.SellPrice, flat.Cell);
                }
            }
            else
            {
                Console.WriteLine("Butų nerasta");
            }
            Console.WriteLine(new string('-', 81));
        }
    }
}
