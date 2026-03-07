using System;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4 };
            int result = MultiplyPositiveNumbers(arr);
            Console.WriteLine(result);
        }

        static int MultiplyPositiveNumbers(int[] arr)
        {
            if (arr.Length < 0) return -2;

            int result = 1;
            foreach (var num in arr)
            {
                if (num > 0) result *= num;
            }

            return result;
        }
    }
}

