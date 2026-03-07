using System;

class SearchElement
{
    static int Search(int[] arr, int size, int key)
    {
        if (size < 0)
            return -2;

        foreach (int val in arr)
        {
            if (val < 0)
                return -1;
        }

        for (int i = 0; i < size; i++)
        {
            if (arr[i] == key)
                return 1;
        }

        return -3;
    }

    static void Main()
    {
        int[] arr = { 1, 2, 3, 4 };
        int size = arr.Length;
        int key = 5;

        Console.WriteLine(Search(arr, size, key));
    }
}

