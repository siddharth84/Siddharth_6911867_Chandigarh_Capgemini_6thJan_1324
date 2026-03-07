namespace Reverse_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 12, 34, 56, 17, 2 };
            int input2 = 5;
            int[] output1 = new int[input2 > 0 ? input2 : 1];

            if (input2 < 0) output1[0] = -2;
            else if (input1.Any(x => x < 0)) output1[0] = -1;
            else if (input2 % 2 == 0) output1[0] = -3;
            else
            {
                for (int i = 0; i < input2; i++)
                    output1[i] = input1[input2 - 1 - i];
            }

            Console.WriteLine("Output Array: " + string.Join(",", output1));
        }
    }
}
