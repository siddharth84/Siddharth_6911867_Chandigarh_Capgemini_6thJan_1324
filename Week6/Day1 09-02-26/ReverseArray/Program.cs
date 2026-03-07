using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        Array.Reverse(arr);

        Console.WriteLine(string.Join(",", arr));
    }
}

