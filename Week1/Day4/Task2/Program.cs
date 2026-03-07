namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int n = number.ToString().Length;
            int output1 = 0;

            if (number < 0)
            {
                output1 = -1;
            }
            else if (n > 3)
            {
                output1 = -2;
            }
            else
            {
                int temp = number;
                int sum = 0;

                while (temp > 0)
                {
                    int rem = temp % 10;
                    sum += (int)Math.Pow(rem, n);
                    temp = temp / 10;
                }

                if (number == sum)
                {
                    output1 = 1;
                }
                else
                {
                    output1 = 0;
                }
            }

            Console.WriteLine(output1);
        }
    }
}
