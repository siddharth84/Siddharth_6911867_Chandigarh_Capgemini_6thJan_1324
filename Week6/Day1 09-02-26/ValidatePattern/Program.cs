using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter full sentence: ");
        string input = Console.ReadLine();

        string pattern = @"^Hi how are you Dear [A-Za-z]{16,}$";

        if (Regex.IsMatch(input, pattern))
            Console.WriteLine("Valid format");
        else
            Console.WriteLine("Invalid format");
    }
}

