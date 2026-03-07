using System;

class PlotPassword
{
    static int FindPassword(int[] arr, int size)
    {
        if (size < 0)
            return -2;

        int oddSum = 0, evenSum = 0;

        foreach (int val in arr)
        {
            if (val < 0)
                return -1;

            if (val % 2 == 0)
                evenSum += val;
            else
                oddSum += val;
        }

        return (oddSum + evenSum) / 2;
    }

    static void Main()
    {
        int[] arr = { 1, 2, 3, 4 };
        Console.WriteLine(FindPassword(arr, arr.Length));
    }
}

