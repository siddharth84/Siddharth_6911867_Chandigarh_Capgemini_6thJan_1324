using System;

namespace Remove_Repeated_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 2, 3, 4, 4, 5 };
            int[] output;

            if (Array.Exists(input, x => x < 0))
            {
                output = new int[] { -1 };
            }
            else
            {
                output = input.Distinct().ToArray();
            }

            Console.WriteLine("Output: " + string.Join(",", output));
        }
    }
}
