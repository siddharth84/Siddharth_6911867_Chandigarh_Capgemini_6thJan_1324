using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"\b\d{10}\b";
        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match m in matches)
            Console.WriteLine(m.Value);
    }
}
