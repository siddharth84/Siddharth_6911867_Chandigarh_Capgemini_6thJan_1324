using System;

class PerformOperations
{
    static void Main()
    {
        int input1 = Convert.ToInt32(Console.ReadLine());
        int input2 = Convert.ToInt32(Console.ReadLine());
        int sum = 0;

        for(int i = input1; i <= input2; i+=input1)
        {
            sum += i;
        }
        Console.WriteLine(sum);
    }
}
