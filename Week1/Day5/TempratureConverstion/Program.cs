using System;

namespace TempratureConverstion
{
        internal class Program
        {
            static void Main(string[] args)
            {
                double fahrenheit = 98.6;
                double output;

                if (fahrenheit < 0) output = -1;
                else output = (fahrenheit - 32) * 5 / 9;

                Console.WriteLine("Output: " + output);
            }
        }
}
