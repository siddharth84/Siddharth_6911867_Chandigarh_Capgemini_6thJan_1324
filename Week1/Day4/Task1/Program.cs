namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int output1;

            if (number < 0)
            {
                output1 = -1;
            }
            else if (number > 7)
            {
                output1 = -2;
            }
            else
            {
                output1 = 1;
                for (int i = 1; i <= number; i++)
                {
                    output1 = output1 * i;
                }
            }
            Console.WriteLine(output1);
        }
    }
}
