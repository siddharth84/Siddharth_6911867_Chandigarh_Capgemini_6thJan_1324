using System;

namespace Currency_Counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 689;
            int output = 0;

            if (input < 0)
            {
                output = -1;
            }
            else
            {
                int temp = input;
                int[] denominations = { 500, 100, 50, 10, 1 };

                foreach (int note in denominations)
                {
                    output += temp / note; 
                    temp %= note;         
                }
            }

            Console.WriteLine("Output1: " + output);
        }
    }
}
