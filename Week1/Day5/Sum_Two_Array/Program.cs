namespace Sum_Two_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 21, 23, 41, 4 };
            int[] input2 = { 3, 4, 1, 5 };
            int input3 = 4;
            int[] output = new int[input3 > 0 ? input3 : 1];

            if (input3 < 0) output[0] = -2;
            else if (input1.Any(x => x < 0) || input2.Any(x => x < 0)) output[0] = -1;
            else
            {
                for (int i = 0; i < input3; i++)
                    output[i] = input1[i] + input2[input3 - 1 - i];
            }

            Console.WriteLine("Output: " + string.Join(",", output));
        }
    }
}
