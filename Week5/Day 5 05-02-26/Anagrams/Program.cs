using System;
using System.Linq;

class Program
{
    static string SortWord(string w)
    {
        return new string(w.Trim().ToLower().OrderBy(c => c).ToArray());
    }

    static void Main()
    {
        Console.Write("Enter comma-separated words: ");
        string[] words = Console.ReadLine().Split(',');

        string first = SortWord(words[0]);

        bool isAnagram = true;

        foreach (string w in words)
        {
            if (SortWord(w) != first)
            {
                isAnagram = false;
                break;
            }
        }

        Console.WriteLine(isAnagram);
    }
}
