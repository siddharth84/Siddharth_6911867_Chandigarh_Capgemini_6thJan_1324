using System;

class UserProgramCode
{
    public static string ReplaceString(string input)
    {
        string[] words = input.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Equals("is"))
            {
                words[i] = "is not";
            }
        }

        return string.Join(" ", words);
    }
}

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(UserProgramCode.ReplaceString(input));
    }
}
