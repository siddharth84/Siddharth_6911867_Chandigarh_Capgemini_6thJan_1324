using System;

class Program
{
    static int minOps = int.MaxValue;
    static void FindMinOperations(int current, int steps, int target)
    {
        if (current >= target)
        {
            int total = steps + (current - target);
            if (total < minOps)
            {
                minOps = total;
            }
            return;
        }

        if (steps >= minOps) return;

        FindMinOperations(current * 3, steps + 1, target);

        FindMinOperations(current + 2, steps + 1, target);
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());

        if (n <= 10)
        {
            Console.WriteLine(10 - n);
            return;
        }

        FindMinOperations(10, 0, n);
        Console.WriteLine(minOps);
    }
}