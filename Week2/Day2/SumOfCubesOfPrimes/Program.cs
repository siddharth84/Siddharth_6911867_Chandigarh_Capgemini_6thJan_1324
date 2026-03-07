using System;

class SumOfCubesOfPrimes
{
    static bool IsPrime(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    static int SumOfCubes(int limit)
    {
        if (limit < 0)
            return -1;
        if (limit > 32767)
            return -2;

        int sum = 0;
        for (int i = 2; i <= limit; i++)
        {
            if (IsPrime(i))
                sum += i * i * i;
        }

        return sum;
    }

    static void Main()
    {
        int limit = 10;
        Console.WriteLine(SumOfCubes(limit));
    }
}

