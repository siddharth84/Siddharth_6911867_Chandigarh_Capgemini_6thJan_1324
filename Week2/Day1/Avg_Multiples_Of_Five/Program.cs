using System;
using System.Linq;

namespace Avg_Multiples_Of_Five
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 10, 20, 33, 5 };
            int input2 = 4; 
            double output = 0;

            if (input2 < 0) output = -2;
            else if (input1.Any(x => x < 0)) output = -1;
            else
            {
                var multiples = input1.Where(x => x % 5 == 0).ToArray();
                if (multiples.Length > 0)
                {
                    output = multiples.Average();
                }
            }

            Console.WriteLine("Output: " + output);
        }
    }
}
