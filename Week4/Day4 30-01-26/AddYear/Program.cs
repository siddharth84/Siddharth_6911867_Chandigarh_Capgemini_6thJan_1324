using System;

class Program
{
    static void Main()
    {
        string dateInput = "2026-01-31";
        int years = 2;
        AddYears(dateInput, years);
    }

    static void AddYears(string dateInput, int years)
    {
        if (years < 0)
            Console.WriteLine(-2);

        if (!DateTime.TryParse(dateInput, out DateTime date))
            Console.WriteLine(-1);

        DateTime newDate = date.AddYears(years);
        Console.WriteLine("New Date: " + newDate.ToString("yyyy-MM-dd"));

    }
}
