using System;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 123456;
            int result = SumEvenDigits(num);
            Console.WriteLine(result);
        }

        static int SumEvenDigits(int num)
        {
            if (num < 0) return -1;
            if (num > 32767) return -2;

            int sum = 0;
            while (num > 0)
            {
                int digit = num % 10;
                if (digit % 2 == 0) sum += digit;
                num /= 10;
            }
            return sum;
        }
    }
}

