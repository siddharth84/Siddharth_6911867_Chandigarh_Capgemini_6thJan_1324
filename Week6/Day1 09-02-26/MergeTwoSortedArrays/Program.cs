using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr1 = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
        int[] arr2 = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        int[] merged = arr1.Concat(arr2).OrderBy(x => x).ToArray();

        Console.WriteLine(string.Join(",", merged));
    }
}

