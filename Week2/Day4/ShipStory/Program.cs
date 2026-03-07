using System;

class ShipStory
{
    static int[] CombineArrays(int[] arr1, int[] arr2, int size)
    {
        if (size < 0)
            return new int[] { -2 };

        for (int i = 0; i < size; i++)
        {
            if (arr1[i] < 0 || arr2[i] < 0)
                return new int[] { -1 };
        }

        int[] result = new int[size];

        for (int i = 0; i < size; i++)
        {
            result[i] = arr1[i] + arr2[size - 1 - i];
        }

        return result;
    }

    static void Main()
    {
        int[] a = { 1, 2, 3 };
        int[] b = { 4, 5, 6 };

        Console.WriteLine(string.Join(",", CombineArrays(a, b, 3)));
    }
}

