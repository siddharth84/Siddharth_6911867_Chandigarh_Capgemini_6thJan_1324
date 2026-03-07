using System;
using System.Text.RegularExpressions;

class UserProgramCode
{
    public static string replaceString(string input1, int input2, char input3)
    {
        if (!Regex.IsMatch(input1, "^[a-zA-Z ]+$"))
            return "-1";

        if (input2 <= 0)
            return "-2";

        if (char.IsLetterOrDigit(input3))
            return "-3";

        string[] words = input1.Split(' ');

        if (input2 > words.Length)
            return input1.ToLower();

        int index = input2 - 1;
        words[index] = new string(input3, words[index].Length);

        return string.Join(" ", words).ToLower();
    }
}

class Program
{
    static void Main()
    {
        string input1 = Console.ReadLine();
        int input2 = int.Parse(Console.ReadLine());
        char input3 = Console.ReadLine()[0];

        string result = UserProgramCode.replaceString(input1, input2, input3);

        if (result == "-1")
            Console.WriteLine("Invalid String");
        else if (result == "-2")
            Console.WriteLine("Number not positive");
        else if (result == "-3")
            Console.WriteLine("Character not a special character");
        else
            Console.WriteLine(result);
    }
}
