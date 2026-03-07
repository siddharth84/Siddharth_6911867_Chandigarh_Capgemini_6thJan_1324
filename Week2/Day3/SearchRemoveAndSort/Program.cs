using System;
using System.Collections.Generic;

class SearchRemoveAndSort
{
    static int[] ProcessArray(int[] input1, int input2, int input3)
    {
        if (input2 < 0)
            return new int[] { -2 };

        foreach (int val in input1)
        {
            if (val < 0)
                return new int[] { -1 };
        }

        List<int> list = new List<int>(input1);

        if (!list.Contains(input3))
            return new int[] { -3 };

        list.Remove(input3);
        list.Sort();

        return list.ToArray();
    }

    static void Main()
    {
        int[] arr = { 54, 26, 78, 32, 55 };
        int[] result = ProcessArray(arr, 5, 78);

        Console.WriteLine(string.Join(",", result));
    }
}

