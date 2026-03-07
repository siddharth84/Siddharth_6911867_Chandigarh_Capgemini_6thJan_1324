using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first date (dd/MM/yyyy): ");
        DateTime d1 = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Enter second date (dd/MM/yyyy): ");
        DateTime d2 = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        int days = Math.Abs((d2 - d1).Days);

        Console.WriteLine(days + " days");
    }
}
