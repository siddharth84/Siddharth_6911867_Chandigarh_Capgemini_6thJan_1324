using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

class Program
{
    static void Main()
    {
        List<Book> inventory = new List<Book>
        {
            new Book { Title = "C# Basics", Price = 500, Stock = 5 },
            new Book { Title = "LINQ", Price = 750, Stock = 0 },
            new Book { Title = "ASP.NET", Price = 900, Stock = 3 }
        };

        inventory.Add(new Book { Title = "Collections", Price = 650, Stock = 4 });

        decimal targetPrice = 700;
        var cheapBooks = inventory.Where(b => b.Price < targetPrice);

        Console.WriteLine("Books cheaper than " + targetPrice);
        foreach (var book in cheapBooks)
            Console.WriteLine(book.Title);

        inventory.ForEach(b => b.Price *= 1.10m);

        inventory.RemoveAll(b => b.Stock == 0);

        Console.WriteLine("\nFinal Inventory:");
        foreach (var book in inventory)
            Console.WriteLine($"{book.Title} - {book.Price} - Stock: {book.Stock}");
    }
}

