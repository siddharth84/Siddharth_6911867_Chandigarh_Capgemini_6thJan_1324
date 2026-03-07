using System;

class CalculateSavings
{
    static int FindSavings(int input1, int input2)
    {
        if (input1 > 9000)
            return -1;
        if (input1 < 0)
            return -2;
        if (input2 < 0)
            return -4;

        int foodExpense = (input1 * 50) / 100;
        int travelExpense = (input1 * 20) / 100;
        int totalExpense = foodExpense + travelExpense;

        int savings = input1 - totalExpense;

        if (input2 == 31)
            savings += 500;

        return savings;
    }

    static void Main()
    {
        int salary = 8000;
        int daysWorked = 31;

        Console.WriteLine(FindSavings(salary, daysWorked));
    }
}
