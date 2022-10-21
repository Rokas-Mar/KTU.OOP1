// Rokas Marcinkevičius IFF-2/10
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Data.SqlTypes;

namespace K1Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookStore bookStore = InOut.InputBooks(@"Knyga.csv");
            List<Book> soldBooks = InOut.InputSoldBooks(@"Parduota.csv");

            if (bookStore != null)
            {
                File.WriteAllText(@"Rezultatai.txt", String.Empty);
                InOut.Print(bookStore, @"Rezultatai.txt", "Pradinė knygyno lentelė");
                InOut.Print(soldBooks, @"Rezultatai.txt", "Pradinė knygų pardavimo lentelė");
                bookStore.AddSalePrice(soldBooks);
                InOut.Print(soldBooks, @"Rezultatai.txt", "Papildyta knygų pardavimo lentelė");
                InOut.Print(bookStore, @"Rezultatai.txt", "Pakeista knygyno lentelė");
                decimal sum = bookStore.Sum();
                string line = String.Format("Dar turi surinkti {0} eurų", Convert.ToString(sum));
                File.AppendAllText(@"Rezultatai.txt", line, Encoding.UTF8);
            }
        }

    }
}

//----------CLASSES----------//
class Book
{
    public string Seller { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }

    public Book(string seller, string name, int count, decimal price)
    {
        Seller = seller;
        Name = name;
        Count = count;
        Price = price;
    }

    public Book()
    { }

    public Book(string name)
    {
        Name = name;
        Price = 0;
        Count = 1;
    }

    public override string ToString()
    {
        return String.Format("| {0, -18} | {1, -18} | {2, 8} | {3, 8} |", Seller, Name, Count, Price);
    }

    public static bool operator <=(Book lhs, Book rhs)
    {
        return lhs.Price <= rhs.Price;
    }
    
    public static bool operator >=(Book lhs, Book rhs)
    {
        return lhs.Price >= rhs.Price;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
}

class BookStore
{
    private List<Book> Books { get; set; }

    public BookStore(List<Book> books)
    {
        Books = books;
    }
    public BookStore()
    {
        Books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public int GetCount()
    {
        return Books.Count;
    }

    public Book GetBook(int index)
    {
        return Books[index];
    }

    public int IndexMaxPrice(Book book)
    {
        int index = 0;
        for(int i = 0; i < Books.Count; i++)
        {
            if(book.Name == Books[i].Name)
            {
                if(book <= Books[i])
                {
                    if (Books[i].Count != 0)
                    {
                        index = i;
                        book.Price = Books[i].Price;
                    }
                }
            }
        }
        return index;
    }

    public void AddSalePrice(List<Book> books)
    {
        for(int i = 0; i < books.Count; i++)
        {
            int index = IndexMaxPrice(books[i]);
            books[i].Price = Books[index].Price;
            Books[index].Count--;
        }
    }

    public decimal Sum()
    {
        decimal sum = 0;
        for(int i = 0; i < Books.Count; i++)
        {
            sum += Books[i].Price * Books[i].Count;
        }
        return sum;
    }
}

//----------IN OUT UTILS----------//

class InOut
{
    public static BookStore InputBooks(string fileName)
    {
        BookStore bookStore = new BookStore();
        string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(';');
            string seller = parts[0];
            string name = parts[1];
            int count = Convert.ToInt32(parts[2]);
            decimal price = Convert.ToDecimal(parts[3]);

            Book book = new Book(seller, name, count, price);
            bookStore.AddBook(book);
        }
        return bookStore;
    }

    public static List<Book> InputSoldBooks(string fileName)
    {
        List<Book> soldBooks = new List<Book>();
        string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
        for (int i = 0; i < lines.Length; i++)
        {
            string name = lines[i];

            Book book = new Book(name);
            soldBooks.Add(book);
        }
        return soldBooks;
    }

    public static void Print(BookStore bookStore, string fileName, string header)
    {
        string[] Lines = new string[bookStore.GetCount() + 5];
        Lines[0] = header;
        Lines[1] = new String('-', 65);
        Lines[2] = String.Format("| {0, -18} | {1, -18} | {2, -8} | {3, -8} |", "Platintojas", "Pavadinimas", "Kiekis", "Kaina");
        Lines[3] = new String('-', 65);
        for (int i = 0; i < bookStore.GetCount(); i++)
        {
            Book book = bookStore.GetBook(i);
            Lines[i + 4] = book.ToString();
        }
        Lines[bookStore.GetCount() + 4] = new String('-', 65);

        File.AppendAllLines(fileName, Lines, Encoding.UTF8);
    }

    public static void Print(List<Book> soldBooks, string fileName, string header)
    {
        string[] Lines = new string[soldBooks.Count + 5];
        Lines[0] = header;
        Lines[1] = new String('-', 44);
        Lines[2] = String.Format("| {0, -18} | {1, 8} | {2, 8} |", "Knyga", "Kiekis", "Kaina");
        Lines[3] = new String('-', 44);
        for (int i = 0; i < soldBooks.Count; i++)
        {
            Lines[i + 4] = String.Format("| {0, -18} | {1, 8} | {2, 8} |", soldBooks[i].Name, soldBooks[i].Count, soldBooks[i].Price);
        }
        Lines[soldBooks.Count + 4] = new String('-', 44);

        File.AppendAllLines(fileName, Lines, Encoding.UTF8);
    }
}