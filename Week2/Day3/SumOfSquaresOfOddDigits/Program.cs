using System;

class SumOfSquaresOfOddDigits
{
    static int CalculateSum(int input1)
    {
        if (input1 < 0)
            return -1;

        int sum = 0;
        while (input1 > 0)
        {
            int digit = input1 % 10;
            if (digit % 2 != 0)
                sum += digit * digit;

            input1 /= 10;
        }

        return sum;
    }

    static void Main()
    {
        Console.WriteLine(CalculateSum(12345));
    }
}

