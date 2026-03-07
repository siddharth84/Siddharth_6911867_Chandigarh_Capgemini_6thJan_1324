using System;

class LeapYear
{
    static int IsLeapYear(int year)
    {
        if (year < 0)
            return -1;

        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            return 1;
        else
            return 0;
    }

    static void Main()
    {
        int result = IsLeapYear(20260);
        if (result == 1)
            Console.WriteLine("Is LeapYear");
        else if (result == 0)
            Console.WriteLine("Is Not LeapYear");
        else 
            Console.WriteLine(result);

    }
}
