namespace Remove_Duplicates
{
    internal class Program
    {
        static void Main()
        {
            int[] input1 = { 1, 2, 2, 3, 3 };
            int input2 = 5;

            if (input2 < 0)
            {
                Console.WriteLine("-2");
                return;
            }

            for (int i = 0; i < input2; i++)
            {
                if (input1[i] < 0)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            int[] temp = new int[input2];
            int count = 0;

            for (int i = 0; i < input2; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < count; j++)
                {
                    if (temp[j] == input1[i])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    temp[count] = input1[i];
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
                Console.Write(temp[i] + " ");
        }
    }
}
