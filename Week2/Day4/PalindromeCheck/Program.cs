using System;

class PalindromeCheck
{
    static int CheckPalindrome(int input)
    {
        if (input < 0)
            return -1;

        int original = input, reverse = 0;

        while (input > 0)
        {
            reverse = reverse * 10 + (input % 10);
            input /= 10;
        }

        if (original == reverse)
            return 1;
        else
            return -2;
    }

    static void Main()
    {
        Console.WriteLine(CheckPalindrome(121));
    }
}

