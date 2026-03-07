using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        int secondLargest = arr.Distinct().OrderByDescending(x => x).Skip(1).First();

        Console.WriteLine(secondLargest);
    }
}
