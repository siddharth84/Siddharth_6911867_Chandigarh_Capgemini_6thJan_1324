using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string password = Console.ReadLine();

        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";

        if (Regex.IsMatch(password, pattern))
            Console.WriteLine("Strong");
        else
            Console.WriteLine("Weak");
    }
}
