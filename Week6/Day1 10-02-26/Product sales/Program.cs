
using System;
using System.Collections.Generic;
using System.Linq;

struct Product
{
    public string ProductID;
    public int TotalSales;
}

class Program
{
    static void Main()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();

        Console.WriteLine("Enter product records (empty line to stop):");

        string line;
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
        {
            string[] parts = line.Split('-');
            string id = parts[0];
            int sale = int.Parse(parts[1]);

            if (!dict.ContainsKey(id) || dict[id] < sale)
                dict[id] = sale;
        }

        var sorted = dict.OrderByDescending(x => x.Value);

        foreach (var item in sorted)
            Console.WriteLine($"{item.Key}-{item.Value}");
    }
}
