using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(',');

        string SortWord(string w) =>
            new string(w.Trim().ToLower().OrderBy(c => c).ToArray());

        string first = SortWord(words[0]);

        bool allAnagrams = true;

        foreach (string w in words)
        {
            if (SortWord(w) != first)
            {
                allAnagrams = false;
                break;
            }
        }

        Console.WriteLine(allAnagrams);
    }
}

