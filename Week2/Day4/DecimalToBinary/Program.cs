using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static int[] Convert(int input1)
    {
        if (input1 < 0)
            return new int[] { -1 };

        List<int> binary = new List<int>();

        if (input1 == 0)
            binary.Add(0);

        while (input1 > 0)
        {
            binary.Insert(0, input1 % 2);
            input1 /= 2;
        }

        return binary.ToArray();
    }

    static void Main()
    {
        Console.WriteLine(string.Join("", Convert(9))); 
    }
}

