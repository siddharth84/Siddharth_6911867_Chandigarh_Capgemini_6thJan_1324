using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"#\w+";
        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match m in matches)
            Console.WriteLine(m.Value);
    }
}

