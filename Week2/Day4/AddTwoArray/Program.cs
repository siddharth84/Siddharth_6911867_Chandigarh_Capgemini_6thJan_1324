using System;
using System.Drawing;

namespace AddTwoArray
{
    internal class Program
    {
        static int[] SumArray(int[] input1, int[] input2, int input3)
        {
            if(input3 < 0) 
                return new int[] { -2};

            int[] Output1 = new int[input3];

            for (int i = 0; i < input3; i++)
            {
                if(input1[i] <0 || input2[input3 - 1 - i] < 0)
                {
                    return new int[] { -1 };
                }
                else 
                    Output1[i] = input1[i] + input2[input3 - 1 - i];
            }
            return Output1;
        }
        static void Main(string[] args)
        {
            int[] Input1 = { 1, 2, 3, 4 };
            int[] Input2 = { 4, 3, -2, 1 };
            int Input3 = 4;

            Console.WriteLine(string.Join(",", SumArray(Input1, Input2, Input3)));
        }
    }
}
