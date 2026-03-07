using System;
using System.Linq;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int search = 3;
            int result = SearchElement(arr, search);
            Console.WriteLine(result);
        }

        static int SearchElement(int[] arr, int x)
        {
            if (arr.Length < 0) return -2;
            if (arr.Any(e => e < 0)) return -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x) return i;
            }

            return 1; 
        }
    }
}

