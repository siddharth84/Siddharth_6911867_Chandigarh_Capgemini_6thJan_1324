using System;

namespace Sum_Cube_of_Primes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            long output = 0;

            if (n < 0) output = -1;
            else if (n > 32676) output = -2;
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    if (IsPrime(i)) output += (long)Math.Pow(i, 3);
                }
            }

            Console.WriteLine("Output: " + output);
        }

        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
    }
}
