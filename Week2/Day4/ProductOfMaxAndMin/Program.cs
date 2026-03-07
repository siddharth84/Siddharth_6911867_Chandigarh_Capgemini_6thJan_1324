using System;

class ProductOfMaxAndMin
{
    static int FindProduct(int[] arr, int size)
    {
        if (size < 0)
            return -2;

        foreach (int val in arr)
        {
            if (val < 0)
                return -1;
        }

        int min = arr[0];
        int max = arr[0];

        for (int i = 1; i < size; i++)
        {
            if (arr[i] < min)
                min = arr[i];
            if (arr[i] > max)
                max = arr[i];
        }

        return min * max;
    }

    static void Main()
    {
        int[] arr = { 4, 2, 9, 1, 5 };
        int size = arr.Length;

        Console.WriteLine(FindProduct(arr, size));
    }
}

