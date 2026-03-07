namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array size:");
            int size = Convert.ToInt32(Console.ReadLine());

            int output1 = 0;

            if (size < 0)
            {
                output1 = -2;
            }
            else
            {
                int[] arr = new int[size];
                int sumEven = 0, sumOdd = 0;

                Console.WriteLine("Enter array elements:");
                for (int i = 0; i < size; i++)
                {
                    arr[i] = Convert.ToInt32(Console.ReadLine());

                    if (arr[i] < 0)
                    {
                        output1 = -1;
                        Console.WriteLine(output1);
                        return;
                    }

                    if (arr[i] % 2 == 0)
                        sumEven += arr[i];
                    else
                        sumOdd += arr[i];
                }

                output1 = (sumEven + sumOdd) / 2;
            }

            Console.WriteLine("Output: " + output1);
        }
    }
}
