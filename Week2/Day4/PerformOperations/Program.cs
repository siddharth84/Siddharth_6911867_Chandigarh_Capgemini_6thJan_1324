using System;

class PerformOperations
{
    static int Calculate(int input1, int input2, int input3)
    {
        if (input1 < 0 && input2 < 0)
            return -1;

        switch (input3)
        {
            case 1:
                return input1 + input2;

            case 2:
                return input1 - input2;

            case 3:
                return input1 * input2;

            case 4:
                return input2 != 0 ? input1 / input2 : 0;

            default:
                return 0;
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter numbers");
        int input1 = Convert.ToInt32(Console.ReadLine());
        int input2 = Convert.ToInt32(Console.ReadLine());
        int input3 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(Calculate(input1, input2, input3));
    }
}

