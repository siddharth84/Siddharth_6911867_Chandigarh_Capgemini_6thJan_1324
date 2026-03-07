using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter the first list of integers: ");
        int[] list1 = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        Console.Write("Enter the second list of integers: ");
        int[] list2 = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        foreach (int n in list1)
        {
            int sum = 0;

            foreach (int x in list2)
            {
                if (x == n)
                    sum += x;
            }

            Console.WriteLine($"{n}-{sum}");
        }
    }
}

