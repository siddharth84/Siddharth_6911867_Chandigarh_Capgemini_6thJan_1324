namespace Multiple_of_Product_of_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1 = 56;
            int output;

            if (input1 < 0) output = -1;
            else if (input1 % 3 == 0 || input1 % 5 == 0) output = -2;
            else
            {
                int product = 1;
                int temp = input1;
                while (temp > 0)
                {
                    product *= (temp % 10);
                    temp /= 10;
                }
                output = (product % 3 == 0 || product % 5 == 0) ? 1 : 0;
            }

            Console.WriteLine("Output: " + output);
        }
    }
}
