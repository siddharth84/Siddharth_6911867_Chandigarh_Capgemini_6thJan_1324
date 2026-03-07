using System;
using System.Collections.Generic;

class UserProgramCode
{
    public static int convertRomanToDecimal(string roman)
    {
        Dictionary<char, int> values = new Dictionary<char, int>()
        {
            {'I',1}, {'V',5}, {'X',10}, {'L',50},
            {'C',100}, {'D',500}, {'M',1000}
        };

        int total = 0;

        for (int i = 0; i < roman.Length; i++)
        {
            if (!values.ContainsKey(roman[i]))
                return -1;

            int current = values[roman[i]];

            if (i + 1 < roman.Length && values[roman[i + 1]] > current)
                total -= current;
            else
                total += current;
        }

        return total;
    }
}

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int result = UserProgramCode.convertRomanToDecimal(input);
        Console.WriteLine(result);
    }
}
