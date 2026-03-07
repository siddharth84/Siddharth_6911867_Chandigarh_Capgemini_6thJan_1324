using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        int count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            bool divisible = false;

            for (int j = 0; j < arr.Length; j++)
            {
                if (i != j && arr[i] % arr[j] == 0)
                {
                    divisible = true;
                    break;
                }
            }

            if (!divisible)
                count++;
        }

        Console.WriteLine(count);
    }
}

