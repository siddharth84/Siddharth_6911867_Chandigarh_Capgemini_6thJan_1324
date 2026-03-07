using System;
using System.Linq;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 5, 7 };
            int[] arr2 = { 2, 3, 6 };

            int[] result = CompareArrays(arr1, arr2);
            Console.WriteLine(string.Join(",", result));
        }

        static int[] CompareArrays(int[] arr1, int[] arr2)
        {
            if (arr1.Length < 0 || arr2.Length < 0) return new int[] { -2 };
            if (arr1.Any(x => x < 0) || arr2.Any(x => x < 0)) return new int[] { -1 };

            int n = Math.Min(arr1.Length, arr2.Length);
            int[] output = new int[n];

            for (int i = 0; i < n; i++)
            {
                output[i] = Math.Max(arr1[i], arr2[i]);
            }

            return output;
        }
    }
}

