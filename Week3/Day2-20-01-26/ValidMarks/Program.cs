using System;

class Program
{
    static void Main()
    {
        int X = Convert.ToInt32(Console.ReadLine());
        int Y = Convert.ToInt32(Console.ReadLine());
        int N1 = Convert.ToInt32(Console.ReadLine());
        int N2 = Convert.ToInt32(Console.ReadLine());
        int M = Convert.ToInt32(Console.ReadLine());

        bool isValid = false;
        int type1 = 0, type2 = 0;

        int i = N1; 

        while (i >= 0)
        {
            int marksFromType1 = i * X;
            int remaining = M - marksFromType1;

            if (remaining >= 0 && remaining % Y == 0)
            {
                int j = remaining / Y;

                if (j <= N2)
                {
                    isValid = true;
                    type1 = i;
                    type2 = j;
                    break; 
                }
            }

            i--;
        }

        if (isValid)
        {
            Console.WriteLine("Valid");
            Console.WriteLine(type1 + " " + type2);
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
}

