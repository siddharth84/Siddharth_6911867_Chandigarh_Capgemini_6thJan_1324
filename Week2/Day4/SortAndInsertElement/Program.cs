using System;
using System.Collections.Generic;

class SortAndInsertElement
{
    static int[] SortAndInsert(int[] arr, int size, int element)
    {
        if (size < 0)
            return new int[] { -2 };

        foreach (int val in arr)
        {
            if (val < 0)
                return new int[] { -1 };
        }

        List<int> list = new List<int>(arr);

        list.Sort();

        int index = list.BinarySearch(element);
        if (index < 0)
            index = ~index;

        list.Insert(index, element);

        return list.ToArray();
    }

    static void Main()
    {
        int[] arr = { 5, 2, 8, 4 };
        int size = arr.Length;
        int element = 6;

        int[] result = SortAndInsert(arr, size, element);
        Console.WriteLine(string.Join(",", result));
    }
}

