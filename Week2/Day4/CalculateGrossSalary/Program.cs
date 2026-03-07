using System;

class CalculateGrossSalary
{
    static int GetGrossSalary(int basicPay, int workingDays)
    {
        if (basicPay < 0)
            return -1;
        if (basicPay > 10000)
            return -2;
        if (workingDays > 31)
            return -3;

        int da = (basicPay * 75) / 100;
        int hra = (basicPay * 50) / 100;

        return basicPay + da + hra;
    }

    static void Main()
    {
        Console.WriteLine(GetGrossSalary(8000, 30));
    }
}

