using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        int n = arr.Length + 1;
        int expectedSum = n * (n + 1) / 2;
        int actualSum = arr.Sum();

        Console.WriteLine(expectedSum - actualSum);
    }
}

