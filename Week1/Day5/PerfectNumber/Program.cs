using System;

namespace PerfectNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 28;
            int output;

            if (num < 0) output = -2;
            else
            {
                int sum = 0;
                for (int i = 1; i <= num / 2; i++)
                    if (num % i == 0) sum += i;

                if (sum == num && num != 0) output = 1;
                else output = -1;
            }

            Console.WriteLine("Output: " + output);
        }
    }
}
