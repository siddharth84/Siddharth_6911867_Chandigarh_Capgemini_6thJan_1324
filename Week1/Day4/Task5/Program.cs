using System;
using System.Linq;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 9, 8, 7, 6, 5 };

            int[] result = MultiplySortedArrays(arr1, arr2);
            Console.WriteLine(string.Join(",", result));
        }

        static int[] MultiplySortedArrays(int[] arr1, int[] arr2)
        {
            if (arr1.Length < 0 || arr2.Length < 0) return new int[] { -2 };
            if (arr1.Any(x => x < 0) || arr2.Any(x => x < 0)) return new int[] { -1 };

            int n = arr1.Length;
            int[] output = new int[n];

            int[] sorted1 = arr1.OrderBy(x => x).ToArray();
            int[] sorted2 = arr2.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < n; i++)
            {
                output[i] = sorted1[i] * sorted2[n - 1 - i];
            }

            return output;
        }
    }
}

