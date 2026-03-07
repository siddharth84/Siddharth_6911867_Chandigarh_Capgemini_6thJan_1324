using System;
using System.Collections.Generic;

namespace Remove_Negative_And_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 20, -10, 4, 78 };
            int input2 = 4; 
            int[] output;

            if (input2 < 0)
            {
                output = new int[] { -1 };
            }
            else
            {
                output = input1.Where(x => x >= 0).ToArray();
                Array.Sort(output);
            }

            Console.WriteLine("Output: " + string.Join(",", output));
        }
    }
}
