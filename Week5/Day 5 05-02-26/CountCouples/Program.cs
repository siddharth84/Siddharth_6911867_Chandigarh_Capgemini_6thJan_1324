using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("Enter array (comma-separated): ");
        int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        int count = 0;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int sum = arr[i] + arr[i + 1];

            if (sum % N == 0)
                count++;
        }

        Console.WriteLine("Total couples: " + count);
    }
}
