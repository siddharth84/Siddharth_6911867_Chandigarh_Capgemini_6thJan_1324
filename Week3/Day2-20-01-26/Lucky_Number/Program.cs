using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucky_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int input1, input2;
            input1 = Convert.ToInt16(Console.ReadLine());
            input2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(UserMainCode.luckynumbers(input1, input2));
        }
    }
}

