namespace Multiple_of_Three
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 1, 2, 3, 4, 5, 6 };
            int input2 = 6;
            int output;

            if (input2 < 0) output = -2;
            else if (input1.Any(x => x < 0)) output = -1;
            else output = input1.Count(x => x % 3 == 0);

            Console.WriteLine("Output: " + output);
        }
    }
}
