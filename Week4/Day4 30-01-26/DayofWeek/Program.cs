using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        string inputDate = "31/01/2026";

        if (DateTime.TryParseExact(
                inputDate,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime date))
        {
            DateTime newDate = date.AddYears(1);
            Console.WriteLine("New Date: " + newDate.ToString("dd/MM/yyyy"));
            Console.WriteLine("Day: " + newDate.DayOfWeek);
        }
        else
        {
            Console.WriteLine("Invalid date format");
        }
    }
}
