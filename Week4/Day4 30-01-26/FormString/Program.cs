using System;
using System.Text;
using System.Text.RegularExpressions;

class UserProgramCode
{
    public static string formString(string[] input1, int input2)
    {
        Regex regex = new Regex("^[a-zA-Z]+$");

        foreach (string s in input1)
        {
            if (!regex.IsMatch(s))
                return "-1";
        }

        StringBuilder result = new StringBuilder();

        foreach (string s in input1)
        {
            if (input2 <= s.Length)
                result.Append(s[input2 - 1]);
            else
                result.Append('$');
        }

        return result.ToString();
    }
}

class Program
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        string[] input1 = new string[k];

        for (int i = 0; i < k; i++)
            input1[i] = Console.ReadLine();

        int n = int.Parse(Console.ReadLine());

        string result = UserProgramCode.formString(input1, n);

        if (result == "-1")
            Console.WriteLine("-1");
        else
            Console.WriteLine(result);
    }
}

