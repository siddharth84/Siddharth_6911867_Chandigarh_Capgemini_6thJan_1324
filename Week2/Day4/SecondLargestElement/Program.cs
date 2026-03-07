namespace SecondLargestElement
{
    internal class Program
    {
        static int FindSecondLargest(int[] input1)
        {
            if(input1.Length <0)
                return -2;

            int output1=0;
            int temp = input1[0];

            for(int i=0;i<input1.Length;i++)
            {
                if (input1[i] < 0)
                    return -1;
                else if (input1[i] > temp)
                {
                    output1 = temp;
                    temp = input1[i];
                }
            }

            return output1;
        }
        static void Main(string[] args)
        {
            int[] input1 = { 2, 3, 4, 1, 9 };
            Console.WriteLine(FindSecondLargest(input1));
        }
    }
}
