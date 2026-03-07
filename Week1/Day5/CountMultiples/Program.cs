using System;

namespace CountMultiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 6, 9, 10 };
            int output;

            if (arr.Any(x => x < 0)) output = -1;
            else output = arr.Count(x => x % 3 == 0);

            Console.WriteLine("Output: " + output);
        }
    }
}
